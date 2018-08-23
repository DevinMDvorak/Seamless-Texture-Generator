using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Collections.Generic;

public static class BrickTexture {
	// These are the two images that we are creating
	private static PictureBox GeneratedImage;
	private static PictureBox GeneratedNormal;

	// All of the data required for creating the texture
	private static int Rows;
	private static int Columns;
	private static float CementRatio;
	private static Color MainColor;
	private static Color CementColor;

	// These deal with the accent bricks
	// First array contains the amount of each accent color and the other array contains the colors (paired up by index)
	// Give these private access later on
	public static int[] AccentCounts;
	public static Color[] AccentColors;

	// Max amount that an RGB value can be off from the cements main color
	private static int CementColorVariety = 10;

	// Call this function when the program loads up, this should only be called once
	public static void Start() {
		AccentCounts = new int[10];
		AccentColors = new Color[10];
		for (int i = 0; i < 10; i++) {
			AccentCounts[i] = 0;
			AccentColors[i] = Color.White;
		}
	}

	// This array is used for creating areas of switching color gradients
	// Instead of random colors it will help create more flowing colors
	private static double[,] SmoothNoiseArray;

	private static bool GenerateHeightMap = true;

	// Call this when the program is loaded up to get the references to the pictureboxes
	public static void SetPictureBoxes(PictureBox gi, PictureBox gn) {
		GeneratedImage = gi;
		GeneratedNormal = gn;
	}

	// This function sets all of the brick information retrieved from the form (BrickPanel)
	// It will be triggered from the form and is only called when ready to generate the texture
	public static void Setup(int row, int col, float cRatio, Color main, Color cement) {
		Rows = row;
		Columns = col;
		CementRatio = cRatio;
		MainColor = main;
		CementColor = cement;

		// Build the texture
		GenerateTexture();
	}

	// This is the function that actually deletes the pixels from the brick to curve the corners
	// Example: top right corner of the brick pass (true, false, x, y, list)
	public static void CurveCorner(bool up, bool left, int x, int y, List<int> list) {
		int index = 0;

		if (up && left) {
			for (int i = y; i < y + list.Count; i++) {
				for (int j = 0; j < list[index]; j++) {
					((Bitmap)GeneratedImage.Image).SetPixel(Helper.ImageRange(false, x + j), Helper.ImageRange(true, i), CementColor);
				}
				index++;
			}
		}
		else if (up && !left) {
			for (int i = y; i < y + list.Count; i++) {
				for (int j = 0; j > -list[index]; j--) {
					((Bitmap)GeneratedImage.Image).SetPixel(Helper.ImageRange(false, x + j), Helper.ImageRange(true, i), CementColor);
				}
				index++;
			}
		}
		else if (!up && left) {
			for (int i = y; i > y - list.Count; i--) {
				for (int j = 0; j < list[index]; j++) {
					((Bitmap)GeneratedImage.Image).SetPixel(Helper.ImageRange(false, x + j), Helper.ImageRange(true, i), CementColor);
				}
				index++;
			}
		}
		else if (!up && !left) {
			for (int i = y; i > y - list.Count; i--) {
				for (int j = 0; j > -list[index]; j--) {
					((Bitmap)GeneratedImage.Image).SetPixel(Helper.ImageRange(false, x + j), Helper.ImageRange(true, i), CementColor);
				}
				index++;
			}
		}
	}

