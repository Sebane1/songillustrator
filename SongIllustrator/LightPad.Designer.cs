namespace SongIllustrator {
	partial class LightPad {
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
			this.lightCanvas = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// lightCanvas
			// 
			this.lightCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lightCanvas.Location = new System.Drawing.Point(0, 0);
			this.lightCanvas.Name = "lightCanvas";
			this.lightCanvas.Size = new System.Drawing.Size(566, 462);
			this.lightCanvas.TabIndex = 0;
			// 
			// LightPad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lightCanvas);
			this.Name = "LightPad";
			this.Size = new System.Drawing.Size(566, 462);
			this.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel lightCanvas;
	}
}
