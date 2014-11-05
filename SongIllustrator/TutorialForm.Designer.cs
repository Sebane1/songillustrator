namespace SongIllustrator {
	partial class TutorialForm {
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.desciptionTextBox = new System.Windows.Forms.RichTextBox();
			this.previousImageButton = new System.Windows.Forms.Button();
			this.nextImageButton = new System.Windows.Forms.Button();
			this.visualPictureBox = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.visualPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.Black;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Enabled = false;
			this.richTextBox1.Location = new System.Drawing.Point(376, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(206, 425);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// desciptionTextBox
			// 
			this.desciptionTextBox.BackColor = System.Drawing.Color.Black;
			this.desciptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.desciptionTextBox.Enabled = false;
			this.desciptionTextBox.Location = new System.Drawing.Point(376, 12);
			this.desciptionTextBox.Name = "desciptionTextBox";
			this.desciptionTextBox.Size = new System.Drawing.Size(206, 425);
			this.desciptionTextBox.TabIndex = 1;
			this.desciptionTextBox.Text = "";
			this.desciptionTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// previousImageButton
			// 
			this.previousImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.previousImageButton.ForeColor = System.Drawing.Color.White;
			this.previousImageButton.Location = new System.Drawing.Point(12, 541);
			this.previousImageButton.Name = "previousImageButton";
			this.previousImageButton.Size = new System.Drawing.Size(75, 23);
			this.previousImageButton.TabIndex = 2;
			this.previousImageButton.Text = "Previous";
			this.previousImageButton.UseVisualStyleBackColor = true;
			this.previousImageButton.Click += new System.EventHandler(this.previousImageButton_Click);
			// 
			// nextImageButton
			// 
			this.nextImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nextImageButton.ForeColor = System.Drawing.Color.White;
			this.nextImageButton.Location = new System.Drawing.Point(707, 541);
			this.nextImageButton.Name = "nextImageButton";
			this.nextImageButton.Size = new System.Drawing.Size(75, 23);
			this.nextImageButton.TabIndex = 3;
			this.nextImageButton.Text = "Next";
			this.nextImageButton.UseVisualStyleBackColor = true;
			this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
			// 
			// visualPictureBox
			// 
			this.visualPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.visualPictureBox.Location = new System.Drawing.Point(12, 12);
			this.visualPictureBox.Name = "visualPictureBox";
			this.visualPictureBox.Size = new System.Drawing.Size(558, 523);
			this.visualPictureBox.TabIndex = 0;
			this.visualPictureBox.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.Black;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Enabled = false;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.ForeColor = System.Drawing.Color.White;
			this.textBox1.HideSelection = false;
			this.textBox1.Location = new System.Drawing.Point(576, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(206, 523);
			this.textBox1.TabIndex = 4;
			// 
			// TutorialForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(794, 576);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.nextImageButton);
			this.Controls.Add(this.previousImageButton);
			this.Controls.Add(this.visualPictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "TutorialForm";
			this.Text = "Song Illustrator";
			this.Load += new System.EventHandler(this.TutorialForm_Load);
			this.Shown += new System.EventHandler(this.TutorialForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.visualPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox visualPictureBox;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.RichTextBox desciptionTextBox;
		private System.Windows.Forms.Button previousImageButton;
		private System.Windows.Forms.Button nextImageButton;
		private System.Windows.Forms.TextBox textBox1;
	}
}