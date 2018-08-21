namespace WindowsFormsApp1 {
	partial class BrickAccentForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.NumberOfAccents = new System.Windows.Forms.NumericUpDown();
			this.NumberAccentsText = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.NumberOfAccents)).BeginInit();
			this.SuspendLayout();
			// 
			// NumberOfAccents
			// 
			this.NumberOfAccents.BackColor = System.Drawing.SystemColors.Window;
			this.NumberOfAccents.Cursor = System.Windows.Forms.Cursors.Default;
			this.NumberOfAccents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumberOfAccents.Location = new System.Drawing.Point(194, 23);
			this.NumberOfAccents.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NumberOfAccents.Name = "NumberOfAccents";
			this.NumberOfAccents.Size = new System.Drawing.Size(50, 23);
			this.NumberOfAccents.TabIndex = 8;
			// 
			// NumberAccentsText
			// 
			this.NumberAccentsText.AutoSize = true;
			this.NumberAccentsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumberAccentsText.Location = new System.Drawing.Point(12, 23);
			this.NumberAccentsText.Name = "NumberAccentsText";
			this.NumberAccentsText.Size = new System.Drawing.Size(165, 17);
			this.NumberAccentsText.TabIndex = 7;
			this.NumberAccentsText.Text = "Number of Accent Colors";
			// 
			// BrickAccentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.NumberOfAccents);
			this.Controls.Add(this.NumberAccentsText);
			this.Name = "BrickAccentForm";
			this.Text = "Accent Brick Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrickAccentForm_Closing);
			this.Load += new System.EventHandler(this.BrickAccentForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.NumberOfAccents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown NumberOfAccents;
		private System.Windows.Forms.Label NumberAccentsText;
	}
}