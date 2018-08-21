using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
	public partial class BrickAccentForm : Form {
		private Button[] buttons;
		private ColorDialog[] colorDialogs;
		private NumericUpDown[] numericUpDowns;

		private const int totalPercent = 100;

		public BrickAccentForm() {
			InitializeComponent();
		}

		private void BrickAccentForm_Load(object sender, EventArgs e) {
			buttons = new Button[10];
			colorDialogs = new ColorDialog[10];
			numericUpDowns = new NumericUpDown[10];

			Button button;
			ColorDialog colorDialog;
			NumericUpDown numericUpDown;
			EventHandler buttonHandler = new EventHandler(ButtonClick);

			for (int i = 0; i < 10; i++) {
				// Create a new button, color-dialog and track-bar
				button = new Button();
				colorDialog = new ColorDialog();
				numericUpDown = new NumericUpDown();

				// Style button and trackbar based on brick texture class
				button.BackColor = BrickTexture.AccentColors[i];
				colorDialog.Color = BrickTexture.AccentColors[i];
				numericUpDown.Value = BrickTexture.AccentCounts[i];

				// The button name is the same as it's index in the button array
				button.Name = i.ToString();
				numericUpDown.Name = i.ToString();

				// Set the location and size of the button and trackbar
				if (i < 5) {
					button.Location = new Point(50, 45 * i + 94);
					numericUpDown.Location = new Point(100, 45 * i + 100);
				}
				else {
					button.Location = new Point(350, 45 * (i - 5) + 94);
					numericUpDown.Location = new Point(400, 45 * (i - 5) + 100);
				}
				button.Size = new Size(30, 30);
				numericUpDown.Size = new Size(50, 25);

				// Add event handler to the button and trackbar
				button.Click += buttonHandler;
				
				// Add button to the form
				Controls.Add(button);
				Controls.Add(numericUpDown);

				// Add newly created button to button array and color dialog to it's array
				buttons[i] = button;
				colorDialogs[i] = colorDialog;
				numericUpDowns[i] = numericUpDown;
			}

			// Edit based on previous info that will be contained in bricktexture class
		}

		private void BrickAccentForm_Closing(object sender, EventArgs e) {
			for (int i = 0; i < 10; i++) {
				BrickTexture.AccentColors[i] = colorDialogs[i].Color;
				BrickTexture.AccentCounts[i] = (int)numericUpDowns[i].Value;
			}
		}

			// Event handler for clicking on the button to change the color
			private void ButtonClick(object sender, EventArgs e) {
				// Get the name of the button (string such as "2") and convert to int to use as index
				int index = int.Parse(((Button)sender).Name.ToString());

				// Show color dialog box
				colorDialogs[index].ShowDialog();

				// Set button color to the same as dialog box choice
				((Button)sender).BackColor = colorDialogs[index].Color;
			}
	}
}
