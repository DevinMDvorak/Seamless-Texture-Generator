using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			// Send the picture box references to the other scripts
			BrickTexture.SetPictureBoxes(GeneratedImage, GeneratedNormal);
			BrickHeightMap.SetPictureBoxes(GeneratedImage, GeneratedNormal);
			// Send image size to helper script
			Helper.SetImageSize((int)ImageHeightField.Value, (int)ImageHeightField.Value);
			// Call start function of bricktexture class
			BrickTexture.Start();

			// All of the panels should be hidden at the start
			BrickPanel.Visible = false;
		}

		// Send information to the BrickTexture class from the form
		// This also triggers the texture to be created
		public void SendBrickInfo(object sender, EventArgs e) {
			BrickTexture.Setup((int)BrickRowsField.Value, (int)BrickColumnsField.Value, (float)BrickCementRatio.Value * 0.01f,
				BrickColorDialog.Color, BrickCementColorDialog.Color);
		}

		// Whenever the image size is edited we must relay that info to our other scripts
		private void ImageHeightField_ValueChanged(object sender, EventArgs e) {
			GeneratedImage.Size = new Size((int)ImageHeightField.Value, (int)ImageHeightField.Value);
			GeneratedNormal.Size = new Size((int)ImageHeightField.Value, (int)ImageHeightField.Value);

			Helper.SetImageSize((int)ImageHeightField.Value, (int)ImageHeightField.Value);
			// Make sure the tab containing the image fits the image size
			// I'm not sure where the extra 8 is coming from but it has to be there and I will look more into it later
			ImageTab.Size = new Size((int)ImageHeightField.Value + 8, (int)ImageHeightField.Value + ImageTab.ItemSize.Height + 8);
		}

		// This section of code covers all buttons that are used in the brick panel
		//
		//

		// Bring up the color dialog box for the brick textures main color
		private void BrickMainColorButton_Click(object sender, EventArgs e) {
			BrickColorDialog.ShowDialog();
			BrickMainColorButton.BackColor = BrickColorDialog.Color;
		}

		// Bring up the color dialog box for the brick textures cement color
		private void BrickCementColorButton_Click(object sender, EventArgs e) {
			BrickCementColorDialog.ShowDialog();
			BrickCementColorButton.BackColor = BrickCementColorDialog.Color;
		}

		private void AccentBrickButton_Click(object sender, EventArgs e) {
			BrickAccentForm newForm = new BrickAccentForm();
			newForm.ShowDialog();
		}

		// This section of code covers everything on the menu bar
		//
		//

		// File drop down button
		// Export texture
		private void exportImageToolStripMenuItem_Click(object sender, EventArgs e) {
			// Create instance of save-file-dialog box which lets user select a location to save the image
			SaveFileDialog sfd = new SaveFileDialog();
			// Filter out the dialog box to only show jpg files
			sfd.Filter = "jpg(.jpg)|*.jpg";
			if (sfd.ShowDialog() == DialogResult.OK) {
				// Save the image using whatever name is specified in the dialog box
				GeneratedImage.Image.Save(sfd.FileName);
			}
		}

		// Export normal map
		private void exportNormalMapToolStripMenuItem_Click(object sender, EventArgs e) {
			// Create instance of save-file-dialog box which lets user select a location to save the image
			SaveFileDialog sfd = new SaveFileDialog();
			// Filter out the dialog box to only show jpg files
			sfd.Filter = "jpg|*.jpg";
			if (sfd.ShowDialog() == DialogResult.OK) {
				// Save the image using whatever name is specified in the dialog box
				GeneratedNormal.Image.Save(sfd.FileName);
			}
		}

		// Generate... drop down button
		// Brick
		private void brickToolStripMenuItem_Click(object sender, EventArgs e) {
			BrickPanel.Visible = true;
		}
	}
}
