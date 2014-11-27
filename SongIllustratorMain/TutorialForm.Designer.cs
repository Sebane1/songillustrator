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
		protected void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			//base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.richTextBox1 = _factory.BuildRichTextBox();
			this.desciptionTextBox = _factory.BuildRichTextBox();
			this.previousImageButton = _factory.BuildButton();
			this.nextImageButton = _factory.BuildButton();
			this.visualPictureBox = _factory.BuildPictureView();
			//this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.visualPictureBox)).BeginInit();
			//this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Enabled = false;
			this.richTextBox1.ControlLocation = new ControlLocation(376, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ControlSize = new ControlSize(206, 425);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// desciptionTextBox
			// 
			this.desciptionTextBox.Enabled = false;
			this.desciptionTextBox.ControlLocation = new ControlLocation(376, 12);
			this.desciptionTextBox.Name = "desciptionTextBox";
			this.desciptionTextBox.ControlSize = new ControlSize(206, 425);
			this.desciptionTextBox.TabIndex = 1;
			this.desciptionTextBox.Text = "";
			this.desciptionTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// previousImageButton
			// 
			this.previousImageButton.ControlLocation = new ControlLocation(12, 541);
			this.previousImageButton.Name = "previousImageButton";
			this.previousImageButton.ControlSize = new ControlSize(75, 23);
			this.previousImageButton.TabIndex = 2;
			this.previousImageButton.Text = "Previous";
			//this.previousImageButton.UseVisualStyleBackColor = true;
			this.previousImageButton.Click += new System.EventHandler(this.previousImageButton_Click);
			// 
			// nextImageButton
			// 
			this.nextImageButton.ControlLocation = new ControlLocation(707, 541);
			this.nextImageButton.Name = "nextImageButton";
			this.nextImageButton.ControlSize = new ControlSize(75, 23);
			this.nextImageButton.TabIndex = 3;
			this.nextImageButton.Text = "Next";
			//this.nextImageButton.UseVisualStyleBackColor = true;
			this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
			// 
			// visualPictureBox
			// 
			//this.visualPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.visualPictureBox.ControlLocation = new ControlLocation(12, 12);
			this.visualPictureBox.Name = "visualPictureBox";
			this.visualPictureBox.ControlSize = new ControlSize(558, 523);
			this.visualPictureBox.TabIndex = 0;
			this.visualPictureBox.TabStop = false;
			// 
			// TextBoxView1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.HideSelection = false;
			this.textBox1.ControlLocation = new ControlLocation(576, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ControlSize = new ControlSize(206, 523);
			this.textBox1.TabIndex = 4;
			// 
			// TutorialForm
			// 
			//this.AutoScaleDimensions = new ControlSize(6F, 13F);
			//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new ControlSize(794, 576);
			this.FormControls.Add(this.textBox1);
			this.FormControls.Add(this.nextImageButton);
			this.FormControls.Add(this.previousImageButton);
			this.FormControls.Add(this.visualPictureBox);
			this.Name = "TutorialForm";
			this.Text = "Song Illustrator";
			this.Load += new System.EventHandler(this.TutorialForm_Load);
			this.Shown += new System.EventHandler(this.TutorialForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.visualPictureBox)).EndInit();
			//this.ResumeLayout(false);
			//this.PerformLayout();

		}

		#endregion

		private IPictureView visualPictureBox;
		private IRichTextBoxView richTextBox1;
		private IRichTextBoxView desciptionTextBox;
		private IButtonView previousImageButton;
		private IButtonView nextImageButton;
		private ITextBoxView textBox1;
	}
}