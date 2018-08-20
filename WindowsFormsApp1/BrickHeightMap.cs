using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

public static class BrickHeightMap {
	// Make sure to pass changing variables such as brick color each time
	private static PictureBox GeneratedImage;
	private static PictureBox GeneratedNormal;
	private static Color BrickColor;

	private static int BrickHeight = 128;
	private static int CementHeight = 120;
	private static int BrickGradient = 4;
	private static int BrickRoughness = 2;
	private static int CementRoughness = 10;

	public static void SetPictureBoxes(PictureBox gi, PictureBox gn) {
		GeneratedImage = gi;
		GeneratedNormal = gn;
	}

	public static void CreateBrickHeightMap(Color brickColor) {
		BrickColor = brickColor;
		// Create normal map
		// At this point we have the basic setup of the brick texture
		// There are only two colors in the image so it is the perfect place to start creating the normal map
		GeneratedNormal.Image = new Bitmap(GeneratedNormal.Width, GeneratedNormal.Height);
		for (int i = 0; i < GeneratedNormal.Height; i++) {
			for (int j = 0; j < GeneratedNormal.Height; j++) {
				if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, j), BrickColor)) {
					((Bitmap)GeneratedNormal.Image).SetPixel(i, j, Color.FromArgb(BrickHeight, BrickHeight, BrickHeight));
				}
				else {
					((Bitmap)GeneratedNormal.Image).SetPixel(i, j, Color.FromArgb(CementHeight, CementHeight, CementHeight));
				}
			}
		}

		/*int count = 0;
		while (RoundBrick() && count < 50) {
			count++;
		}*/

		// Here we add some roughness to the bricks
		for (int i = 0; i < GeneratedNormal.Height; i++) {
			for (int j = 0; j < GeneratedNormal.Width; j++) {
				// If pixel is part of the brick
				if (((Bitmap)GeneratedImage.Image).GetPixel(j, i).R > CementHeight) {
					int newColor = (int)((BrickTexture.AverageNoise(j, i) + 1) * BrickRoughness) + ((Bitmap)GeneratedImage.Image).GetPixel(j, i).R;
					if (newColor < BrickHeight) {
						newColor = BrickHeight;
					}
					((Bitmap)GeneratedNormal.Image).SetPixel(j, i, Color.FromArgb(newColor, newColor, newColor));
				}
				// Add roughness to the cement
				else {
					int newColor = (int)(BrickTexture.AverageNoise(j, i) * CementRoughness) + CementHeight;
					if (newColor < CementHeight) {
						newColor = CementHeight;
					}
					((Bitmap)GeneratedNormal.Image).SetPixel(j, i, Color.FromArgb(newColor, newColor, newColor));
				}
			}
		}
	}

	// Round the edges of the bricks
	public static bool RoundBrick() {
		int baseColor = BrickHeight;
		bool result = false;

		for (int i = 0; i < GeneratedNormal.Height; i++) {
			for (int j = 0; j < GeneratedNormal.Height; j++) {
				// If we are on a brick pixel of the original color then we will try and adjust it's color (if it is next to darker pixels)
				//if (ColorComparison(((Bitmap)GeneratedNormal.Image).GetPixel(i, j), Color.FromArgb(BrickHeight, BrickHeight, BrickHeight))) {
				if (((Bitmap)GeneratedNormal.Image).GetPixel(i, j).R > CementHeight) {
					// Check to see if we are at the edge of the image, if so we should wrap around the coordinates to the other side
					int up = Helper.ImageRange(true, j - 1);
					int down = Helper.ImageRange(true, j + 1);
					int left = Helper.ImageRange(false, i - 1);
					int right = Helper.ImageRange(false, i + 1);

					// First check up
					if (((Bitmap)GeneratedNormal.Image).GetPixel(i, up).R + BrickGradient < BrickHeight && ((Bitmap)GeneratedNormal.Image).GetPixel(i, up).R + BrickGradient < baseColor) {
						baseColor = ((Bitmap)GeneratedNormal.Image).GetPixel(i, up).R + BrickGradient;
						result = true;
					}
					// Then check down
					if (((Bitmap)GeneratedNormal.Image).GetPixel(i, down).R + BrickGradient < BrickHeight && ((Bitmap)GeneratedNormal.Image).GetPixel(i, down).R + BrickGradient < baseColor) {
						baseColor = ((Bitmap)GeneratedNormal.Image).GetPixel(i, down).R + BrickGradient;
						result = true;
					}
					// Then check left
					if (((Bitmap)GeneratedNormal.Image).GetPixel(left, j).R + BrickGradient < BrickHeight && ((Bitmap)GeneratedNormal.Image).GetPixel(left, j).R + BrickGradient < baseColor) {
						baseColor = ((Bitmap)GeneratedNormal.Image).GetPixel(left, j).R + BrickGradient;
						result = true;
					}
					// Then check right
					if (((Bitmap)GeneratedNormal.Image).GetPixel(right, j).R + BrickGradient < BrickHeight && ((Bitmap)GeneratedNormal.Image).GetPixel(right, j).R + BrickGradient < baseColor) {
						baseColor = ((Bitmap)GeneratedNormal.Image).GetPixel(right, j).R + BrickGradient;
						result = true;
					}
					//Console.WriteLine(((Bitmap)GeneratedNormal.Image).GetPixel(i, up).R + " " + ((Bitmap)GeneratedNormal.Image).GetPixel(i, down).R + " " +
					//	((Bitmap)GeneratedNormal.Image).GetPixel(left, j).R + " " + ((Bitmap)GeneratedNormal.Image).GetPixel(right, j).R + " " + baseColor);

					((Bitmap)GeneratedNormal.Image).SetPixel(i, j, Color.FromArgb(baseColor, baseColor, baseColor));
					baseColor = BrickHeight;
				}
			}
		}
		return result;
	}
}