	// This is basically a recursive flood fill function
	// It will fill up any brick area with the chosen color
	public static void FillAccentBrick(int x, int y, int AccentColorIndex) {
		if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(x, y), MainColor)) {
			((Bitmap)GeneratedImage.Image).SetPixel(x, y, AccentColors[AccentColorIndex]);
		}
		else {
			return;
		}
		FillAccentBrick(Helper.ImageRange(false, x - 1), y, AccentColorIndex);
		FillAccentBrick(Helper.ImageRange(false, x + 1), y, AccentColorIndex);
		FillAccentBrick(x, Helper.ImageRange(true, y - 1), AccentColorIndex);
		FillAccentBrick(x, Helper.ImageRange(true, y + 1), AccentColorIndex);
	}

	// Pass a pixel coordinate to this function to receive the average noise value (-1 ... 1) of it's corners
	public static double AverageNoise(int x, int y) {
		double averageNoise = 0;
		averageNoise = SmoothNoiseArray[x, y] + SmoothNoiseArray[Helper.ImageRange(false, x + 1), y];
		averageNoise += SmoothNoiseArray[x, Helper.ImageRange(true, y + 1)] + SmoothNoiseArray[Helper.ImageRange(false, x + 1), Helper.ImageRange(true, y + 1)];
		averageNoise /= 4.0;
		
		return averageNoise;
	}

	// Main function that actually creates our texture
	// This will be called from out setup function which is called from the main form
	public static void GenerateTexture() {
		//Console.WriteLine(Rows + " " + Columns + " " + CementRatio + " " + MainColor + " " + CementColor);
		Console.WriteLine("Starting to generate brick texture");
		GeneratedImage.Image = new Bitmap(GeneratedImage.Width, GeneratedImage.Height);

		// Initialize our 2d noise array with random values between -1 and 1
		Random rand = new Random();
		SmoothNoiseArray = new double[GeneratedImage.Width, GeneratedImage.Height];
		for (int i = 0; i < GeneratedImage.Height; i++) {
			for (int j = 0; j < GeneratedImage.Width; j++) {
				SmoothNoiseArray[j, i] = 1 - rand.NextDouble() * 2;
				//Console.WriteLine(SmoothNoiseArray[j, i]);
			}
		}

		// First we set up the main color of the image
		// Simple loop over the entire thing setting each pixel to the same main color
		for (int i = 0; i < GeneratedImage.Height; i++) {
			for (int j = 0; j < GeneratedImage.Height; j++) {
				((Bitmap)GeneratedImage.Image).SetPixel(i, j, MainColor);
			}
		}

		// Average thickness of brick plus cement
		float averageLayerHeight = GeneratedImage.Height / (float)Rows;
		float averageLayerWidth = GeneratedImage.Width / (float)Columns;

		float averageBrick = GeneratedImage.Height / (float)Rows / (1 + CementRatio);
		//Console.WriteLine(averageBrick);

		float averageCement = GeneratedImage.Height / (float)Rows - averageBrick;
		//Console.WriteLine(averageCement);

		//Console.WriteLine(55%25.6);
		// Add the horizontal cement lines to the image
		for (int i = 0; i < GeneratedImage.Height; i++) {
			for (int j = 0; j < GeneratedImage.Height; j++) {
				if (j % averageLayerHeight <= averageCement) {
					((Bitmap)GeneratedImage.Image).SetPixel(i, j, CementColor);
					//Console.WriteLine("Add horizontal lines");
				}
			}
		}

		// Add the vertical lines to the image
		for (int i = 0; i < GeneratedImage.Height; i++) {
			for (int j = 0; j < GeneratedImage.Height; j++) {
				if (i % averageLayerWidth <= averageCement/* && (j / averageLayer) % 2 > 1*/) {
					if ((j / averageLayerHeight) % 2 > 1) {
						((Bitmap)GeneratedImage.Image).SetPixel(i, j, CementColor);
					}
					else {
						int staggeredRow = i + (int)averageLayerWidth / 2;
						if (staggeredRow < GeneratedImage.Width) {
							((Bitmap)GeneratedImage.Image).SetPixel(staggeredRow, j, CementColor);
						}
					}
				}
			}
		}

		// Here we are gonna add curves to the bricks
		//
		//
		// This variable has to be less than 1/2 of the size of smallest side of the bricks
		// So if the the height of a brick is 20 pixels and the length is 50 pixels then curve must be less than 10
		int curve = 10; // Use 5 for our basis for now
		List<int> curvature = new List<int>();
		//curvature.Add(0);
		for (int i = 1; i <= curve; i++) {
			// This represents the point at the top of the current unit
			double top = Math.Sqrt(Math.Pow(curve, 2) - Math.Pow(curve - i, 2));
			// This represents the point below the current unit
			double bot = Math.Sqrt(Math.Pow(curve, 2) - Math.Pow(curve - i + 1, 2));
			//Math.Sqrt(curve - i) + Math.Sqrt(curve - i)
			if (curve - (int)((top + bot + 1) / 2) > 0) {
				curvature.Add(curve - (int)((top + bot + 1) / 2));
				Console.WriteLine(top + " " + bot + " " + curvature[i - 1]);
			}
		}
		// I could fix this slightly by checking that the 0 index is equal to the number of last indexes that are the same
		// And then the 1 index would be equal to that plus the secodn to last indexes that are the same
		// But this is close and works for now

		// Subtract the curved area from the bricks
		for (int i = 0; i < GeneratedImage.Height; i++) {
			bool found = false;
			for (int j = 0; j < GeneratedImage.Width; j++) {
				// First check that the current pixel is the main color
				if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(j, i), MainColor)) {
					int up = Helper.ImageRange(true, i - 1);
					int down = Helper.ImageRange(true, i + 1);
					int left = Helper.ImageRange(false, j - 1);
					int right = Helper.ImageRange(false, j + 1);
					// First check up
					if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(j, up), CementColor)) {
						// Up plus left
						if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(left, i), CementColor)) {
							CurveCorner(true, true, j, i, curvature);
							//Console.WriteLine("UP LEFT : " + j + " " + i + " " + left + " " + up);
							j += curve;
							right = Helper.ImageRange(false, j + 1);
							found = true;
							if (!(j < GeneratedImage.Width)) {
								return;
							}
						}
						// Up plus right
						if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(right, i), CementColor)) {
							CurveCorner(true, false, j, i, curvature);
							found = true;
							j += 2;
						}
					}
					// Then check down
					else if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(j, down), CementColor)) {
						// Down plus left
						if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(left, i), CementColor)) {
							CurveCorner(false, true, j, i, curvature);
							j += curve;
							right = Helper.ImageRange(false, j + 1);
							if (!(j < GeneratedImage.Width)) {
								return;
							}
						}
						// Down plus right
						if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(right, i), CementColor)) {
							CurveCorner(false, false, j, i, curvature);
							j += 2;
						}
					}
				}
			}
			if (found) {
				i += curve;
				found = false;
			}
		}


		// Add some sloppy cement overlap for more realistic texture
		int nodes = 1500; // Change this to be a percentage of the picture size later or/and give user option to adjust this
		// This should reach a max value of 3 then reset to 0, basically it changes which direction the point moves when searching
		int increment = 0;
		while (nodes > 0) {
			int nodeSize = rand.Next(5, 25);
			if (increment == 0) {
				for (int i = rand.Next(0, GeneratedImage.Height); i < GeneratedImage.Height; i++) {
					for (int j = rand.Next(0, GeneratedImage.Height); j < GeneratedImage.Height; j++) {
						// Check if pixel is part of brick at edge of cement
						if (AddSloppyCement(i, j, nodeSize)) {
							i = GeneratedImage.Height;
							j = GeneratedImage.Height;
						}
					}
				}
			}
			else if (increment == 1) {
				for (int i = rand.Next(0, GeneratedImage.Height); i < GeneratedImage.Height; i++) {
					for (int j = rand.Next(0, GeneratedImage.Height); j >= 0; j--) {
						// Check if pixel is part of brick at edge of cement
						if (AddSloppyCement(i, j, nodeSize)) {
							i = GeneratedImage.Height;
							j = 0;
						}
					}
				}
			}
			else if (increment == 2) {
				for (int j = rand.Next(0, GeneratedImage.Height); j < GeneratedImage.Height; j++) {
					for (int i = rand.Next(0, GeneratedImage.Height); i < GeneratedImage.Height; i++) {
						// Check if pixel is part of brick at edge of cement
						if (AddSloppyCement(i, j, nodeSize)) {
							i = GeneratedImage.Height;
							j = GeneratedImage.Height;
						}
					}
				}
			}
			else if (increment == 3) {
				for (int j = rand.Next(0, GeneratedImage.Height); j < GeneratedImage.Height; j++) {
					for (int i = rand.Next(0, GeneratedImage.Height); i >= 0; i--) {
						// Check if pixel is part of brick at edge of cement
						if (AddSloppyCement(i, j, nodeSize)) {
							i = 0;
							j = GeneratedImage.Height;
						}
					}
				}
			}

			increment++;
			if (increment == 4) {
				increment = 0;
			}
			nodes--;
		}

		// Create height map after the base texture has been completed
		// Uncomment this to allow creation of height map
		BrickHeightMap.CreateBrickHeightMap(MainColor);


		// Here we will add our accent bricks
		for (int index = 0; index < 10; index++) {
			int count = AccentCounts[index];
			while (count > 0) {
				int x = rand.Next(GeneratedImage.Width);
				int y = rand.Next(GeneratedImage.Height);
				if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(x, y), MainColor)) {
					FillAccentBrick(x, y, index);
					count--;
				}
			}
		}

		// Get the r g b values for our brick color so we can add variance to each individual value
		int r = MainColor.R;
		int g = MainColor.G;
		int b = MainColor.B;
		Color BrickVariationColor = new Color();
		// Add slight variety to the main color
		// We are now also adding variety to the accent colors here.  May split this apart later
		for (int i = 0; i < GeneratedImage.Height; i++) {
			for (int j = 0; j < GeneratedImage.Width; j++) {
				if (!Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, j), CementColor)) {
					r = ((Bitmap)GeneratedImage.Image).GetPixel(i, j).R;
					g = ((Bitmap)GeneratedImage.Image).GetPixel(i, j).G;
					b = ((Bitmap)GeneratedImage.Image).GetPixel(i, j).B;
					//Console.WriteLine("In the second loop");
					//BrickVariationColor = new Color();

					// This is the original way of changing the brick color uncomment to revert back
					//BrickVariationColor = Color.FromArgb(Helper.ColorRange(r + rand.Next(-30, 30)), Helper.ColorRange(g + rand.Next(-30, 30)), Helper.ColorRange(b + rand.Next(-30, 30)));
					// This is the new way using the 2d noise array
					int r2 = r + (int)AverageNoise(j, i) * 10;
					BrickVariationColor = Color.FromArgb(Helper.ColorRange(r + rand.Next(-30, 30)), Helper.ColorRange(g + rand.Next(-30, 30)), Helper.ColorRange(b + rand.Next(-30, 30)));

					((Bitmap)GeneratedImage.Image).SetPixel(i, j, BrickVariationColor);
				}
			}
		}

		// This should be combined with the previous double-for loop as an else statement
		// Do the same thing for the cement
		r = CementColor.R;
		g = CementColor.G;
		b = CementColor.B;
		// Add slight variety to the cement color
		for (int i = 0; i < GeneratedImage.Height; i++) {
			for (int j = 0; j < GeneratedImage.Height; j++) {
				if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, j), CementColor)) {
					BrickVariationColor = Color.FromArgb(Helper.ColorRange(r + rand.Next(-CementColorVariety, CementColorVariety)),
						Helper.ColorRange(g + rand.Next(-CementColorVariety, CementColorVariety)),
						Helper.ColorRange(b + rand.Next(-CementColorVariety, CementColorVariety)));
					((Bitmap)GeneratedImage.Image).SetPixel(i, j, BrickVariationColor);
				}
			}
		}
	}

	// This function adds stray pieces of cement
	private static bool AddSloppyCement(int i, int j, int size) {
		if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, j), MainColor)) {
			int up = Helper.ImageRange(true, j - 1);
			int down = Helper.ImageRange(true, j + 1);
			int left = Helper.ImageRange(false, i - 1);
			int right = Helper.ImageRange(false, i + 1);
			// First check up and down
			if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, up), CementColor) ||
				Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, down), CementColor)) {
				AddCementPixels(false);
				return true;
			}
			// Then check left and right
			else if (Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(left, j), CementColor) ||
				Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(right, j), CementColor)) {
				AddCementPixels(true);
				//Console.WriteLine("Added a vertical line!");
				return true;
			}
		}
		return false;

		// Local function that actually adds the new cement pixels to the image
		void AddCementPixels(bool vertical) {
			for (int k = 0; k < size; k++) {
				// This is a check making sure we do not extend the cement down into the middle of the brick.
				// This case most frequently happens when extending from the vertical lines but can also happen if we double up on the horizontal lines
				if (vertical) {
					if (!Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(Helper.ImageRange(false, i - 1), j), CementColor) &&
						!Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(Helper.ImageRange(false, i + 1), j), CementColor)) {
						k = size;
					}
				}
				else {
					if (!Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, Helper.ImageRange(true, j - 1)), CementColor) &&
						!Helper.ColorComparison(((Bitmap)GeneratedImage.Image).GetPixel(i, Helper.ImageRange(true, j + 1)), CementColor)) {
						k = size;
					}
				}

				((Bitmap)GeneratedImage.Image).SetPixel(i, j, CementColor);
				if (vertical) {
					j++;
					if (j >= GeneratedImage.Height) {
						j = 0;
					}
				}
				else {
					i++;
					if (i >= GeneratedImage.Width) {
						i = 0;
					}
				}
			}
		}
	}
}