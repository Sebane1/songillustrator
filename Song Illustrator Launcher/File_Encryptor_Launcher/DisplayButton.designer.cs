namespace SongIllustrator
{
    partial class DisplayButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayButton));
            this.mouseFollow = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mouseFollow
            // 
            this.mouseFollow.Interval = 1;
            this.mouseFollow.Tick += new System.EventHandler(this.mouseFollow_Tick);
            // 
            // DisplayButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Name = "DisplayButton";
            this.Size = new System.Drawing.Size(154, 149);
            this.Load += new System.EventHandler(this.DisplayButton_Load);
            this.Click += new System.EventHandler(this.DisplayButton_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayButton_Paint);
            this.DoubleClick += new System.EventHandler(this.DisplayButton_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayButton_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DisplayButton_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer mouseFollow;
    }
}
