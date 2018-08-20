using System;
using System.Drawing;

public static class Helper {
	static int ImageHeight;
	static int ImageWidth;

	public static void SetImageSize(int h, int w) {
		ImageHeight = h;
		ImageWidth = w;
	}

	// Compare if the rgb values of two colors are the same
	public static bool ColorComparison(Color c1, Color c2) {
		if (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B) {
			return true;
		}
		else {
			return false;
		}
	}

	// When altering individual rgb values we must make sure that the int range stays between 0 - 255
	public static int ColorRange(int value) {
		if (value > 255) {
			return 255;
		}
		else if (value < 0) {
			return 0;
		}
		return value;
	}

	// This class checks whether or not the adjacent pixel wraps around the screen
	public static int ImageRange(bool vertical, int value) {
		if (vertical) {
			if (value < 0) {
				value = ImageHeight + value;
			}
			if (value >= ImageHeight) {
				value = value - ImageHeight;
			}
		}
		else {
			if (value < 0) {
				value = ImageWidth + value;
			}
			if (value >= ImageWidth) {
				value = value - ImageWidth;
			}
		}
		return value;
	}
}
