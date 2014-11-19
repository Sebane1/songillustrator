namespace MediaPlayerModuleBase {
	partial class WavPlayerControl {
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
			this.components = new System.ComponentModel.Container();
			this.playButton = new System.Windows.Forms.Button();
			this.mediaPositioner = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// playButton
			// 
			this.playButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.playButton.Location = new System.Drawing.Point(0, 0);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(74, 68);
			this.playButton.TabIndex = 0;
			this.playButton.Text = ">";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// mediaPositioner
			// 
			this.mediaPositioner.Enabled = true;
			this.mediaPositioner.Tick += new System.EventHandler(this.mediaPositioner_Tick);
			// 
			// WavPlayerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.playButton);
			this.Name = "WavPlayerControl";
			this.Size = new System.Drawing.Size(586, 68);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Timer mediaPositioner;
	}
}
