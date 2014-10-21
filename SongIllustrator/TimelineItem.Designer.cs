namespace SongIllustrator {
	partial class TimelineItem {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.imageIdentifier = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imageIdentifier)).BeginInit();
			this.SuspendLayout();
			// 
			// imageIdentifier
			// 
			this.imageIdentifier.BackColor = System.Drawing.Color.Red;
			this.imageIdentifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.imageIdentifier.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageIdentifier.Location = new System.Drawing.Point(0, 0);
			this.imageIdentifier.Name = "imageIdentifier";
			this.imageIdentifier.Size = new System.Drawing.Size(153, 116);
			this.imageIdentifier.TabIndex = 0;
			this.imageIdentifier.TabStop = false;
			this.imageIdentifier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimelineItem_MouseDown);
			this.imageIdentifier.MouseHover += new System.EventHandler(this.TimelineItem_MouseHover);
			this.imageIdentifier.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimelineItem_MouseMove);
			this.imageIdentifier.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimelineItem_MouseUp);
			// 
			// TimelineItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.Controls.Add(this.imageIdentifier);
			this.Name = "TimelineItem";
			this.Size = new System.Drawing.Size(153, 116);
			this.Load += new System.EventHandler(this.TimelineItem_Load);
			this.Click += new System.EventHandler(this.TimelineItem_Click);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimelineItem_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimelineItem_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimelineItem_MouseDown);
			this.MouseHover += new System.EventHandler(this.TimelineItem_MouseHover);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimelineItem_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimelineItem_MouseUp);
			this.Resize += new System.EventHandler(this.TimelineItem_Resize);
			((System.ComponentModel.ISupportInitialize)(this.imageIdentifier)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imageIdentifier;
	}
}
