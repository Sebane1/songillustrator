using MediaPlayerModuleBase;
using System.Windows.Forms;
namespace SongIllustrator {
	partial class Form1 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reverseDuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pixelBar = new System.Windows.Forms.TrackBar();
			this.frameCheckbox = new System.Windows.Forms.CheckBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toMIDIToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editCurrentFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopEditingCurrentFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.useWithAbletonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howDoIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shiftFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.midiCheck = new System.Windows.Forms.Timer(this.components);
			this.frameLabel = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.frameListBox = new System.Windows.Forms.CheckedListBox();
			this.shiftButton = new SongIllustrator.DisplayButton();
			this.addFrameButton = new SongIllustrator.DisplayButton();
			this.timeline1 = new SongIllustrator.Timeline();
			this.fullscreenButton = new SongIllustrator.DisplayButton();
			this.imageButton = new SongIllustrator.DisplayButton();
			this.syncButton = new SongIllustrator.DisplayButton();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.pixelBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
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
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(552, 479);
			this.panel1.TabIndex = 68;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.reverseDuplicateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.exportSelectionToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(168, 114);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateButton_Click);
			// 
			// reverseDuplicateToolStripMenuItem
			// 
			this.reverseDuplicateToolStripMenuItem.Name = "reverseDuplicateToolStripMenuItem";
			this.reverseDuplicateToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.reverseDuplicateToolStripMenuItem.Text = "Reverse Duplicate";
			this.reverseDuplicateToolStripMenuItem.Click += new System.EventHandler(this.reverseDuplicateToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// exportSelectionToolStripMenuItem
			// 
			this.exportSelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toMIDIToolStripMenuItem});
			this.exportSelectionToolStripMenuItem.Name = "exportSelectionToolStripMenuItem";
			this.exportSelectionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.exportSelectionToolStripMenuItem.Text = "Export Selection";
			// 
			// toMIDIToolStripMenuItem
			// 
			this.toMIDIToolStripMenuItem.Name = "toMIDIToolStripMenuItem";
			this.toMIDIToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.toMIDIToolStripMenuItem.Text = "To MIDI";
			this.toMIDIToolStripMenuItem.Click += new System.EventHandler(this.toMIDIToolStripMenuItem_Click);
			// 
			// pixelBar
			// 
			this.pixelBar.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
			// 
			// frameCheckbox
			// 
			this.frameCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
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
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.pLaylistToolStripMenuItem,
            this.launchpadToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 89;
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
			this.newToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
			this.newToolStripMenuItem1.Text = "&New";
			this.newToolStripMenuItem1.Click += new System.EventHandler(this.new_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openDisplayFileButton_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toMIDIToolStripMenuItem1});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// toMIDIToolStripMenuItem1
			// 
			this.toMIDIToolStripMenuItem1.Name = "toMIDIToolStripMenuItem1";
			this.toMIDIToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
			this.toMIDIToolStripMenuItem1.Text = "To MIDI";
			this.toMIDIToolStripMenuItem1.Click += new System.EventHandler(this.toMIDIToolStripMenuItem1_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCurrentFrameToolStripMenuItem,
            this.stopEditingCurrentFrameToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// editCurrentFrameToolStripMenuItem
			// 
			this.editCurrentFrameToolStripMenuItem.Name = "editCurrentFrameToolStripMenuItem";
			this.editCurrentFrameToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
			this.editCurrentFrameToolStripMenuItem.Text = "Edit Current Frame";
			this.editCurrentFrameToolStripMenuItem.Click += new System.EventHandler(this.editCurrentFrameToolStripMenuItem_Click);
			// 
			// stopEditingCurrentFrameToolStripMenuItem
			// 
			this.stopEditingCurrentFrameToolStripMenuItem.Enabled = false;
			this.stopEditingCurrentFrameToolStripMenuItem.Name = "stopEditingCurrentFrameToolStripMenuItem";
			this.stopEditingCurrentFrameToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
			this.stopEditingCurrentFrameToolStripMenuItem.Text = "Stop Editing Current Frame";
			this.stopEditingCurrentFrameToolStripMenuItem.Click += new System.EventHandler(this.stopEditingCurrentFrameToolStripMenuItem_Click);
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
            this.controlEditorToolStripMenuItem,
            this.toolStripSeparator1,
            this.addLaunchpadToolStripMenuItem,
            this.removeLaunchpadToolStripMenuItem});
			this.launchpadToolStripMenuItem.Name = "launchpadToolStripMenuItem";
			this.launchpadToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
			this.launchpadToolStripMenuItem.Text = "Launchpad";
			this.launchpadToolStripMenuItem.Click += new System.EventHandler(this.launchpadToolStripMenuItem_Click);
			// 
			// controlEditorToolStripMenuItem
			// 
			this.controlEditorToolStripMenuItem.Enabled = false;
			this.controlEditorToolStripMenuItem.Name = "controlEditorToolStripMenuItem";
			this.controlEditorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.controlEditorToolStripMenuItem.Text = "Enable Passive Mode";
			this.controlEditorToolStripMenuItem.Click += new System.EventHandler(this.controlEditorToolStripMenuItem_Click);
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
			this.addLaunchpadToolStripMenuItem.Click += new System.EventHandler(this.addLaunchpadToolStripMenuItem_Click);
			// 
			// removeLaunchpadToolStripMenuItem
			// 
			this.removeLaunchpadToolStripMenuItem.Name = "removeLaunchpadToolStripMenuItem";
			this.removeLaunchpadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.removeLaunchpadToolStripMenuItem.Text = "Remove Launchpad";
			this.removeLaunchpadToolStripMenuItem.Click += new System.EventHandler(this.removeLaunchpadToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fLPortSetupToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// fLPortSetupToolStripMenuItem
			// 
			this.fLPortSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useWithFLStudioToolStripMenuItem,
            this.useWithAbletonToolStripMenuItem,
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
			this.useWithFLStudioToolStripMenuItem.Click += new System.EventHandler(this.useWithFLStudioToolStripMenuItem_Click);
			// 
			// useWithAbletonToolStripMenuItem
			// 
			this.useWithAbletonToolStripMenuItem.Name = "useWithAbletonToolStripMenuItem";
			this.useWithAbletonToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.useWithAbletonToolStripMenuItem.Text = "Use With Ableton";
			this.useWithAbletonToolStripMenuItem.Click += new System.EventHandler(this.useWithAbletonToolStripMenuItem_Click);
			// 
			// howDoIToolStripMenuItem
			// 
			this.howDoIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAFrameToolStripMenuItem,
            this.changeSpeedToolStripMenuItem,
            this.shiftFramesToolStripMenuItem,
            this.deleteFramesToolStripMenuItem});
			this.howDoIToolStripMenuItem.Name = "howDoIToolStripMenuItem";
			this.howDoIToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.howDoIToolStripMenuItem.Text = "How do I...";
			this.howDoIToolStripMenuItem.Click += new System.EventHandler(this.howDoIToolStripMenuItem_Click);
			// 
			// addAFrameToolStripMenuItem
			// 
			this.addAFrameToolStripMenuItem.Name = "addAFrameToolStripMenuItem";
			this.addAFrameToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.addAFrameToolStripMenuItem.Text = "Add a frame";
			this.addAFrameToolStripMenuItem.Click += new System.EventHandler(this.addAFrameToolStripMenuItem_Click);
			// 
			// changeSpeedToolStripMenuItem
			// 
			this.changeSpeedToolStripMenuItem.Name = "changeSpeedToolStripMenuItem";
			this.changeSpeedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.changeSpeedToolStripMenuItem.Text = "Change speed";
			this.changeSpeedToolStripMenuItem.Click += new System.EventHandler(this.changeSpeedToolStripMenuItem_Click);
			// 
			// shiftFramesToolStripMenuItem
			// 
			this.shiftFramesToolStripMenuItem.Name = "shiftFramesToolStripMenuItem";
			this.shiftFramesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.shiftFramesToolStripMenuItem.Text = "Shift frames";
			this.shiftFramesToolStripMenuItem.Click += new System.EventHandler(this.shiftFramesToolStripMenuItem_Click);
			// 
			// deleteFramesToolStripMenuItem
			// 
			this.deleteFramesToolStripMenuItem.Name = "deleteFramesToolStripMenuItem";
			this.deleteFramesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.deleteFramesToolStripMenuItem.Text = "Delete frames";
			this.deleteFramesToolStripMenuItem.Click += new System.EventHandler(this.deleteFramesToolStripMenuItem_Click);
			// 
			// midiCheck
			// 
			this.midiCheck.Interval = 1;
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
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(560, 494);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(60, 20);
			this.textBox2.TabIndex = 76;
			this.textBox2.Text = "10";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(560, 468);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(60, 20);
			this.textBox1.TabIndex = 71;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// frameListBox
			// 
			this.frameListBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.frameListBox.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
			this.frameListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frameListBox.ContextMenuStrip = this.contextMenuStrip1;
			this.frameListBox.FormattingEnabled = true;
			this.frameListBox.Location = new System.Drawing.Point(560, 27);
			this.frameListBox.Name = "frameListBox";
			this.frameListBox.Size = new System.Drawing.Size(115, 435);
			this.frameListBox.TabIndex = 69;
			this.frameListBox.Click += new System.EventHandler(this.checkedListBox1_Click);
			this.frameListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
			this.frameListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkedListBox1_KeyDown);
			this.frameListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkedListBox1_KeyUp);
			// 
			// shiftButton
			// 
			this.shiftButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.shiftButton.ArrayPos = 0;
			this.shiftButton.BackColor = System.Drawing.Color.Gray;
			this.shiftButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("shiftButton.BackgroundImage")));
			this.shiftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.shiftButton.CanSendMessage = true;
			this.shiftButton.DisplayText = "Shift";
			this.shiftButton.LaunchpadEdit = false;
			this.shiftButton.Location = new System.Drawing.Point(623, 468);
			this.shiftButton.Name = "shiftButton";
			this.shiftButton.Port = null;
			this.shiftButton.ShiftDown = false;
			this.shiftButton.Size = new System.Drawing.Size(49, 20);
			this.shiftButton.TabIndex = 91;
			this.shiftButton.Click += new System.EventHandler(this.shiftButton_Click);
			// 
			// addFrameButton
			// 
			this.addFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addFrameButton.ArrayPos = 0;
			this.addFrameButton.BackColor = System.Drawing.Color.Gray;
			this.addFrameButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("addFrameButton.BackgroundImage")));
			this.addFrameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.addFrameButton.CanSendMessage = true;
			this.addFrameButton.DisplayText = "Add Frame";
			this.addFrameButton.LaunchpadEdit = false;
			this.addFrameButton.Location = new System.Drawing.Point(560, 520);
			this.addFrameButton.Name = "addFrameButton";
			this.addFrameButton.Port = null;
			this.addFrameButton.ShiftDown = false;
			this.addFrameButton.Size = new System.Drawing.Size(112, 23);
			this.addFrameButton.TabIndex = 39;
			this.addFrameButton.Load += new System.EventHandler(this.button39_Load);
			this.addFrameButton.Click += new System.EventHandler(this.button39_Click);
			// 
			// timeline1
			// 
			this.timeline1.AutoScroll = true;
			this.timeline1.BackColor = System.Drawing.Color.Black;
			this.timeline1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timeline1.Location = new System.Drawing.Point(0, 0);
			this.timeline1.MinimumSize = new System.Drawing.Size(0, 75);
			this.timeline1.Name = "timeline1";
			this.timeline1.Size = new System.Drawing.Size(552, 103);
			this.timeline1.TabIndex = 85;
			// 
			// fullscreenButton
			// 
			this.fullscreenButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.fullscreenButton.ArrayPos = 0;
			this.fullscreenButton.BackColor = System.Drawing.Color.Gray;
			this.fullscreenButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("fullscreenButton.BackgroundImage")));
			this.fullscreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.fullscreenButton.CanSendMessage = true;
			this.fullscreenButton.DisplayText = "Fullscreen";
			this.fullscreenButton.LaunchpadEdit = false;
			this.fullscreenButton.Location = new System.Drawing.Point(560, 549);
			this.fullscreenButton.Name = "fullscreenButton";
			this.fullscreenButton.Port = null;
			this.fullscreenButton.ShiftDown = false;
			this.fullscreenButton.Size = new System.Drawing.Size(112, 23);
			this.fullscreenButton.TabIndex = 79;
			this.fullscreenButton.Click += new System.EventHandler(this.displayButton66_Click);
			// 
			// imageButton
			// 
			this.imageButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.imageButton.ArrayPos = 0;
			this.imageButton.BackColor = System.Drawing.Color.Gray;
			this.imageButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("imageButton.BackgroundImage")));
			this.imageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.imageButton.CanSendMessage = true;
			this.imageButton.DisplayText = "Overlay Image";
			this.imageButton.LaunchpadEdit = false;
			this.imageButton.Location = new System.Drawing.Point(560, 578);
			this.imageButton.Name = "imageButton";
			this.imageButton.Port = null;
			this.imageButton.ShiftDown = false;
			this.imageButton.Size = new System.Drawing.Size(112, 23);
			this.imageButton.TabIndex = 84;
			this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
			// 
			// syncButton
			// 
			this.syncButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.syncButton.ArrayPos = 0;
			this.syncButton.BackColor = System.Drawing.Color.Gray;
			this.syncButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("syncButton.BackgroundImage")));
			this.syncButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.syncButton.CanSendMessage = true;
			this.syncButton.DisplayText = "Sync";
			this.syncButton.LaunchpadEdit = false;
			this.syncButton.Location = new System.Drawing.Point(623, 494);
			this.syncButton.Name = "syncButton";
			this.syncButton.Port = null;
			this.syncButton.ShiftDown = false;
			this.syncButton.Size = new System.Drawing.Size(49, 20);
			this.syncButton.TabIndex = 82;
			this.syncButton.Click += new System.EventHandler(this.displayButton2_Click);

			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(684, 662);
			this.Controls.Add(this.frameListBox);
			this.Controls.Add(this.shiftButton);
			this.Controls.Add(this.addFrameButton);
			this.Controls.Add(this.frameLabel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.fullscreenButton);
			this.Controls.Add(this.frameCheckbox);
			this.Controls.Add(this.imageButton);
			this.Controls.Add(this.pixelBar);
			this.Controls.Add(this.syncButton);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Song Illustrator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.pixelBar)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TrackBar pixelBar;
		private System.Windows.Forms.CheckBox frameCheckbox;
		private Timeline timeline1;
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
		private System.Windows.Forms.ToolStripMenuItem exportSelectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toMIDIToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toMIDIToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem launchpadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem controlEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem addLaunchpadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeLaunchpadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fLPortSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem useWithFLStudioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem howDoIToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAFrameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeSpeedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shiftFramesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteFramesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem useWithAbletonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reverseDuplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editCurrentFrameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopEditingCurrentFrameToolStripMenuItem;
		private DisplayButton imageButton;
		private DisplayButton syncButton;
		private DisplayButton fullscreenButton;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private DisplayButton addFrameButton;
		private DisplayButton shiftButton;
		private System.Windows.Forms.CheckedListBox frameListBox;
	}
}

