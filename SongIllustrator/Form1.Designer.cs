namespace SongIllustrator
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.frameListBox = new System.Windows.Forms.CheckedListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.pixelBar = new System.Windows.Forms.TrackBar();
			this.frameCheckbox = new System.Windows.Forms.CheckBox();
			this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.timeline1 = new SongIllustrator.Timeline();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toMIDIToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pickSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pLaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.launchpadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.controlEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.midiCheck = new System.Windows.Forms.Timer(this.components);
			this.frameLabel = new System.Windows.Forms.Label();
			this.shiftButton = new SongIllustrator.DisplayButton();
			this.imageButton = new SongIllustrator.DisplayButton();
			this.displayButton2 = new SongIllustrator.DisplayButton();
			this.fullscreenButton = new SongIllustrator.DisplayButton();
			this.button39 = new SongIllustrator.DisplayButton();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pixelBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(552, 479);
			this.panel1.TabIndex = 68;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// frameListBox
			// 
			this.frameListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.frameListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frameListBox.ContextMenuStrip = this.contextMenuStrip1;
			this.frameListBox.FormattingEnabled = true;
			this.frameListBox.Location = new System.Drawing.Point(560, 37);
			this.frameListBox.Name = "frameListBox";
			this.frameListBox.Size = new System.Drawing.Size(115, 435);
			this.frameListBox.TabIndex = 69;
			this.frameListBox.Click += new System.EventHandler(this.checkedListBox1_Click);
			this.frameListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
			this.frameListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkedListBox1_KeyDown);
			this.frameListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkedListBox1_KeyUp);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.exportSelectionToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(159, 92);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateButton_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// exportSelectionToolStripMenuItem
			// 
			this.exportSelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toMIDIToolStripMenuItem});
			this.exportSelectionToolStripMenuItem.Name = "exportSelectionToolStripMenuItem";
			this.exportSelectionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.exportSelectionToolStripMenuItem.Text = "Export Selection";
			// 
			// toMIDIToolStripMenuItem
			// 
			this.toMIDIToolStripMenuItem.Name = "toMIDIToolStripMenuItem";
			this.toMIDIToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.toMIDIToolStripMenuItem.Text = "To MIDI";
			this.toMIDIToolStripMenuItem.Click += new System.EventHandler(this.toMIDIToolStripMenuItem_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(560, 478);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(60, 20);
			this.textBox1.TabIndex = 71;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(560, 504);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(60, 20);
			this.textBox2.TabIndex = 76;
			this.textBox2.Text = "10";
			// 
			// pixelBar
			// 
			this.pixelBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pixelBar.LargeChange = 8;
			this.pixelBar.Location = new System.Drawing.Point(439, 4);
			this.pixelBar.Maximum = 32;
			this.pixelBar.Minimum = 8;
			this.pixelBar.Name = "pixelBar";
			this.pixelBar.Size = new System.Drawing.Size(112, 45);
			this.pixelBar.SmallChange = 8;
			this.pixelBar.TabIndex = 80;
			this.pixelBar.Value = 8;
			this.pixelBar.Visible = false;
			this.pixelBar.Scroll += new System.EventHandler(this.pixelBar_Scroll);
			this.pixelBar.ValueChanged += new System.EventHandler(this.pixelBar_ValueChanged);
			// 
			// frameCheckbox
			// 
			this.frameCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.frameCheckbox.AutoSize = true;
			this.frameCheckbox.ForeColor = System.Drawing.Color.White;
			this.frameCheckbox.Location = new System.Drawing.Point(335, 4);
			this.frameCheckbox.Name = "frameCheckbox";
			this.frameCheckbox.Size = new System.Drawing.Size(98, 17);
			this.frameCheckbox.TabIndex = 83;
			this.frameCheckbox.Text = "Repeat Frames";
			this.frameCheckbox.UseVisualStyleBackColor = true;
			this.frameCheckbox.Visible = false;
			// 
			// axWindowsMediaPlayer1
			// 
			this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.axWindowsMediaPlayer1.Enabled = true;
			this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(2, 614);
			this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
			this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
			this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(673, 45);
			this.axWindowsMediaPlayer1.TabIndex = 87;
			this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Location = new System.Drawing.Point(2, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.timeline1);
			this.splitContainer1.Size = new System.Drawing.Size(552, 586);
			this.splitContainer1.SplitterDistance = 479;
			this.splitContainer1.TabIndex = 88;
			// 
			// timeline1
			// 
			this.timeline1.AutoScroll = true;
			this.timeline1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timeline1.Location = new System.Drawing.Point(0, 0);
			this.timeline1.MinimumSize = new System.Drawing.Size(0, 75);
			this.timeline1.Name = "timeline1";
			this.timeline1.Size = new System.Drawing.Size(552, 103);
			this.timeline1.TabIndex = 85;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.pLaylistToolStripMenuItem,
            this.launchpadToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 89;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// fILEToolStripMenuItem
			// 
			this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem});
			this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
			this.fILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fILEToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem1
			// 
			this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			this.newToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
			this.newToolStripMenuItem1.Text = "&New";
			this.newToolStripMenuItem1.Click += new System.EventHandler(this.displayButton65_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openDisplayFileButton_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toMIDIToolStripMenuItem1});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// toMIDIToolStripMenuItem1
			// 
			this.toMIDIToolStripMenuItem1.Name = "toMIDIToolStripMenuItem1";
			this.toMIDIToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
			this.toMIDIToolStripMenuItem1.Text = "To MIDI";
			this.toMIDIToolStripMenuItem1.Click += new System.EventHandler(this.toMIDIToolStripMenuItem1_Click);
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
			this.pickSongToolStripMenuItem.Click += new System.EventHandler(this.songButton_Click);
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
			this.openPlaylistToolStripMenuItem.Click += new System.EventHandler(this.listButton_Click);
			// 
			// createPlaylistToolStripMenuItem
			// 
			this.createPlaylistToolStripMenuItem.Name = "createPlaylistToolStripMenuItem";
			this.createPlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.createPlaylistToolStripMenuItem.Text = "Create Playlist";
			this.createPlaylistToolStripMenuItem.Click += new System.EventHandler(this.createListButton_Click);
			// 
			// launchpadToolStripMenuItem
			// 
			this.launchpadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlEditorToolStripMenuItem});
			this.launchpadToolStripMenuItem.Name = "launchpadToolStripMenuItem";
			this.launchpadToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
			this.launchpadToolStripMenuItem.Text = "Launchpad";
			// 
			// controlEditorToolStripMenuItem
			// 
			this.controlEditorToolStripMenuItem.Name = "controlEditorToolStripMenuItem";
			this.controlEditorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.controlEditorToolStripMenuItem.Text = "Control Editor";
			this.controlEditorToolStripMenuItem.Click += new System.EventHandler(this.controlEditorToolStripMenuItem_Click);
			// 
			// midiCheck
			// 
			this.midiCheck.Interval = 1;
			this.midiCheck.Tick += new System.EventHandler(this.midiCheck_Tick);
			// 
			// frameLabel
			// 
			this.frameLabel.AutoSize = true;
			this.frameLabel.BackColor = System.Drawing.SystemColors.Control;
			this.frameLabel.Location = new System.Drawing.Point(557, 5);
			this.frameLabel.Name = "frameLabel";
			this.frameLabel.Size = new System.Drawing.Size(39, 13);
			this.frameLabel.TabIndex = 90;
			this.frameLabel.Text = "Frame:";
			// 
			// shiftButton
			// 
			this.shiftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.shiftButton.ArrayPos = 0;
			this.shiftButton.BackColor = System.Drawing.Color.Gray;
			this.shiftButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shiftButton.BackgroundImage")));
			this.shiftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.shiftButton.CanSendMessage = true;
			this.shiftButton.DisplayText = "Shift";
			this.shiftButton.LaunchpadEdit = false;
			this.shiftButton.Location = new System.Drawing.Point(623, 478);
			this.shiftButton.Name = "shiftButton";
			this.shiftButton.Port = null;
			this.shiftButton.ShiftDown = false;
			this.shiftButton.Size = new System.Drawing.Size(49, 20);
			this.shiftButton.TabIndex = 91;
			this.shiftButton.Click += new System.EventHandler(this.shiftButton_Click);
			// 
			// imageButton
			// 
			this.imageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.imageButton.ArrayPos = 0;
			this.imageButton.BackColor = System.Drawing.Color.Gray;
			this.imageButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imageButton.BackgroundImage")));
			this.imageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.imageButton.CanSendMessage = true;
			this.imageButton.DisplayText = "Overlay Image";
			this.imageButton.LaunchpadEdit = false;
			this.imageButton.Location = new System.Drawing.Point(560, 588);
			this.imageButton.Name = "imageButton";
			this.imageButton.Port = null;
			this.imageButton.ShiftDown = false;
			this.imageButton.Size = new System.Drawing.Size(112, 23);
			this.imageButton.TabIndex = 84;
			this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
			// 
			// displayButton2
			// 
			this.displayButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.displayButton2.ArrayPos = 0;
			this.displayButton2.BackColor = System.Drawing.Color.Gray;
			this.displayButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("displayButton2.BackgroundImage")));
			this.displayButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.displayButton2.CanSendMessage = true;
			this.displayButton2.DisplayText = "Sync";
			this.displayButton2.LaunchpadEdit = false;
			this.displayButton2.Location = new System.Drawing.Point(623, 504);
			this.displayButton2.Name = "displayButton2";
			this.displayButton2.Port = null;
			this.displayButton2.ShiftDown = false;
			this.displayButton2.Size = new System.Drawing.Size(49, 20);
			this.displayButton2.TabIndex = 82;
			this.displayButton2.Click += new System.EventHandler(this.displayButton2_Click);
			// 
			// fullscreenButton
			// 
			this.fullscreenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.fullscreenButton.ArrayPos = 0;
			this.fullscreenButton.BackColor = System.Drawing.Color.Gray;
			this.fullscreenButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fullscreenButton.BackgroundImage")));
			this.fullscreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.fullscreenButton.CanSendMessage = true;
			this.fullscreenButton.DisplayText = "Fullscreen";
			this.fullscreenButton.LaunchpadEdit = false;
			this.fullscreenButton.Location = new System.Drawing.Point(560, 559);
			this.fullscreenButton.Name = "fullscreenButton";
			this.fullscreenButton.Port = null;
			this.fullscreenButton.ShiftDown = false;
			this.fullscreenButton.Size = new System.Drawing.Size(112, 23);
			this.fullscreenButton.TabIndex = 79;
			this.fullscreenButton.Click += new System.EventHandler(this.displayButton66_Click);
			// 
			// button39
			// 
			this.button39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button39.ArrayPos = 0;
			this.button39.BackColor = System.Drawing.Color.Gray;
			this.button39.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button39.BackgroundImage")));
			this.button39.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button39.CanSendMessage = true;
			this.button39.DisplayText = "Add Frame";
			this.button39.LaunchpadEdit = false;
			this.button39.Location = new System.Drawing.Point(560, 530);
			this.button39.Name = "button39";
			this.button39.Port = null;
			this.button39.ShiftDown = false;
			this.button39.Size = new System.Drawing.Size(112, 23);
			this.button39.TabIndex = 39;
			this.button39.Load += new System.EventHandler(this.button39_Load);
			this.button39.Click += new System.EventHandler(this.button39_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(684, 662);
			this.Controls.Add(this.shiftButton);
			this.Controls.Add(this.frameLabel);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.axWindowsMediaPlayer1);
			this.Controls.Add(this.imageButton);
			this.Controls.Add(this.frameCheckbox);
			this.Controls.Add(this.displayButton2);
			this.Controls.Add(this.pixelBar);
			this.Controls.Add(this.fullscreenButton);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.frameListBox);
			this.Controls.Add(this.button39);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Song Illustrator";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pixelBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

				private DisplayButton button39;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox frameListBox;
				private System.Windows.Forms.TextBox textBox1;
				private System.Windows.Forms.TextBox textBox2;
        private DisplayButton fullscreenButton;
        private System.Windows.Forms.TrackBar pixelBar;
        private DisplayButton displayButton2;
        private System.Windows.Forms.CheckBox frameCheckbox;
        private DisplayButton imageButton;
        private Timeline timeline1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
				private System.Windows.Forms.SplitContainer splitContainer1;
				private System.Windows.Forms.MenuStrip menuStrip1;
				private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem pickSongToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
				private System.Windows.Forms.ToolStripMenuItem pLaylistToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem createPlaylistToolStripMenuItem;
				private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
				private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
				private System.Windows.Forms.Timer midiCheck;
				private System.Windows.Forms.Label frameLabel;
				private DisplayButton shiftButton;
				private System.Windows.Forms.ToolStripMenuItem exportSelectionToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem toMIDIToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem toMIDIToolStripMenuItem1;
				private System.Windows.Forms.ToolStripMenuItem launchpadToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem controlEditorToolStripMenuItem;
    }
}

