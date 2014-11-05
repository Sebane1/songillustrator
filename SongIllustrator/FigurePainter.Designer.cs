namespace SongIllustrator {
	partial class FigurePainter {
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
			this.components = new System.ComponentModel.Container();
			this.animation = new System.Windows.Forms.Timer(this.components);
			this.pauseTimer = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toMIDIToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pickSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pLaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.launchpadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.controlEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.addLaunchpadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeLaunchpadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fLPortSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.useWithFLStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howDoIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shiftFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// animation
			// 
			this.animation.Interval = 1;
			this.animation.Tick += new System.EventHandler(this.animation_Tick);
			// 
			// pauseTimer
			// 
			this.pauseTimer.Interval = 5000;
			this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.pLaylistToolStripMenuItem,
            this.launchpadToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
			this.menuStrip1.TabIndex = 90;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fILEToolStripMenuItem
			// 
			this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem});
			this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
			this.fILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fILEToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem1
			// 
			this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.newToolStripMenuItem1.Text = "&New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "&Open";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toMIDIToolStripMenuItem1});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// toMIDIToolStripMenuItem1
			// 
			this.toMIDIToolStripMenuItem1.Name = "toMIDIToolStripMenuItem1";
			this.toMIDIToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
			this.toMIDIToolStripMenuItem1.Text = "To MIDI";
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickSongToolStripMenuItem});
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.projectToolStripMenuItem.Text = "Project";
			// 
			// pickSongToolStripMenuItem
			// 
			this.pickSongToolStripMenuItem.Name = "pickSongToolStripMenuItem";
			this.pickSongToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.pickSongToolStripMenuItem.Text = "Pick Song";
			// 
			// pLaylistToolStripMenuItem
			// 
			this.pLaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPlaylistToolStripMenuItem,
            this.createPlaylistToolStripMenuItem});
			this.pLaylistToolStripMenuItem.Name = "pLaylistToolStripMenuItem";
			this.pLaylistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.pLaylistToolStripMenuItem.Text = "Playlist";
			// 
			// openPlaylistToolStripMenuItem
			// 
			this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
			this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.openPlaylistToolStripMenuItem.Text = "Open Playlist";
			// 
			// createPlaylistToolStripMenuItem
			// 
			this.createPlaylistToolStripMenuItem.Name = "createPlaylistToolStripMenuItem";
			this.createPlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.createPlaylistToolStripMenuItem.Text = "Create Playlist";
			// 
			// launchpadToolStripMenuItem
			// 
			this.launchpadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlEditorToolStripMenuItem,
            this.toolStripSeparator1,
            this.addLaunchpadToolStripMenuItem,
            this.removeLaunchpadToolStripMenuItem});
			this.launchpadToolStripMenuItem.Name = "launchpadToolStripMenuItem";
			this.launchpadToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
			this.launchpadToolStripMenuItem.Text = "Launchpad";
			this.launchpadToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.launchpadToolStripMenuItem_Paint);
			// 
			// controlEditorToolStripMenuItem
			// 
			this.controlEditorToolStripMenuItem.Name = "controlEditorToolStripMenuItem";
			this.controlEditorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.controlEditorToolStripMenuItem.Text = "Enable Passive Mode";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
			// 
			// addLaunchpadToolStripMenuItem
			// 
			this.addLaunchpadToolStripMenuItem.Name = "addLaunchpadToolStripMenuItem";
			this.addLaunchpadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.addLaunchpadToolStripMenuItem.Text = "Add Launchpad";
			// 
			// removeLaunchpadToolStripMenuItem
			// 
			this.removeLaunchpadToolStripMenuItem.Name = "removeLaunchpadToolStripMenuItem";
			this.removeLaunchpadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.removeLaunchpadToolStripMenuItem.Text = "Remove Launchpad";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fLPortSetupToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// fLPortSetupToolStripMenuItem
			// 
			this.fLPortSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useWithFLStudioToolStripMenuItem,
            this.howDoIToolStripMenuItem});
			this.fLPortSetupToolStripMenuItem.Name = "fLPortSetupToolStripMenuItem";
			this.fLPortSetupToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.fLPortSetupToolStripMenuItem.Text = "FAQ";
			// 
			// useWithFLStudioToolStripMenuItem
			// 
			this.useWithFLStudioToolStripMenuItem.Name = "useWithFLStudioToolStripMenuItem";
			this.useWithFLStudioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.useWithFLStudioToolStripMenuItem.Text = "Use With FL Studio";
			// 
			// howDoIToolStripMenuItem
			// 
			this.howDoIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAFrameToolStripMenuItem,
            this.changeSpeedToolStripMenuItem,
            this.shiftFramesToolStripMenuItem});
			this.howDoIToolStripMenuItem.Name = "howDoIToolStripMenuItem";
			this.howDoIToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.howDoIToolStripMenuItem.Text = "How do I...";
			// 
			// addAFrameToolStripMenuItem
			// 
			this.addAFrameToolStripMenuItem.Name = "addAFrameToolStripMenuItem";
			this.addAFrameToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.addAFrameToolStripMenuItem.Text = "Add a frame";
			// 
			// changeSpeedToolStripMenuItem
			// 
			this.changeSpeedToolStripMenuItem.Name = "changeSpeedToolStripMenuItem";
			this.changeSpeedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.changeSpeedToolStripMenuItem.Text = "Change speed";
			// 
			// shiftFramesToolStripMenuItem
			// 
			this.shiftFramesToolStripMenuItem.Name = "shiftFramesToolStripMenuItem";
			this.shiftFramesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.shiftFramesToolStripMenuItem.Text = "Shift frames";
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.descriptionLabel.Location = new System.Drawing.Point(12, 165);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.descriptionLabel.Size = new System.Drawing.Size(51, 20);
			this.descriptionLabel.TabIndex = 91;
			this.descriptionLabel.Text = "label1";
			this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.descriptionLabel.Click += new System.EventHandler(this.descriptionLabel_Click);
			// 
			// FigurePainter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.descriptionLabel);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FigurePainter";
			this.Text = "FigurePainter";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Load += new System.EventHandler(this.FigurePainter_Load);
			this.Shown += new System.EventHandler(this.FigurePainter_Shown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FigurePainter_Paint);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer animation;
		private System.Windows.Forms.Timer pauseTimer;
		private System.Windows.Forms.MenuStrip menuStrip1;
		public System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem toMIDIToolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem pickSongToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem pLaylistToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem createPlaylistToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem launchpadToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem controlEditorToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public System.Windows.Forms.ToolStripMenuItem addLaunchpadToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem removeLaunchpadToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem fLPortSetupToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem useWithFLStudioToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem howDoIToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem addAFrameToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem changeSpeedToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem shiftFramesToolStripMenuItem;
		private System.Windows.Forms.Label descriptionLabel;
	}
}