namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.BrickPanel = new System.Windows.Forms.Panel();
			this.GenerateBrick = new System.Windows.Forms.Button();
			this.BrickCementRatio = new System.Windows.Forms.NumericUpDown();
			this.BrickCementRatioLabel = new System.Windows.Forms.Label();
			this.BrickColumnsField = new System.Windows.Forms.NumericUpDown();
			this.BrickColumnsLabel = new System.Windows.Forms.Label();
			this.BrickRowsField = new System.Windows.Forms.NumericUpDown();
			this.BrickRowsLabel = new System.Windows.Forms.Label();
			this.CementColorLabel = new System.Windows.Forms.Label();
			this.BrickMainColorLabel = new System.Windows.Forms.Label();
			this.BrickCementColorButton = new System.Windows.Forms.Button();
			this.BrickMainColorButton = new System.Windows.Forms.Button();
			this.ImageHeightField = new System.Windows.Forms.NumericUpDown();
			this.HeightLabel = new System.Windows.Forms.Label();
			this.BrickColorDialog = new System.Windows.Forms.ColorDialog();
			this.GeneratedImage = new System.Windows.Forms.PictureBox();
			this.BrickCementColorDialog = new System.Windows.Forms.ColorDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportNormalMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.brickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImageTab = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.GeneratedNormal = new System.Windows.Forms.PictureBox();
			this.AccentBrickButton = new System.Windows.Forms.Button();
			this.BrickPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BrickCementRatio)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BrickColumnsField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BrickRowsField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageHeightField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GeneratedImage)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.ImageTab.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GeneratedNormal)).BeginInit();
			this.SuspendLayout();
			// 
			// BrickPanel
			// 
			this.BrickPanel.Controls.Add(this.AccentBrickButton);
			this.BrickPanel.Controls.Add(this.GenerateBrick);
			this.BrickPanel.Controls.Add(this.BrickCementRatio);
			this.BrickPanel.Controls.Add(this.BrickCementRatioLabel);
			this.BrickPanel.Controls.Add(this.BrickColumnsField);
			this.BrickPanel.Controls.Add(this.BrickColumnsLabel);
			this.BrickPanel.Controls.Add(this.BrickRowsField);
			this.BrickPanel.Controls.Add(this.BrickRowsLabel);
			this.BrickPanel.Controls.Add(this.CementColorLabel);
			this.BrickPanel.Controls.Add(this.BrickMainColorLabel);
			this.BrickPanel.Controls.Add(this.BrickCementColorButton);
			this.BrickPanel.Controls.Add(this.BrickMainColorButton);
			this.BrickPanel.Location = new System.Drawing.Point(12, 106);
			this.BrickPanel.Name = "BrickPanel";
			this.BrickPanel.Size = new System.Drawing.Size(261, 354);
			this.BrickPanel.TabIndex = 2;
			// 
			// GenerateBrick
			// 
			this.GenerateBrick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GenerateBrick.Location = new System.Drawing.Point(74, 306);
			this.GenerateBrick.Name = "GenerateBrick";
			this.GenerateBrick.Size = new System.Drawing.Size(99, 25);
			this.GenerateBrick.TabIndex = 7;
			this.GenerateBrick.Text = "Generate!";
			this.GenerateBrick.UseVisualStyleBackColor = true;
			this.GenerateBrick.Click += new System.EventHandler(this.SendBrickInfo);
			// 
			// BrickCementRatio
			// 
			this.BrickCementRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickCementRatio.Location = new System.Drawing.Point(104, 64);
			this.BrickCementRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.BrickCementRatio.Name = "BrickCementRatio";
			this.BrickCementRatio.Size = new System.Drawing.Size(70, 23);
			this.BrickCementRatio.TabIndex = 6;
			this.BrickCementRatio.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BrickCementRatio.ValueChanged += new System.EventHandler(this.ImageHeightField_ValueChanged);
			// 
			// BrickCementRatioLabel
			// 
			this.BrickCementRatioLabel.AutoSize = true;
			this.BrickCementRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickCementRatioLabel.Location = new System.Drawing.Point(3, 67);
			this.BrickCementRatioLabel.Name = "BrickCementRatioLabel";
			this.BrickCementRatioLabel.Size = new System.Drawing.Size(97, 17);
			this.BrickCementRatioLabel.TabIndex = 5;
			this.BrickCementRatioLabel.Text = "Cement Ratio:";
			// 
			// BrickColumnsField
			// 
			this.BrickColumnsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickColumnsField.Location = new System.Drawing.Point(104, 35);
			this.BrickColumnsField.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.BrickColumnsField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.BrickColumnsField.Name = "BrickColumnsField";
			this.BrickColumnsField.Size = new System.Drawing.Size(70, 23);
			this.BrickColumnsField.TabIndex = 6;
			this.BrickColumnsField.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.BrickColumnsField.ValueChanged += new System.EventHandler(this.ImageHeightField_ValueChanged);
			// 
			// BrickColumnsLabel
			// 
			this.BrickColumnsLabel.AutoSize = true;
			this.BrickColumnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickColumnsLabel.Location = new System.Drawing.Point(3, 38);
			this.BrickColumnsLabel.Name = "BrickColumnsLabel";
			this.BrickColumnsLabel.Size = new System.Drawing.Size(101, 17);
			this.BrickColumnsLabel.TabIndex = 5;
			this.BrickColumnsLabel.Text = "Brick Columns:";
			// 
			// BrickRowsField
			// 
			this.BrickRowsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickRowsField.Location = new System.Drawing.Point(104, 6);
			this.BrickRowsField.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.BrickRowsField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.BrickRowsField.Name = "BrickRowsField";
			this.BrickRowsField.Size = new System.Drawing.Size(70, 23);
			this.BrickRowsField.TabIndex = 6;
			this.BrickRowsField.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
			this.BrickRowsField.ValueChanged += new System.EventHandler(this.ImageHeightField_ValueChanged);
			// 
			// BrickRowsLabel
			// 
			this.BrickRowsLabel.AutoSize = true;
			this.BrickRowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickRowsLabel.Location = new System.Drawing.Point(3, 9);
			this.BrickRowsLabel.Name = "BrickRowsLabel";
			this.BrickRowsLabel.Size = new System.Drawing.Size(81, 17);
			this.BrickRowsLabel.TabIndex = 5;
			this.BrickRowsLabel.Text = "Brick Rows:";
			// 
			// CementColorLabel
			// 
			this.CementColorLabel.AutoSize = true;
			this.CementColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CementColorLabel.Location = new System.Drawing.Point(2, 148);
			this.CementColorLabel.Name = "CementColorLabel";
			this.CementColorLabel.Size = new System.Drawing.Size(97, 17);
			this.CementColorLabel.TabIndex = 2;
			this.CementColorLabel.Text = "Cement Color:";
			// 
			// BrickMainColorLabel
			// 
			this.BrickMainColorLabel.AutoSize = true;
			this.BrickMainColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrickMainColorLabel.Location = new System.Drawing.Point(2, 112);
			this.BrickMainColorLabel.Name = "BrickMainColorLabel";
			this.BrickMainColorLabel.Size = new System.Drawing.Size(79, 17);
			this.BrickMainColorLabel.TabIndex = 2;
			this.BrickMainColorLabel.Text = "Main Color:";
			// 
			// BrickCementColorButton
			// 
			this.BrickCementColorButton.BackColor = System.Drawing.Color.DimGray;
			this.BrickCementColorButton.FlatAppearance.BorderSize = 0;
			this.BrickCementColorButton.Location = new System.Drawing.Point(104, 141);
			this.BrickCementColorButton.Name = "BrickCementColorButton";
			this.BrickCementColorButton.Size = new System.Drawing.Size(30, 30);
			this.BrickCementColorButton.TabIndex = 1;
			this.BrickCementColorButton.UseVisualStyleBackColor = false;
			this.BrickCementColorButton.Click += new System.EventHandler(this.BrickCementColorButton_Click);
			// 
			// BrickMainColorButton
			// 
			this.BrickMainColorButton.BackColor = System.Drawing.Color.Maroon;
			this.BrickMainColorButton.FlatAppearance.BorderSize = 0;
			this.BrickMainColorButton.Location = new System.Drawing.Point(104, 105);
			this.BrickMainColorButton.Name = "BrickMainColorButton";
			this.BrickMainColorButton.Size = new System.Drawing.Size(30, 30);
			this.BrickMainColorButton.TabIndex = 1;
			this.BrickMainColorButton.UseVisualStyleBackColor = false;
			this.BrickMainColorButton.Click += new System.EventHandler(this.BrickMainColorButton_Click);
			// 
			// ImageHeightField
			// 
			this.ImageHeightField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ImageHeightField.Location = new System.Drawing.Point(115, 67);
			this.ImageHeightField.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.ImageHeightField.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
			this.ImageHeightField.Name = "ImageHeightField";
			this.ImageHeightField.Size = new System.Drawing.Size(70, 23);
			this.ImageHeightField.TabIndex = 6;
			this.ImageHeightField.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
			this.ImageHeightField.ValueChanged += new System.EventHandler(this.ImageHeightField_ValueChanged);
			// 
			// HeightLabel
			// 
			this.HeightLabel.AutoSize = true;
			this.HeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeightLabel.Location = new System.Drawing.Point(14, 70);
			this.HeightLabel.Name = "HeightLabel";
			this.HeightLabel.Size = new System.Drawing.Size(95, 17);
			this.HeightLabel.TabIndex = 5;
			this.HeightLabel.Text = "Image Height:";
			// 
			// BrickColorDialog
			// 
			this.BrickColorDialog.Color = System.Drawing.Color.Maroon;
			// 
			// GeneratedImage
			// 
			this.GeneratedImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.GeneratedImage.Location = new System.Drawing.Point(0, 0);
			this.GeneratedImage.MaximumSize = new System.Drawing.Size(2048, 2048);
			this.GeneratedImage.Name = "GeneratedImage";
			this.GeneratedImage.Size = new System.Drawing.Size(512, 512);
			this.GeneratedImage.TabIndex = 3;
			this.GeneratedImage.TabStop = false;
			// 
			// BrickCementColorDialog
			// 
			this.BrickCementColorDialog.Color = System.Drawing.Color.DimGray;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generateToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(922, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportImageToolStripMenuItem,
            this.exportNormalMapToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exportImageToolStripMenuItem
			// 
			this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
			this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.exportImageToolStripMenuItem.Text = "Export Texture";
			this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.exportImageToolStripMenuItem_Click);
			// 
			// exportNormalMapToolStripMenuItem
			// 
			this.exportNormalMapToolStripMenuItem.Name = "exportNormalMapToolStripMenuItem";
			this.exportNormalMapToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.exportNormalMapToolStripMenuItem.Text = "Export Normal Map";
			this.exportNormalMapToolStripMenuItem.Click += new System.EventHandler(this.exportNormalMapToolStripMenuItem_Click);
			// 
			// generateToolStripMenuItem
			// 
			this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brickToolStripMenuItem});
			this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
			this.generateToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.generateToolStripMenuItem.Text = "Generate...";
			// 
			// brickToolStripMenuItem
			// 
			this.brickToolStripMenuItem.Name = "brickToolStripMenuItem";
			this.brickToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.brickToolStripMenuItem.Text = "Brick";
			this.brickToolStripMenuItem.Click += new System.EventHandler(this.brickToolStripMenuItem_Click);
			// 
			// ImageTab
			// 
			this.ImageTab.Controls.Add(this.tabPage1);
			this.ImageTab.Controls.Add(this.tabPage2);
			this.ImageTab.Location = new System.Drawing.Point(316, 48);
			this.ImageTab.Name = "ImageTab";
			this.ImageTab.SelectedIndex = 0;
			this.ImageTab.Size = new System.Drawing.Size(520, 538);
			this.ImageTab.TabIndex = 5;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.GeneratedImage);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(512, 512);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Texture";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.GeneratedNormal);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(512, 512);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Height Map";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// GeneratedNormal
			// 
			this.GeneratedNormal.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.GeneratedNormal.Location = new System.Drawing.Point(0, 0);
			this.GeneratedNormal.MaximumSize = new System.Drawing.Size(2048, 2048);
			this.GeneratedNormal.Name = "GeneratedNormal";
			this.GeneratedNormal.Size = new System.Drawing.Size(512, 512);
			this.GeneratedNormal.TabIndex = 4;
			this.GeneratedNormal.TabStop = false;
			// 
			// AccentBrickButton
			// 
			this.AccentBrickButton.Location = new System.Drawing.Point(6, 200);
			this.AccentBrickButton.Name = "AccentBrickButton";
			this.AccentBrickButton.Size = new System.Drawing.Size(128, 23);
			this.AccentBrickButton.TabIndex = 8;
			this.AccentBrickButton.Text = "Edit Accent Bricks";
			this.AccentBrickButton.UseVisualStyleBackColor = true;
			this.AccentBrickButton.Click += new System.EventHandler(this.AccentBrickButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(922, 590);
			this.Controls.Add(this.ImageTab);
			this.Controls.Add(this.BrickPanel);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.HeightLabel);
			this.Controls.Add(this.ImageHeightField);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Seamless Texture Generator";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.BrickPanel.ResumeLayout(false);
			this.BrickPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BrickCementRatio)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BrickColumnsField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BrickRowsField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageHeightField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GeneratedImage)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ImageTab.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GeneratedNormal)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.Panel BrickPanel;
		private System.Windows.Forms.Button BrickMainColorButton;
		private System.Windows.Forms.ColorDialog BrickColorDialog;
		private System.Windows.Forms.Label BrickMainColorLabel;
		private System.Windows.Forms.PictureBox GeneratedImage;
		private System.Windows.Forms.Label HeightLabel;
		private System.Windows.Forms.NumericUpDown ImageHeightField;
		private System.Windows.Forms.Button GenerateBrick;
		private System.Windows.Forms.NumericUpDown BrickRowsField;
		private System.Windows.Forms.Label BrickRowsLabel;
		private System.Windows.Forms.NumericUpDown BrickColumnsField;
		private System.Windows.Forms.Label BrickColumnsLabel;
		private System.Windows.Forms.NumericUpDown BrickCementRatio;
		private System.Windows.Forms.Label BrickCementRatioLabel;
		private System.Windows.Forms.Label CementColorLabel;
		private System.Windows.Forms.Button BrickCementColorButton;
		private System.Windows.Forms.ColorDialog BrickCementColorDialog;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem brickToolStripMenuItem;
		private System.Windows.Forms.TabControl ImageTab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.PictureBox GeneratedNormal;
		private System.Windows.Forms.ToolStripMenuItem exportNormalMapToolStripMenuItem;
		private System.Windows.Forms.Button AccentBrickButton;
	}
}

