using MediaPlayerModuleBase;
using System;
namespace SongIllustrator {
	partial class MainForm {
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
			//this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			//this.timer1 = new Timer(this.components);
			this.panel1 = _factory.BuildPanel();
			this.contextMenuStrip1 = _factory.BuildContextMenu();
			this.refreshMenuItem = _factory.BuildContextMenuItem();
			this.duplicateMenuItem = _factory.BuildContextMenuItem();
			this.reverseDuplicateMenuItem = _factory.BuildContextMenuItem();
			this.deleteMenuItem = _factory.BuildContextMenuItem();
			this.exportSelectionMenuItem = _factory.BuildContextMenuItem();
			this.toMIDIMenuItem = _factory.BuildMenuItem();
			this.pixelBar = _factory.BuildTrackBar();
			//this.frameCheckbox = _factory.BuildListView();
			//this.splitContainer1 = _factory.BuildSplitContainerView();
			this.menuStrip1 = _factory.BuildToolStripMenu();
			this.fILEMenuItem = _factory.BuildMenuItem();
			this.newMenuItem1 = _factory.BuildMenuItem();
			this.openMenuItem = _factory.BuildMenuItem();
			this.saveMenuItem = _factory.BuildMenuItem();
			this.saveAsMenuItem = _factory.BuildMenuItem();
			this.exportMenuItem = _factory.BuildMenuItem();
			this.toMIDIMenuItem1 = _factory.BuildMenuItem();
			this.editMenuItem = _factory.BuildMenuItem();
			this.editCurrentFrameMenuItem = _factory.BuildMenuItem();
			this.stopEditingCurrentFrameMenuItem = _factory.BuildMenuItem();
			this.projectMenuItem = _factory.BuildMenuItem();
			this.pickSongMenuItem = _factory.BuildMenuItem();
			this.pLaylistMenuItem = _factory.BuildMenuItem();
			this.openPlaylistMenuItem = _factory.BuildMenuItem();
			this.createPlaylistMenuItem = _factory.BuildMenuItem();
			this.launchpadMenuItem = _factory.BuildMenuItem();
			this.FormControlEditorMenuItem = _factory.BuildMenuItem();
			this.MenuItemSeperator1 = _factory.BuildMenuItemSeperator();
			this.addLaunchpadMenuItem = _factory.BuildMenuItem();
			this.removeLaunchpadMenuItem = _factory.BuildMenuItem();
			this.helpMenuItem = _factory.BuildMenuItem();
			this.fLPortSetupMenuItem = _factory.BuildMenuItem();
			this.useWithFLStudioMenuItem = _factory.BuildMenuItem();
			this.useWithAbletonMenuItem = _factory.BuildMenuItem();
			this.howDoIMenuItem = _factory.BuildMenuItem();
			this.addAFrameMenuItem = _factory.BuildMenuItem();
			this.changeSpeedMenuItem = _factory.BuildMenuItem();
			this.shiftFramesMenuItem = _factory.BuildMenuItem();
			this.deleteFramesMenuItem = _factory.BuildMenuItem();
			//this.midiCheck = _factory.BuildTimer();
			this.frameLabelView = _factory.BuildLabelView();
			this.textBox2 = _factory.BuildTextBox();
			this.textBox1 = _factory.BuildTextBox();
			this.frameListBox = _factory.BuildListView();
			this.shiftButton = _factory.BuildButton();
			this.addFrameButton = _factory.BuildButton();
			//this.timeline1 = new SongIllustrator.Timeline();
			this.fullscreenButton =  _factory.BuildButton();
			//this.imageButton =  _factory.BuildButton();
			this.syncButton = _factory.BuildButton();
			//this.contextMenuStrip1.SuspendLayout();
			//((System.ComponentModel.ISupportInitialize) (this.pixelBar)).BeginInit();
			//((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
			//this.splitContainer1.Panel1.SuspendLayout();
			//this.splitContainer1.Panel2.SuspendLayout();
			//this.splitContainer1.SuspendLayout();
			//this.menuStrip1.SuspendLayout();
			//this.SuspendLayout();
			// 
			// timer1
			// 
			//this.timer1.Interval = 1;
			//this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			//
			if (!(_factory.GetType() == typeof(DummyFactory))) {
				this.panel1.ControlLocation = new ControlLocation(0, 0);
				this.panel1.Name = "panel1";
				this.panel1.ControlSize = new ControlSize(552, 479);
				this.panel1.TabIndex = 68;
				//this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
				// 
				// contextMenuStrip1
				// 
				this.contextMenuStrip1.AddRange(new IMenuItemView[] {
            this.refreshMenuItem,
            this.duplicateMenuItem,
            this.reverseDuplicateMenuItem,
            this.deleteMenuItem,
            this.exportSelectionMenuItem});
				this.contextMenuStrip1.Name = "contextMenuStrip1";
				this.contextMenuStrip1.ControlSize = new ControlSize(168, 114);
				// 
				// refreshMenuItem
				// 
				this.refreshMenuItem.Name = "refreshMenuItem";
				this.refreshMenuItem.Size = new ControlSize(167, 22);
				this.refreshMenuItem.Text = "Refresh";
				this.refreshMenuItem.Click += new System.EventHandler(this.refreshButton_Click);
				// 
				// duplicateMenuItem
				// 
				this.duplicateMenuItem.Name = "duplicateMenuItem";
				this.duplicateMenuItem.Size = new ControlSize(167, 22);
				this.duplicateMenuItem.Text = "Duplicate";
				this.duplicateMenuItem.Click += new System.EventHandler(this.duplicateButton_Click);
				// 
				// reverseDuplicateMenuItem
				// 
				this.reverseDuplicateMenuItem.Name = "reverseDuplicateMenuItem";
				this.reverseDuplicateMenuItem.Size = new ControlSize(167, 22);
				this.reverseDuplicateMenuItem.Text = "Reverse Duplicate";
				this.reverseDuplicateMenuItem.Click += new System.EventHandler(this.reverseDuplicateToolStripMenuItem_Click);
				// 
				// deleteMenuItem
				// 
				this.deleteMenuItem.Name = "deleteMenuItem";
				this.deleteMenuItem.Size = new ControlSize(167, 22);
				this.deleteMenuItem.Text = "Delete";
				this.deleteMenuItem.Click += new System.EventHandler(this.deleteButton_Click);
				// 
				// exportSelectionMenuItem
				// 
				this.exportSelectionMenuItem.AddRange(new IMenuItemView[] {
            this.toMIDIMenuItem});
				this.exportSelectionMenuItem.Name = "exportSelectionMenuItem";
				this.exportSelectionMenuItem.Size = new ControlSize(167, 22);
				this.exportSelectionMenuItem.Text = "Export Selection";
				// 
				// toMIDIMenuItem
				// 
				this.toMIDIMenuItem.Name = "toMIDIMenuItem";
				this.toMIDIMenuItem.Size = new ControlSize(116, 22);
				this.toMIDIMenuItem.Text = "To MIDI";
				//this.toMIDIMenuItem.Click += new System.EventHandler(this.toMIDIMenuItem_Click);
				// 
				// pixelBar
				// 
				//this.pixelBar.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
				/*this.pixelBar.LargeChange = 8;
				this.pixelBar.ControlLocation = new ControlLocation(439, 4);
				this.pixelBar.Maximum = 32;
				this.pixelBar.Minimum = 8;
				this.pixelBar.Name = "pixelBar";
				this.pixelBar.ControlSize = new ControlSize(112, 45);
				this.pixelBar.SmallChange = 8;
				this.pixelBar.TabIndex = 80;
				this.pixelBar.Value = 8;
				this.pixelBar.Visible = false;*/
				// 
				// splitContainer1
				// 
				//this.splitContainer1.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
				//      | AnchorStyles.Left)
				//      | AnchorStyles.Right)));
				//this.splitContainer1.ControlLocation = new ControlLocation(2, 25);
				//this.splitContainer1.Name = "splitContainer1";
				//this.splitContainer1.Orientation = Orientation.Horizontal;
				// 
				// splitContainer1.Panel1
				// 
				//this.ViewItems.Add(this.panel1);
				// 
				// splitContainer1.Panel2
				// 
				//this.ViewItems.Add(this.timeline1);
				//this.splitContainer1.ControlSize = new ControlSize(552, 586);
				//this.splitContainer1.SplitterDistance = 479;
				//this.splitContainer1.TabIndex = 88;
				// 
				// menuStrip1
				// 
				this.menuStrip1.AddRange(new IMenuItemView[] {
            this.fILEMenuItem,
            this.editMenuItem,
            this.projectMenuItem,
            this.pLaylistMenuItem,
            this.launchpadMenuItem,
            this.helpMenuItem});
				this.menuStrip1.ControlLocation = new ControlLocation(0, 0);
				this.menuStrip1.Name = "menuStrip1";
				this.menuStrip1.ControlSize = new ControlSize(684, 24);
				this.menuStrip1.TabIndex = 89;
				this.menuStrip1.Text = "menuStrip1";
				// 
				// fILEMenuItem
				// 
				this.fILEMenuItem.AddRange(new IMenuItemView[] {
            this.newMenuItem1,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.exportMenuItem});
				this.fILEMenuItem.Name = "fILEMenuItem";
				this.fILEMenuItem.Size = new ControlSize(37, 20);
				this.fILEMenuItem.Text = "&File";
				// 
				// newMenuItem1
				// 
				this.newMenuItem1.Name = "newMenuItem1";
				this.newMenuItem1.Size = new ControlSize(114, 22);
				this.newMenuItem1.Text = "&New";
				this.newMenuItem1.Click += new System.EventHandler(this.new_Click);
				// 
				// openMenuItem
				// 
				this.openMenuItem.Name = "openMenuItem";
				this.openMenuItem.Size = new ControlSize(114, 22);
				this.openMenuItem.Text = "&Open";
				this.openMenuItem.Click += new System.EventHandler(this.openDisplayFileButton_Click);
				// 
				// saveMenuItem
				// 
				this.saveMenuItem.Name = "saveMenuItem";
				this.saveMenuItem.Size = new ControlSize(114, 22);
				this.saveMenuItem.Text = "&Save";
				this.saveMenuItem.Click += new System.EventHandler(this.saveButton_Click);
				// 
				// saveAsMenuItem
				// 
				this.saveAsMenuItem.Name = "saveAsMenuItem";
				this.saveAsMenuItem.Size = new ControlSize(114, 22);
				this.saveAsMenuItem.Text = "Save &As";
				this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
				// 
				// exportMenuItem
				// 
				this.exportMenuItem.AddRange(new IMenuItemView[] {
            this.toMIDIMenuItem1});
				this.exportMenuItem.Name = "exportMenuItem";
				this.exportMenuItem.Size = new ControlSize(114, 22);
				this.exportMenuItem.Text = "Export";
				// 
				// toMIDIMenuItem1
				// 
				this.toMIDIMenuItem1.Name = "toMIDIMenuItem1";
				this.toMIDIMenuItem1.Size = new ControlSize(116, 22);
				this.toMIDIMenuItem1.Text = "To MIDI";
				//this.toMIDIMenuItem1.Click += new System.EventHandler(this.toMIDIMenuItem1_Click);
				// 
				// editMenuItem
				// 
				this.editMenuItem.AddRange(new IMenuItemView[] {
            this.editCurrentFrameMenuItem,
            this.stopEditingCurrentFrameMenuItem});
				this.editMenuItem.Name = "editMenuItem";
				this.editMenuItem.Size = new ControlSize(39, 20);
				this.editMenuItem.Text = "Edit";
				// 
				// editCurrentFrameMenuItem
				// 
				this.editCurrentFrameMenuItem.Name = "editCurrentFrameMenuItem";
				this.editCurrentFrameMenuItem.Size = new ControlSize(217, 22);
				this.editCurrentFrameMenuItem.Text = "Edit Current Frame";
				this.editCurrentFrameMenuItem.Click += new System.EventHandler(this.editCurrentFrameToolStripMenuItem_Click);
				// 
				// stopEditingCurrentFrameMenuItem
				// 
				this.stopEditingCurrentFrameMenuItem.Enabled = false;
				this.stopEditingCurrentFrameMenuItem.Name = "stopEditingCurrentFrameMenuItem";
				this.stopEditingCurrentFrameMenuItem.Size = new ControlSize(217, 22);
				this.stopEditingCurrentFrameMenuItem.Text = "Stop Editing Current Frame";
				this.stopEditingCurrentFrameMenuItem.Click += new System.EventHandler(this.stopEditingCurrentFrameToolStripMenuItem_Click);
				// 
				// projectMenuItem
				// 
				this.projectMenuItem.AddRange(new IMenuItemView[] {
            this.pickSongMenuItem});
				this.projectMenuItem.Name = "projectMenuItem";
				this.projectMenuItem.Size = new ControlSize(56, 20);
				this.projectMenuItem.Text = "Project";
				// 
				// pickSongMenuItem
				// 
				this.pickSongMenuItem.Name = "pickSongMenuItem";
				this.pickSongMenuItem.Size = new ControlSize(126, 22);
				this.pickSongMenuItem.Text = "Pick Song";
				this.pickSongMenuItem.Click += new System.EventHandler(this.songButton_Click);
				// 
				// pLaylistMenuItem
				// 
				this.pLaylistMenuItem.AddRange(new IMenuItemView[] {
            this.openPlaylistMenuItem,
            this.createPlaylistMenuItem});
				this.pLaylistMenuItem.Name = "pLaylistMenuItem";
				this.pLaylistMenuItem.Size = new ControlSize(56, 20);
				this.pLaylistMenuItem.Text = "Playlist";
				// 
				// openPlaylistMenuItem
				// 
				this.openPlaylistMenuItem.Name = "openPlaylistMenuItem";
				this.openPlaylistMenuItem.Size = new ControlSize(148, 22);
				this.openPlaylistMenuItem.Text = "Open Playlist";
				this.openPlaylistMenuItem.Click += new System.EventHandler(this.listButton_Click);
				// 
				// createPlaylistMenuItem
				// 
				this.createPlaylistMenuItem.Name = "createPlaylistMenuItem";
				this.createPlaylistMenuItem.Size = new ControlSize(148, 22);
				this.createPlaylistMenuItem.Text = "Create Playlist";
				this.createPlaylistMenuItem.Click += new System.EventHandler(this.createListButton_Click);
				// 
				// launchpadMenuItem
				// 
				this.launchpadMenuItem.AddRange(new IMenuItemView[] {
            this.FormControlEditorMenuItem,
            this.MenuItemSeperator1,
            this.addLaunchpadMenuItem,
            this.removeLaunchpadMenuItem});
				this.launchpadMenuItem.Name = "launchpadMenuItem";
				this.launchpadMenuItem.Size = new ControlSize(78, 20);
				this.launchpadMenuItem.Text = "Launchpad";
				this.launchpadMenuItem.Click += new System.EventHandler(this.launchpadToolStripMenuItem_Click);
				// 
				// FormControlEditorMenuItem
				// 
				this.FormControlEditorMenuItem.Enabled = false;
				this.FormControlEditorMenuItem.Name = "FormControlEditorMenuItem";
				this.FormControlEditorMenuItem.Size = new ControlSize(184, 22);
				this.FormControlEditorMenuItem.Text = "Enable Passive Mode";
				this.FormControlEditorMenuItem.Click += new System.EventHandler(this.FormControlEditorToolStripMenuItem_Click);
				// 
				// MenuItemSeperator1
				// 
				this.MenuItemSeperator1.Name = "MenuItemSeperator1";
				this.MenuItemSeperator1.Size = new ControlSize(181, 6);
				// 
				// addLaunchpadMenuItem
				// 
				this.addLaunchpadMenuItem.Name = "addLaunchpadMenuItem";
				this.addLaunchpadMenuItem.Size = new ControlSize(184, 22);
				this.addLaunchpadMenuItem.Text = "Add Launchpad";
				this.addLaunchpadMenuItem.Click += new System.EventHandler(this.addLaunchpadToolStripMenuItem_Click);
				// 
				// removeLaunchpadMenuItem
				// 
				this.removeLaunchpadMenuItem.Name = "removeLaunchpadMenuItem";
				this.removeLaunchpadMenuItem.Size = new ControlSize(184, 22);
				this.removeLaunchpadMenuItem.Text = "Remove Launchpad";
				this.removeLaunchpadMenuItem.Click += new System.EventHandler(this.removeLaunchpadToolStripMenuItem_Click);
				// 
				// helpMenuItem
				// 
				this.helpMenuItem.AddRange(new IMenuItemView[] {
            this.fLPortSetupMenuItem});
				this.helpMenuItem.Name = "helpMenuItem";
				this.helpMenuItem.Size = new ControlSize(44, 20);
				this.helpMenuItem.Text = "Help";
				//this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
				// 
				// fLPortSetupMenuItem
				// 
				this.fLPortSetupMenuItem.AddRange(new IMenuItemView[] {
            this.useWithFLStudioMenuItem,
            this.useWithAbletonMenuItem,
            this.howDoIMenuItem});
				this.fLPortSetupMenuItem.Name = "fLPortSetupMenuItem";
				this.fLPortSetupMenuItem.Size = new ControlSize(97, 22);
				this.fLPortSetupMenuItem.Text = "FAQ";
				// 
				// useWithFLStudioMenuItem
				// 
				this.useWithFLStudioMenuItem.Name = "useWithFLStudioMenuItem";
				this.useWithFLStudioMenuItem.Size = new ControlSize(173, 22);
				this.useWithFLStudioMenuItem.Text = "Use With FL Studio";
				//this.useWithFLStudioMenuItem.Click += new System.EventHandler(this.useWithFLStudioMenuItem_Click);
				// 
				// useWithAbletonMenuItem
				// 
				this.useWithAbletonMenuItem.Name = "useWithAbletonMenuItem";
				this.useWithAbletonMenuItem.Size = new ControlSize(173, 22);
				this.useWithAbletonMenuItem.Text = "Use With Ableton";
				//this.useWithAbletonMenuItem.Click += new System.EventHandler(this.useWithAbletonMenuItem_Click);
				// 
				// howDoIMenuItem
				// 
				this.howDoIMenuItem.AddRange(new IMenuItemView[] {
            this.addAFrameMenuItem,
            this.changeSpeedMenuItem,
            this.shiftFramesMenuItem,
            this.deleteFramesMenuItem});
				this.howDoIMenuItem.Name = "howDoIMenuItem";
				this.howDoIMenuItem.Size = new ControlSize(173, 22);
				this.howDoIMenuItem.Text = "How do I...";
				//this.howDoIMenuItem.Click += new System.EventHandler(this.howDoIMenuItem_Click);
				// 
				// addAFrameMenuItem
				// 
				this.addAFrameMenuItem.Name = "addAFrameMenuItem";
				this.addAFrameMenuItem.Size = new ControlSize(149, 22);
				this.addAFrameMenuItem.Text = "Add a frame";
				//this.addAFrameMenuItem.Click += new System.EventHandler(this.addAFrameMenuItem_Click);
				// 
				// changeSpeedMenuItem
				// 
				this.changeSpeedMenuItem.Name = "changeSpeedMenuItem";
				this.changeSpeedMenuItem.Size = new ControlSize(149, 22);
				this.changeSpeedMenuItem.Text = "Change speed";
				//this.changeSpeedMenuItem.Click += new System.EventHandler(this.changeSpeedMenuItem_Click);
				// 
				// shiftFramesMenuItem
				// 
				this.shiftFramesMenuItem.Name = "shiftFramesMenuItem";
				this.shiftFramesMenuItem.Size = new ControlSize(149, 22);
				this.shiftFramesMenuItem.Text = "Shift frames";
				//this.shiftFramesMenuItem.Click += new System.EventHandler(this.shiftFramesMenuItem_Click);
				// 
				// deleteFramesMenuItem
				// 
				this.deleteFramesMenuItem.Name = "deleteFramesMenuItem";
				this.deleteFramesMenuItem.Size = new ControlSize(149, 22);
				this.deleteFramesMenuItem.Text = "Delete frames";
				//this.deleteFramesMenuItem.Click += new System.EventHandler(this.deleteFramesMenuItem_Click);
				// 
				// midiCheck
				// 
				//this.midiCheck.Interval = 1;
				// 
				// frameLabelView
				// 
				this.frameLabelView.ControlLocation = new ControlLocation(557, 5);
				this.frameLabelView.Name = "frameLabelView";
				this.frameLabelView.ControlSize = new ControlSize(39, 13);
				this.frameLabelView.TabIndex = 90;
				this.frameLabelView.Text = "Frame:";
				// 
				// TextBoxView2
				// 
				this.textBox2.ControlLocation = new ControlLocation(560, 494);
				this.textBox2.Name = "textBox2";
				this.textBox2.ControlSize = new ControlSize(60, 20);
				this.textBox2.TabIndex = 76;
				this.textBox2.Text = "10";
				// 
				// TextBoxView1
				// 
				this.textBox1.ControlLocation = new ControlLocation(560, 468);
				this.textBox1.Name = "textBox1";
				this.textBox1.ControlSize = new ControlSize(60, 20);
				this.textBox1.TabIndex = 71;
				this.textBox1.Text = "0";
				this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
				// 
				// frameListBox
				// 
				//this.frameListBox.Anchor = ((AnchorStyles) (((AnchorStyles.Top | AnchorStyles.Bottom)
				//      | AnchorStyles.Right)));
				//this.frameListBox.ControlBackColor = Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
				//this.frameListBox.BorderStyle = BorderStyle.None;
				//this.frameListBox.ContextMenuStrip = this.contextMenuStrip1;
				//this.frameListBox.FormattingEnabled = true;
				this.frameListBox.ControlLocation = new ControlLocation(560, 27);
				this.frameListBox.Name = "frameListBox";
				this.frameListBox.ControlSize = new ControlSize(115, 435);
				this.frameListBox.TabIndex = 69;
				this.frameListBox.Click += new System.EventHandler(this.checkedListBox1_Click);
				this.frameListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
				//this.frameListBox.KeyDown += new EventHandler(this.checkedListBox1_KeyDown);
				//this.frameListBox.KeyUp += new EventHandler(this.checkedListBox1_KeyUp);
				// 
				// shiftButton
				// 
				//this.shiftButton.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
				//this.shiftButton.ArrayPos = 0;
				try{
				this.shiftButton.ControlBackColor = Color.Gray;
				}catch{
				}
				//this.shiftButton.BackgroundImage = ((Image) (resources.GetObject("shiftButton.BackgroundImage")));
				//this.shiftButton.BackgroundImageLayout = ImageLayout.Stretch;
				//this.shiftButton.CanSendMessage = true;
				this.shiftButton.Text = "Shift";
				//this.shiftButton.LaunchpadEdit = false;
				this.shiftButton.ControlLocation = new ControlLocation(623, 468);
				this.shiftButton.Name = "shiftButton";
				//	this.shiftButton.Port = null;
				//	this.shiftButton.ShiftDown = false;
				this.shiftButton.ControlSize = new ControlSize(49, 20);
				this.shiftButton.TabIndex = 91;
				this.shiftButton.Click += new System.EventHandler(this.shiftButton_Click);
				// 
				// addFrameButton
				// 
				//this.addFrameButton.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
				//this.addFrameButton.ArrayPos = 0;
				try{
				this.addFrameButton.ControlBackColor = Color.Gray;
				}catch{
				}
				//this.addFrameButton.BackgroundImage = ((Image) (resources.GetObject("addFrameButton.BackgroundImage")));
				//this.addFrameButton.BackgroundImageLayout = ImageLayout.Stretch;
				//this.addFrameButton.CanSendMessage = true;
				this.addFrameButton.Text = "Add Frame";
				//this.addFrameButton.LaunchpadEdit = false;
				this.addFrameButton.ControlLocation = new ControlLocation(560, 520);
				this.addFrameButton.Name = "addFrameButton";
				//this.addFrameButton.Port = null;
				//this.addFrameButton.ShiftDown = false;
				this.addFrameButton.ControlSize = new ControlSize(112, 23);
				this.addFrameButton.TabIndex = 39;
				this.addFrameButton.Load += new System.EventHandler(this.button39_Load);
				this.addFrameButton.Click += new System.EventHandler(this.addFrameButton_Click);
				// 
				// timeline1
				// 
				////this.timeline1.AutoScroll = true;
				////this.timeline1.ControlBackColor = Color.Black;
				////this.timeline1.Dock = DockStyle.Fill;
				//this.timeline1.ControlLocation = new ControlLocation(0, 0);
				//this.timeline1.MinimumSize = new ControlSize(0, 75);
				//this.timeline1.Name = "timeline1";
				//this.timeline1.ControlSize = new ControlSize(552, 103);
				//this.timeline1.TabIndex = 85;
				// 
				// fullscreenButton
				// 
				//this.fullscreenButton.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
				//this.fullscreenButton.ArrayPos = 0;
				//this.fullscreenButton.ControlBackColor = Color.Gray;
				//this.fullscreenButton.BackgroundImage = ((Image) (resources.GetObject("fullscreenButton.BackgroundImage")));
				//this.fullscreenButton.BackgroundImageLayout = ImageLayout.Stretch;
				//this.fullscreenButton.CanSendMessage = true;
				this.fullscreenButton.Text = "Fullscreen";
				//this.fullscreenButton.LaunchpadEdit = false;
				this.fullscreenButton.ControlLocation = new ControlLocation(560, 549);
				this.fullscreenButton.Name = "fullscreenButton";
				//this.fullscreenButton.Port = null;
				//this.fullscreenButton.ShiftDown = false;
				this.fullscreenButton.ControlSize = new ControlSize(112, 23);
				this.fullscreenButton.TabIndex = 79;
				this.fullscreenButton.Click += new System.EventHandler(this.fullscreen_Click);
				// 
				// imageButton
				// 
				////this.imageButton.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
				//this.imageButton.ArrayPos = 0;
				//this.imageButton.ControlBackColor = Color.Gray;
				////this.imageButton.BackgroundImage = ((Image) (resources.GetObject("imageButton.BackgroundImage")));
				////this.imageButton.BackgroundImageLayout = ImageLayout.Stretch;
				//this.imageButton.CanSendMessage = true;
				//this.imageButton.DisplayText = "Overlay Image";
				//this.imageButton.LaunchpadEdit = false;
				//this.imageButton.ControlLocation = new ControlLocation(560, 578);
				//this.imageButton.Name = "imageButton";
				//this.imageButton.Port = null;
				//this.imageButton.ShiftDown = false;
				//this.imageButton.ControlSize = new ControlSize(112, 23);
				//this.imageButton.TabIndex = 84;
				//this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
				// 
				// syncButton
				// 
				//this.syncButton.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
				//this.syncButton.ArrayPos = 0;
				//this.syncButton.ControlBackColor = Color.Gray;
				//this.syncButton.BackgroundImage = ((Image) (resources.GetObject("syncButton.BackgroundImage")));
				//this.syncButton.BackgroundImageLayout = ImageLayout.Stretch;
				//this.syncButton.CanSendMessage = true;
				this.syncButton.Text = "Sync";
				//this.syncButton.LaunchpadEdit = false;
				this.syncButton.ControlLocation = new ControlLocation(623, 494);
				this.syncButton.Name = "syncButton";
				//this.syncButton.Port = null;
				//this.syncButton.ShiftDown = false;
				this.syncButton.ControlSize = new ControlSize(49, 20);
				this.syncButton.TabIndex = 82;
				this.syncButton.Click += new System.EventHandler(this.displayButton2_Click);

				// 
				// MainForm
				// 
				//this.AutoScaleDimensions = new ControlSizeF(6F, 13F);
				//this.AutoScaleMode = AutoScaleMode.Font;
				//this.ControlBackColor = SystemColors.ActiveCaptionText;
				//this.ClientSize = new ControlSize(684, 662);
				this.ViewItems.Add(this.frameListBox);
				this.ViewItems.Add(this.shiftButton);
				this.ViewItems.Add(this.addFrameButton);
				this.ViewItems.Add(this.frameLabelView);
				this.ViewItems.Add(this.textBox1);
				//this.ViewItems.Add(this.splitContainer1);
				this.ViewItems.Add(this.textBox2);
				this.ViewItems.Add(this.fullscreenButton);
				//this.ViewItems.Add(this.imageButton);
				this.ViewItems.Add(this.pixelBar);
				this.ViewItems.Add(this.syncButton);
				this.ViewItems.Add(this.menuStrip1);
				//this.DoubleBuffered = true;
				//this.FormBorderStyle = FormBorderStyle.FixedDialog;
				//this.MainMenuStrip = this.menuStrip1;
				//this.MaximizeBox = false;
				this.Name = "MainForm";
				this.Text = "Song Illustrator";
				//this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
				//this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
				this.Load += new System.EventHandler(this.Form1_Load);
				//this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
				//this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
				//this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
				//this.Resize += new System.EventHandler(this.Form1_Resize);
				//this.contextMenuStrip1.ResumeLayout(false);
				//((System.ComponentModel.ISupportInitialize) (this.pixelBar)).EndInit();
				//this.splitContainer1.Panel1.ResumeLayout(false);
				//this.splitContainer1.Panel2.ResumeLayout(false);
				//((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
				//this.splitContainer1.ResumeLayout(false);
				//this.menuStrip1.ResumeLayout(false);
				//this.menuStrip1.PerformLayout();
				//this.ResumeLayout(false);
				//this.PerformLayout();
			}

		}

