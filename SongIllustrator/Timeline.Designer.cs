namespace SongIllustrator
{
    partial class Timeline
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.MinimumSize = new System.Drawing.Size(30, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(811, 69);
			this.panel1.TabIndex = 0;
			// 
			// Timeline
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(0, 75);
			this.Name = "Timeline";
			this.Size = new System.Drawing.Size(817, 75);
			this.Load += new System.EventHandler(this.Timeline_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
				private System.Windows.Forms.Panel panel1;
    }
}
