using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TobiasErichsen.teVirtualMIDI;
using TypingConnector;

namespace SongIllustrator {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}
		private Stream _overlayImage;
		private TeVirtualMIDI _port = new TeVirtualMIDI("Song Illustrator");

		public TeVirtualMIDI Port {
			get {
				return _port;
			}
			set {
				_port = value;
			}
		}

		public Stream OverlayImage {
			get {
				return _overlayImage;
			}
			set {
				_overlayImage = value;
				display.OverlayImage = _overlayImage;
			}
		}
		public CheckedListBox FrameList {
			get {
				return frameListBox;
			}
			set {
				frameListBox = value;
			}
		}
		private FrameData _refFrame1;
		private FrameData _refFrame2;
		int _frameReferences = 0;
		private const int SysExBufferSize = 128;


		private SynchronizationContext context;

		public Form1(string filename) {
			InitializeComponent();
			if (filename != null) {
				if (filename.Length > 0) {
					OpenFileDialog(filename);
				}
			}
		}
		int frameProgress = 0;
		int playlistPosition = 1;
		bool gotPlay = false;
		List<string> playlist = new List<string>();
		bool shiftDown = false;
		ShowDisplay display = new ShowDisplay();
		MilliStopWatch stopwatch = new MilliStopWatch();
		List<FrameData> frames = new List<FrameData>();
		private bool _shiftDown;
		private Thread _thread;
		private bool _controlEditor = true;
		private bool _listenToMidi = true;

		public bool ControlEditor {
			get {
				return _controlEditor;
			}
			set {
				_controlEditor = value;
			}
		}

		public Panel Canvas {
			get {
				return panel1;
			}
			set {
				panel1 = value;
			}
		}
		public string Timestamp {
			get {
				return textBox1.Text;
			}
			set {
				textBox1.Text = value;
			}
		}
		public List<FrameData> Frames {
			get {
				return frames;
			}
			set {
				frames = value;
			}
		}
		public int Density {
			get {
				return pixelBar.Value;
			}
			set {
				pixelBar.Value = value;
			}
		}
		private void button38_Click(object sender, EventArgs e) {
		}

		private void refreshButton_Click(object sender, EventArgs e) {
			/*try {
				frameListBox.Items.Clear();
				frames.Sort(delegate(FrameData data1, FrameData data2) {
					return data1.TimeStamp - data2.TimeStamp;
				});
				foreach (FrameData frame in frames) {
					frameListBox.Items.Add(frame);
				}
			} catch {

			}*/
			UpdateFrames();
		}
		private void NoteToButton(string note) {

		}
		private void pauseButton_Click(object sender, EventArgs e) {
			stopwatch.Stop();
		}

		private void stopButton_Click(object sender, EventArgs e) {
			timer1.Stop();
			stopwatch.Reset();
		}
		private void timer1_Tick(object sender, EventArgs e) {
			stopwatch.Stop();
			foreach (FrameData time in frames) {
				decimal currentPos = (decimal) axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
				if (currentPos * 100 <= time.TimeStamp) {
					time.Fired = false;
				}
				if (currentPos * 100 >= time.TimeStamp) {
					if (!time.Fired) {
						frameLabel.Text = "Frame: " + time.TimeStamp;
						for (int i = 0; i < panel1.Controls.Count; i++) {
							panel1.Controls[i].BackColor = time.Colours[i];
							if (display.PadLights.Controls.Count > 0) {
								try {
									display.PadLights.Controls[i].BackColor = time.Colours[i];
								} catch {

								}
							}
						}
						time.Fired = true;
						frameProgress++;
					}
				}
			}
			if (frameProgress >= frames.Count && frameProgress >= frameListBox.Items.Count && frameCheckbox.Checked) {
				stopwatch.Reset();
				stopwatch.Start();
				frameProgress = 0;
			}
			stopwatch.Start();
		}

		private void button39_Click(object sender, EventArgs e) {
			FrameData data = new FrameData();
			try {
				decimal currentCount = 0;
				if (frames.Count != 0) {
					currentCount = frames[frames.Count - 1].TimeStamp;
				}
				data.TimeStamp = currentCount + decimal.Parse(textBox2.Text);
			} catch (FormatException) {
			}
			foreach (DisplayButton button in panel1.Controls) {
				data.Colours.Add(button.BackColor);
			}
			frames.Add(data);
			UpdateFrames();
		}
		private void UpdateFrames() {
			frameListBox.Items.Clear();
			frames.Sort(delegate(FrameData data1, FrameData data2) {
				return (int) data1.TimeStamp - (int) data2.TimeStamp;
			});
			foreach (FrameData frame in frames) {
				frameListBox.Items.Add(frame);
			}
			if (frameListBox.Items.Count > 0) {
				pixelBar.Enabled = false;
			}
			timeline1.UpdateTimeline();
		}
		private void checkedListBox1_Click(object sender, EventArgs e) {
			for (int i = 0; i < panel1.Controls.Count; i++) {
				try {
					panel1.Controls[i].BackColor = (frameListBox.SelectedItem as FrameData).Colours[i];
					textBox1.Text = (frameListBox.SelectedItem as FrameData).TimeStamp.ToString();
				} catch {
				}
			}
		}

		private void displayButton1_Click(object sender, EventArgs e) {
			//try
			//{
			//    (frameListBox.SelectedItem as FrameData).Colours.Clear();
			//}
			//catch
			//{

			//}
			//foreach (DisplayButton button in panel1.Controls)
			//{
			//    try
			//    {
			//        (frameListBox.SelectedItem as FrameData).Colours.Add(button.BackColor);
			//    }
			//    catch
			//    {

			//    }
			//}
		}

		private void displayButton1_Load(object sender, EventArgs e) {

		}

		private void songButton_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				axWindowsMediaPlayer1.URL = dialog.FileName;
			}
		}

		private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) {
			if (e.newState == 3) {
				timer1.Start();
				stopwatch.Start();
				_listenToMidi = false;
				gotPlay = true;
			}
			if (e.newState == 2) {
				timer1.Stop();
				stopwatch.Stop();
				_listenToMidi = true;
			}
			if (gotPlay) {
				if (e.newState == 1) {
					gotPlay = false;
					timer1.Stop();
					stopwatch.Stop();
					_listenToMidi = false;
					stopwatch.Reset();
				}
				if (e.newState == 8) {
					if (playlist.Count > 1) {
						if (playlistPosition < playlist.Count) {
							try {
								OpenFileDialog(playlist[playlistPosition++]);
							} catch {

							}
						}
					}
				}
				if (e.newState == 10) {
					try {
						axWindowsMediaPlayer1.Ctlcontrols.play();
						stopwatch.Reset();
					} catch {
					}
				}
			}
		}

		private void duplicateButton_Click(object sender, EventArgs e) {
			decimal currentCount = 0;
			decimal difference = 0;
			if (frames.Count != 0) {
				currentCount = frames[frames.Count - 1].TimeStamp;
			}
			for (int i = 0; i < frameListBox.CheckedItems.Count; i++) {
				FrameData item = frameListBox.CheckedItems[i] as FrameData;
				FrameData data = new FrameData();
				try {
					data.Colours = item.Colours;
					if (i < frameListBox.CheckedItems.Count - 1) {
						FrameData frame2 = (frameListBox.CheckedItems[i + 1] as FrameData);
						difference = frame2.TimeStamp - item.TimeStamp;
					}
					currentCount += difference;
					data.TimeStamp = currentCount;
					frames.Add(data);
				} catch {
					MessageBox.Show("Nothing is selected.");
				}
			}
			UpdateFrames();
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			try {
				//(frameListBox.SelectedItem as FrameData).TimeStamp = decimal.Parse(textBox1.Text);
			} catch {
				try {
					//textBox1.Text = (frameListBox.SelectedItem as FrameData).TimeStamp.ToString();
				} catch {
				}
			}
		}

		private void saveButton_Click(object sender, EventArgs e) {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			if (dialog.ShowDialog() == DialogResult.OK) {
				SaveFileDialog(dialog.FileName);
			}
		}
		private void OpenFileDialog(string filepath) {
			frames.Clear();
			frameProgress = 0;
			panel1.Controls.Clear();
			GeneratePixels(Density);
			timer1.Stop();
			stopwatch.Stop();
			stopwatch.Reset();
			pixelBar.Enabled = false;
			using (FileStream openStream = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
				using (BinaryReader reader = new BinaryReader(openStream)) {
					string version = reader.ReadString();
					if (version.Contains("v")) {
						GeneratePixels(display.Pixels = pixelBar.Value = display.Pixels = reader.ReadInt32());
						int frameCount;
						frameCount = reader.ReadInt32();
						for (int i = 0; i < frameCount; i++) {
							FrameData frame = new FrameData();
							if (version.Contains("v1")) {
								frame.TimeStamp = reader.ReadInt32();
							} else {
								if (version.Contains("v2")) {
									frame.TimeStamp = reader.ReadDecimal();
								}
							}
							int colourCount = reader.ReadInt32();
							for (int colorNumber = 0; colorNumber < colourCount; colorNumber++) {
								try {
									frame.Colours.Add(Color.FromArgb(reader.ReadInt32()));
								} catch {
									object test;
								}
							}
							frames.Add(frame);
						}
						try {
							axWindowsMediaPlayer1.URL = reader.ReadString();
						} catch {

						}
					}
				}
			}
			//timeline1.UpdateTimeline();
			UpdateFrames();
		}
		private void FixFile(List<FrameData> corruptFrames) {
			foreach (FrameData frame in corruptFrames) {
				Color[] data = new Color[frame.Colours.Count];
				data[0] = frame.Colours[0];
				data[1] = frame.Colours[1];
				data[2] = frame.Colours[3];
				data[3] = frame.Colours[2];
				data[4] = frame.Colours[24];
				data[5] = frame.Colours[5];
				data[6] = frame.Colours[4];
				data[7] = frame.Colours[7];
				data[8] = frame.Colours[6];
				data[9] = frame.Colours[23];
				data[10] = frame.Colours[15];
				data[11] = frame.Colours[14];
				data[12] = frame.Colours[13];
				data[13] = frame.Colours[12];
				data[14] = frame.Colours[22];
				data[15] = frame.Colours[11];
				data[16] = frame.Colours[10];
				data[17] = frame.Colours[9];
				data[18] = frame.Colours[8];
				data[19] = frame.Colours[21];
				data[20] = frame.Colours[19];
				data[21] = frame.Colours[18];
				data[22] = frame.Colours[17];
				data[23] = frame.Colours[16];
				data[24] = frame.Colours[20];
				data[25] = frame.Colours[25];
				data[26] = frame.Colours[27];
				data[27] = frame.Colours[26];
				data[28] = frame.Colours[28];
				data[29] = frame.Colours[30];
				data[30] = frame.Colours[39];
				data[31] = frame.Colours[31];
				data[32] = frame.Colours[63];
				data[33] = frame.Colours[62];
				data[34] = frame.Colours[61];
				data[35] = frame.Colours[60];
				data[36] = frame.Colours[43];
				data[37] = frame.Colours[59];
				data[38] = frame.Colours[58];
				data[39] = frame.Colours[57];
				data[40] = frame.Colours[56];
				data[41] = frame.Colours[43];
				data[42] = frame.Colours[56];
				data[43] = frame.Colours[54];
				data[44] = frame.Colours[53];
				data[45] = frame.Colours[52];
				data[46] = frame.Colours[41];
				data[47] = frame.Colours[51];
				data[48] = frame.Colours[50];
				data[49] = frame.Colours[49];
				data[50] = frame.Colours[48];
				data[51] = frame.Colours[40];
				data[52] = frame.Colours[47];
				data[53] = frame.Colours[46];
				data[54] = frame.Colours[45];
				data[55] = frame.Colours[44];
				data[56] = frame.Colours[39];
				data[57] = frame.Colours[38];
				data[58] = frame.Colours[37];
				data[59] = frame.Colours[35];
				data[60] = frame.Colours[33];
				data[61] = frame.Colours[34];
				data[62] = frame.Colours[32];
				data[63] = frame.Colours[32];
				frame.Colours = new List<Color>();
				frame.Colours.AddRange(data);
			}
		}
		private void SaveFileDialog(string filepath) {
			using (FileStream saveStream = new FileStream(filepath, FileMode.Create, FileAccess.Write)) {
				using (BinaryWriter writer = new BinaryWriter(saveStream)) {
					writer.Write("v2");
					writer.Write(pixelBar.Value);
					writer.Write(frames.Count);
					foreach (FrameData data in frames) {
						writer.Write(data.TimeStamp);
						writer.Write(data.Colours.Count);
						foreach (Color color in data.Colours) {
							writer.Write(color.ToArgb());
						}
					}
					writer.Write(axWindowsMediaPlayer1.URL);
				}
			}
		}

		private void openDisplayFileButton_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			if (dialog.ShowDialog() == DialogResult.OK) {
				OpenFileDialog(dialog.FileName);
			}
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
			switch (_frameReferences) {
				case 0:
					_refFrame1 = frameListBox.SelectedItem as FrameData;
					if (frameListBox.SelectedIndex >= 0) {
						frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						axWindowsMediaPlayer1.Ctlcontrols.currentPosition = (double) (frameListBox.SelectedItem as FrameData).TimeStamp / 100;
					}
					_frameReferences++;
					break;
				case 1:
					if (_shiftDown) {
						_refFrame2 = frameListBox.SelectedItem as FrameData;
						for (int i = 0; i < frameListBox.Items.Count; i++) {
							FrameData item = frameListBox.Items[i] as FrameData;
							if (_refFrame2 != null) {
								if (item.TimeStamp >= _refFrame1.TimeStamp && item.TimeStamp <= _refFrame2.TimeStamp) {
									frameListBox.SetItemChecked(i, true);
								}
							}
						}
						frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
					} else {
						_refFrame1 = frameListBox.SelectedItem as FrameData;
						if (frameListBox.SelectedIndex != -1) {
							frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						}
					}
					break;
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Shift) {
				shiftDown = true;
				foreach (DisplayButton button in panel1.Controls) {
					button.ShiftDown = true;
				}
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			foreach (DisplayButton button in panel1.Controls) {
				button.ShiftDown = false;
			}
		}

		private void button39_Load(object sender, EventArgs e) {

		}

		private void displayButton65_Click(object sender, EventArgs e) {
			frames = new List<FrameData>();
			frameListBox.Items.Clear();
			axWindowsMediaPlayer1.URL = "";
			pixelBar.Enabled = true;
		}

		private void deleteButton_DoubleClick(object sender, EventArgs e) {

		}

		private void deleteButton_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to delete these frames? (" + frameListBox.CheckedItems.Count + ")", "Delete Item?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				for (int i = frameListBox.CheckedItems.Count - 1; i >= 0; i--) {
					frames.Remove(frameListBox.CheckedItems[i] as FrameData);
					frameListBox.Items.Remove(frameListBox.CheckedItems[i]);
				}
				if (frameListBox.Items.Count < 1) {
					pixelBar.Enabled = false;
				}
			}
			UpdateFrames();
		}

		private void deleteButton_Load(object sender, EventArgs e) {

		}

		private void listButton_Load(object sender, EventArgs e) {

		}
		private void OpenPlaylist(string filepath) {
			frames.Clear();
			playlist.Clear();
			playlist = new List<string>();
			playlistPosition = 1;
			using (FileStream openStream = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
				using (StreamReader reader = new StreamReader(openStream)) {
					int count = int.Parse(reader.ReadLine());
					for (int i = 0; i < count; i++) {
						playlist.Add(reader.ReadLine());
					}
				}
			}
			OpenFileDialog(playlist[0]);
		}

		private void listButton_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Song Illustrator Playlist (*.slpl)|*.slpl";
			if (dialog.ShowDialog() == DialogResult.OK) {
				OpenPlaylist(dialog.FileName);
			}
		}

		private void createListButton_Click(object sender, EventArgs e) {
			List<string> songList = new List<string>();
			bool loop = true;
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			while (loop) {
				if (openDialog.ShowDialog() == DialogResult.OK) {
					songList.AddRange(openDialog.FileNames);
				}
				switch (MessageBox.Show("Would you like to add more display files?", "Create Playlist", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
					case DialogResult.No:
						loop = false;
						break;
				}
			}
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = "Song Illustrator Playlist (*.slpl)|*.slpl";
			if (saveDialog.ShowDialog() == DialogResult.OK) {
				SavePlaylist(saveDialog.FileName, songList);
			}
		}

		private void SavePlaylist(string filepath, List<string> songList) {
			using (FileStream saveStream = new FileStream(filepath, FileMode.Create, FileAccess.Write)) {
				using (StreamWriter writer = new StreamWriter(saveStream)) {
					writer.WriteLine(songList.Count.ToString());
					foreach (string song in songList) {
						writer.WriteLine(song);
					}
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e) {
			GeneratePixels(8);
		}
		private void GeneratePixels(int pixels) {
			panel1.Controls.Clear();
			int arrayPos = 0;
			Size buttonSize = new Size(panel1.Width / pixels, panel1.Height / pixels);
			for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {

				for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
					DisplayButton button = new DisplayButton();
					button.ArrayPos = arrayPos++;
					button.Port = _port;
					button.Size = buttonSize;
					button.Location = new Point(buttonSize.Width * widthProgression, buttonSize.Height * heightProgression);
					panel1.Controls.Add(button);
				}
			}
			if (_overlayImage != null) {
				OverlayButtons(_overlayImage, panel1.Controls);
			}
			if (display.Visible) {
				display.Show();
				display.GeneratePixels(pixels);
			} else {
				display.Show();
				display.GeneratePixels(pixels);
				display.Hide();
			}
		}
		private void displayButton66_Click(object sender, EventArgs e) {
			display.ShowDialog();
		}

		private void openDisplayFileButton_Load(object sender, EventArgs e) {

		}

		private void pixelBar_ValueChanged(object sender, EventArgs e) {
			display.Pixels = pixelBar.Value;
			GeneratePixels(pixelBar.Value);
		}

		private void panel1_SizeChanged(object sender, EventArgs e) {
			List<Color> colours = new List<Color>();
			foreach (DisplayButton button in panel1.Controls) {
				colours.Add(button.BackColor);
			}
			panel1.Width = this.Width - 140;
			GeneratePixels(pixelBar.Value);
			for (int i = 0; i < colours.Count; i++) {
				panel1.Controls[i].BackColor = colours[i];
			}
		}

		private void displayButton1_Click_1(object sender, EventArgs e) {

		}

		private void displayButton2_Click(object sender, EventArgs e) {
			//Sync Button.
			if (MessageBox.Show("Are you sure you want to syncronize frames? It will re-increment the selected frames based on a delay of " + textBox2.Text + ".", "Song Illustrator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
				int frameIndex = 0;
				List<FrameData> tempFrames = new List<FrameData>();
				FrameData data = new FrameData();
				data.TimeStamp = (frameListBox.CheckedItems[0] as FrameData).TimeStamp - decimal.Parse(textBox2.Text);
				tempFrames.Add(data);
				foreach (FrameData item in frameListBox.CheckedItems) {
					tempFrames.Add(item);
				}
				for (int i = 0; i < frameListBox.Items.Count; i++) {
					if (tempFrames[0] == frameListBox.Items[i]) {
						frameIndex = i > 0 ? i - 1 : 0;
						break;
					}
				}
				for (int i = 0; i < frameListBox.CheckedItems.Count; i++) {
					(frameListBox.CheckedItems[i] as FrameData).TimeStamp = (tempFrames[frameIndex] as FrameData).TimeStamp + (decimal.Parse(textBox2.Text) * (i + 1));
				}
			}
		}

		private void Form1_Shown(object sender, EventArgs e) {
			_thread = new Thread(new ThreadStart(MidiDataCoordinator));
			_thread.Start();
		}

		private void refreshButton_Load(object sender, EventArgs e) {

		}

		private void imageButton_Click(object sender, EventArgs e) {
			ImageList imagelist = new ImageList();
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				using (FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read)) {
					OverlayImage = new MemoryStream();
					stream.CopyTo(OverlayImage);
					stream.CopyTo(display.OverlayImage);
					OverlayButtons(OverlayImage, panel1.Controls);
				}
			}
		}
		public void OverlayButtons(Stream bitmapStream, Control.ControlCollection controls) {
			List<Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.Size, new Size(pixelBar.Value, pixelBar.Value));
			for (int i = 0; i < controls.Count; i++) {
				controls[i].BackgroundImage = images[i];
			}
		}

		private void Form1_Resize(object sender, EventArgs e) {
			timeline1.UpdateTimeline();
		}

		private void pixelBar_Scroll(object sender, EventArgs e) {

		}

		private void duplicateButton_Load(object sender, EventArgs e) {

		}

		private void checkedListBox1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.ShiftKey) {
				_shiftDown = true;
			}
		}

		private void checkedListBox1_KeyUp(object sender, KeyEventArgs e) {
			_shiftDown = false;
			_frameReferences = 0;
			_refFrame1 = null;
			_refFrame2 = null;
		}

		private void MidiDataCoordinator() {
			while (true) {
				if (_listenToMidi) {
					byte[] command = _port.getCommand();
					if (command.Length >= 3) {
						int process = command[0];
						int key = command[1];
						int velocity = command[2];
						string note = NoteIdentifier.GetNoteFromInt(key);
						int notePos = NoteIdentifier.GetNotePosition(note);
						//MessageBox.Show(process + "|" + key + "|" + velocity + "     " + stringCommand);
						switch (process) {
							case 128:
								DisplayButton button;
								if (notePos >= 0) {
									Invoke(new MethodInvoker(
										delegate() {
											if (display.Visible == false) {
												button = (DisplayButton) panel1.Controls[NoteIdentifier.GetNotePosition(note)];
											} else {
												button = (DisplayButton) display.PadLights.Controls[NoteIdentifier.GetNotePosition(note)];
											}
											if (!_controlEditor) {
												button.Reset();
												//	button.CanSendMessage = false;
											} else {
												if (velocity == 64) {
													button.SendMessage();
												}
											}
										}));
								}
								break;
							case 144:
								if (notePos >= 0) {
									Invoke(new MethodInvoker(
										delegate() {
											button = panel1.Controls[notePos] as DisplayButton;
											if (display.Visible == false) {
												button = (DisplayButton) panel1.Controls[NoteIdentifier.GetNotePosition(note)];
											} else {
												button = (DisplayButton) display.PadLights.Controls[NoteIdentifier.GetNotePosition(note)];
											}
											switch (velocity) {
												case 7:
													button.BackColor = Color.Red;
													break;
												case 83:
													button.BackColor = Color.Orange;
													break;
												case 124:
													button.BackColor = Color.Green;
													break;
												case 127:
													button.BackColor = Color.Yellow;
													break;
											}
										}));
								}
								break;
							case 176:
								switch (key) {
									case 123:
										//foreach (DisplayButton buttons in panel1.Controls) {
										//buttons.CanSendMessage = false;
										//_controlEditor = false;
										//}
										break;
									case 101:
										break;
									case 100:
										break;
									case 6:
										break;
									case 10:
										break;
									case 7:
										break;
									default:

										break;
								}
								break;
						}
					} else {

					}
				}
			}
		}
		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

		private void midiCheck_Tick(object sender, EventArgs e) {
			MidiDataCoordinator();
		}

		private void shiftButton_Click(object sender, EventArgs e) {
			//Shift Button.
			if (MessageBox.Show("Are you sure you want to shift the frames? It will place the selected frames starting from " + textBox1.Text + "ms.", "Song Illustrator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
				decimal baseStamp = decimal.Parse(textBox1.Text);
				for (int i = 0; i < frameListBox.CheckedItems.Count; i++) {
					decimal difference = 0;
					FrameData frame = (frameListBox.CheckedItems[i] as FrameData);
					if (i < frameListBox.CheckedItems.Count - 1) {
						FrameData frame2 = (frameListBox.CheckedItems[i + 1] as FrameData);
						difference = frame2.TimeStamp - frame.TimeStamp;
					}
					frame.TimeStamp -= frame.TimeStamp - baseStamp;
					baseStamp += difference;
				}
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			_thread.Abort();
		}

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void toMIDIToolStripMenuItem_Click(object sender, EventArgs e) {
			ExportMidi(frames);
		}

		private void ExportMidi(List<FrameData> midiFrames) {
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				MidiIO.WriteMidi(dialog.FileName, midiFrames, 120, 4);
			}
		}

		private void toMIDIToolStripMenuItem1_Click(object sender, EventArgs e) {
			ExportMidi(frames);
		}

		private void controlEditorToolStripMenuItem_Click(object sender, EventArgs e) {
			_controlEditor = !_controlEditor;
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e) {
			_controlEditor = false;
		}
	}
}