		#endregion
		private ILabelView frameLabel;
		//private Timer timer1;
		private IPanelView panel1;
		private ITrackBarView pixelBar;
		//private IArrayView frameCheckbox;
		private Timeline timeline1;
	//	private SplitContainerView splitContainer1;
		private IToolStripMenuView menuStrip1;
		private IMenuItemView fILEMenuItem;
		private IMenuItemView openMenuItem;
		private IMenuItemView saveMenuItem;
		private IMenuItemView projectMenuItem;
		private IMenuItemView pickSongMenuItem;
		private IMenuItemView newMenuItem1;
		private IMenuItemView pLaylistMenuItem;
		private IMenuItemView openPlaylistMenuItem;
		private IMenuItemView createPlaylistMenuItem;
		private IContextMenuView contextMenuStrip1;
		private IMenuItemView refreshMenuItem;
		private IMenuItemView duplicateMenuItem;
		private IMenuItemView deleteMenuItem;
		//private Timer midiCheck;
		private ILabelView frameLabelView;
		private IMenuItemView exportSelectionMenuItem;
		private IMenuItemView toMIDIMenuItem;
		private IMenuItemView exportMenuItem;
		private IMenuItemView toMIDIMenuItem1;
		private IMenuItemView launchpadMenuItem;
		private IMenuItemView FormControlEditorMenuItem;
		private IMenuItemSeperator MenuItemSeperator1;
		private IMenuItemView addLaunchpadMenuItem;
		private IMenuItemView saveAsMenuItem;
		private IMenuItemView removeLaunchpadMenuItem;
		private IMenuItemView helpMenuItem;
		private IMenuItemView fLPortSetupMenuItem;
		private IMenuItemView useWithFLStudioMenuItem;
		private IMenuItemView howDoIMenuItem;
		private IMenuItemView addAFrameMenuItem;
		private IMenuItemView changeSpeedMenuItem;
		private IMenuItemView shiftFramesMenuItem;
		private IMenuItemView deleteFramesMenuItem;
		private IMenuItemView useWithAbletonMenuItem;
		private IMenuItemView reverseDuplicateMenuItem;
		private IMenuItemView editMenuItem;
		private IMenuItemView editCurrentFrameMenuItem;
		private IMenuItemView stopEditingCurrentFrameMenuItem;
		//private IButtonView imageButton;
		private IButtonView syncButton;
		private IButtonView fullscreenButton;
		private ITextBoxView textBox2;
		private ITextBoxView textBox1;
		private IButtonView addFrameButton;
		private IButtonView shiftButton;
		private IArrayView frameListBox;
	}
}

