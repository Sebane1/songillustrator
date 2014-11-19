using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TypingConnector;
using System.Drawing.Imaging;
using MediaPlayerModuleBase;

namespace SongIllustrator {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}
		MediaPlayer axWindowsMediaPlayer1;
		private Stream _overlayImage;
		int _portCount = 0;
		string filePath = "";
		bool _changed = true;

		public bool Changed {
			get {
				return _changed;
			}
			set {
				_changed = value;
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
		ShowDisplay display = new ShowDisplay();
		MilliStopWatch stopwatch = new MilliStopWatch();
		List<Launchpad> launchPads = new List<Launchpad>();
		private bool _shiftDown;
		private bool passiveMode = true;
		private int _lowestDivisor;
		private bool shiftDown;
		private void CheckImage() {
			List<List<DisplayButton>> displayButtonsList = new List<List<DisplayButton>>();
			foreach (LightPad launchPad in panel1.Controls) {
				List<DisplayButton> displayButtons = new List<DisplayButton>();
				foreach (DisplayButton displayButton in launchPad.LightCanvas.Controls) {
					displayButtons.Add(displayButton);
				}
				displayButtonsList.Add(displayButtons);
			}
			if (displayButtonsList.Count > 0) {
				OverlayButtons(_overlayImage, displayButtonsList);
			}
		}
		public List<Launchpad> LaunchPads {
			get {
				return launchPads;
			}
			set {
				launchPads = value;
			}
		}
		public bool ControlEditor {
			get {
				return passiveMode;
			}
			set {
				passiveMode = value;
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
			for (int i = 0; i < launchPads.Count; i++) {
				decimal currentPos = (decimal) axWindowsMediaPlayer1.CurrentPosition;
				for (int z = 0; z < launchPads[i].FrameData.Count; z++) {
					FrameData time = launchPads[i].FrameData[z];
					if (currentPos * 100 <= time.TimeStamp) {
						time.Fired = false;
					}
					if (currentPos * 100 >= time.TimeStamp) {
						if (!time.Fired) {
							frameLabel.Text = "Frame: " + time.Index;
							if (panel1.Controls.Count > 0) {
								(panel1.Controls[i] as LightPad).SetFrame(z);
							}
							if (display.Canvas.Controls.Count > 0) {
								LightPad pad = (display.Canvas.Controls[i] as LightPad);
								if (pad != null) {
									pad.SetFrame(z);
								}
							}
							time.Fired = true;
						}
					}
				}
			}
		}

		private void button39_Click(object sender, EventArgs e) {
			_changed = true;
			for (int i = 0; i < launchPads.Count; i++) {
				FrameData data = new FrameData();
				try {
					decimal currentCount = 0;
					if (launchPads[i].FrameData.Count != 0) {
						currentCount = launchPads[i].FrameData[launchPads[i].FrameData.Count - 1].TimeStamp;
					}
					data.TimeStamp = currentCount + decimal.Parse(textBox2.Text);
				} catch (FormatException) {
				}
				foreach (DisplayButton button in (panel1.Controls[i] as LightPad).LightCanvas.Controls) {
					data.Colours.Add(button.BackColor);
				}
				data.Index = launchPads[i].FrameData.Count;
				(panel1.Controls[i] as LightPad).LightData.FrameData.Add(data);
			}
			UpdateFrames();
		}
		private void UpdateFrames() {
			frameListBox.Items.Clear();
			for (int i = 0; i < launchPads.Count; i++) {
				launchPads[i].FrameData.Sort(delegate(FrameData data1, FrameData data2) {
					return (int) data1.TimeStamp - (int) data2.TimeStamp;
				});
			}
			foreach (FrameData frame in launchPads[0].FrameData) {
				frameListBox.Items.Add(frame);
			}
			if (frameListBox.Items.Count > 0) {
				pixelBar.Enabled = false;
			}
			timeline1.UpdateTimeline();
		}

		private void checkedListBox1_Click(object sender, EventArgs e) {
			_changed = true;
			for (int i = 0; i < panel1.Controls.Count; i++) {
				(panel1.Controls[i] as LightPad).SetFrame(frameListBox.SelectedIndex);
				FrameData item = (frameListBox.SelectedItem as FrameData);
				if (item != null) {
					frameLabel.Text = "Frame " + item.Index;
					textBox1.Text = item.TimeStamp.ToString();
				}
			}
		}

		private void songButton_Click(object sender, EventArgs e) {
			_changed = true;
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				axWindowsMediaPlayer1.MediaPath = dialog.FileName;
			}
		}

		private void duplicateButton_Click(object sender, EventArgs e) {
			_changed = true;
			List<FrameData> frameTimes = new List<FrameData>();
			foreach (FrameData item in frameListBox.CheckedItems) {
				frameTimes.Add(item);
			}
			foreach (Launchpad launchPad in launchPads) {
				launchPad.DuplicateFrames(decimal.Parse(textBox2.Text), frameTimes);
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
			Save();
		}

		private DialogResult Save() {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			if (string.IsNullOrEmpty(filePath)) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					SaveFileDialog(dialog.FileName, launchPads);
					filePath = dialog.FileName;
					_changed = false;
					return DialogResult.OK;
				}
			} else {
				_changed = false;
				SaveFileDialog(filePath, launchPads);
				return DialogResult.OK;
			}
			return DialogResult.None;
		}
		private void OpenFileDialog(string filepath) {
			int oldCount = launchPads.Count;
			int newCount = 0;
			_lowestDivisor = 1;
			frameProgress = 0;
			timer1.Stop();
			stopwatch.Stop();
			stopwatch.Reset();
			pixelBar.Enabled = false;
			using (FileStream openStream = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
				List<Launchpad> padData = SongIO.OpenFile(openStream);
				foreach (Launchpad lightData in padData) {
					LightPad lightPad = new LightPad();
					lightPad.LightData = lightData;
				}
				newCount = padData.Count;
				launchPads = MergeLightPads(padData, launchPads);
				axWindowsMediaPlayer1.MediaPath = SongIO.Url;
			}
			//timeline1.UpdateTimeline();
			if (oldCount != newCount) {
				panel1.Controls.Clear();
				GeneratePads(launchPads, panel1);
			} else {
				OverWritePadFrame(launchPads, panel1);
			}
			UpdateFrames();
		}

		private void OverWritePadFrame(List<Launchpad> launchPads, Panel panel1) {
			for (int i = 0; i < panel1.Controls.Count; i++) {
				(panel1.Controls[i] as LightPad).LightData.FrameData = launchPads[i].FrameData;
			}
		}

		private List<Launchpad> MergeLightPads(List<Launchpad> newList, List<Launchpad> existingList) {
			for (int i = 0; i < Math.Max(newList.Count, existingList.Count); i++) {
				Launchpad newLaunchPad = null;
				Launchpad existingLaunchPad = null;
				if (newList.Count > -existingList.Count && i < existingList.Count) {
					existingLaunchPad = existingList[i];
				}
				if (newList.Count <= existingList.Count && i < newList.Count) {
					newLaunchPad = newList[i];
				} else if (newList.Count < existingList.Count && i >= newList.Count) {
					existingLaunchPad.Port.ShutDown();
					existingLaunchPad.Thread.Abort();
					existingLaunchPad.Thread = null;
					existingLaunchPad.Port = null;
				}
				if (newLaunchPad != null && existingLaunchPad != null) {
					existingLaunchPad.FrameData.Clear();
					existingLaunchPad.FrameData.AddRange(newLaunchPad.FrameData);
					newLaunchPad = existingLaunchPad;
				}
			}
			return newList;
		}
		private void SaveFileDialog(string filePath, List<Launchpad> padData) {
			SongIO.SaveFile(filePath, padData, axWindowsMediaPlayer1.MediaPath);
		}

		private void openDisplayFileButton_Click(object sender, EventArgs e) {
			bool continueWithNewFile = true;
			bool saveDeniedOrDone = false;
			_changed = false;
			if (launchPads[0].FrameData.Count > 0 && _changed) {

				while (!saveDeniedOrDone) {
					switch (MessageBox.Show("You have unsaved changes. Would you like to save them?", "Song Illustrator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)) {
						case DialogResult.Yes:
							if (Save() == DialogResult.OK) {
								saveDeniedOrDone = true;
							}
							break;
						case DialogResult.No:
							saveDeniedOrDone = true;
							break;
						case DialogResult.Cancel:
							saveDeniedOrDone = true;
							continueWithNewFile = false;
							break;
					}
				}
			}
			if (continueWithNewFile) {
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
				if (dialog.ShowDialog() == DialogResult.OK) {
					OpenFileDialog(dialog.FileName);
					filePath = dialog.FileName;
				}
			}
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
			switch (_frameReferences) {
				case 0:
					_refFrame1 = frameListBox.SelectedItem as FrameData;
					if (frameListBox.SelectedIndex >= 0) {
						frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						axWindowsMediaPlayer1.CurrentPosition = (double) (frameListBox.SelectedItem as FrameData).TimeStamp / 100;
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
						try {
							frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						} catch {
						}
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

		private void new_Click(object sender, EventArgs e) {
			bool continueWithNewFile = true;
			bool saveDeniedOrDone = false;
			_changed = false;
			if (launchPads[0].FrameData.Count > 0 && _changed) {

				while (!saveDeniedOrDone) {
					switch (MessageBox.Show("You have unsaved changes. Would you like to save them?", "Song Illustrator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)) {
						case DialogResult.Yes:
							if (Save() == DialogResult.OK) {
								saveDeniedOrDone = true;
							}
							break;
						case DialogResult.No:
							saveDeniedOrDone = true;
							break;
						case DialogResult.Cancel:
							saveDeniedOrDone = true;
							continueWithNewFile = false;
							break;
					}
				}
			}
			if (continueWithNewFile) {
				for (int i = 0; i < launchPads.Count; i++) {
					launchPads[i].FrameData.Clear();
					(panel1.Controls[i] as LightPad).LightData.FrameData.Clear();
				}
				frameListBox.Items.Clear();
				axWindowsMediaPlayer1.MediaPath = "";
				pixelBar.Enabled = true;
				UpdateFrames();
			}
		}

		private void deleteButton_DoubleClick(object sender, EventArgs e) {

		}

		private void deleteButton_Click(object sender, EventArgs e) {
			_changed = true;
			if (MessageBox.Show("Are you sure you want to delete these frames? (" + frameListBox.CheckedItems.Count + ")", "Delete Item?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				for (int i = frameListBox.CheckedItems.Count - 1; i >= 0; i--) {
					foreach (Launchpad launchpad in launchPads) {
						launchpad.FrameData.Remove(launchpad.FrameData[(frameListBox.CheckedItems[i] as FrameData).Index]);
					}
					frameListBox.Items.Remove(frameListBox.CheckedItems[i]);
					foreach (LightPad lightPad in panel1.Controls) {
						lightPad.IndexFrames();
					}
					if (frameListBox.Items.Count < 1) {
						pixelBar.Enabled = false;
					}
				}
			}
			UpdateFrames();
		}

		private void deleteButton_Load(object sender, EventArgs e) {

		}

		private void listButton_Load(object sender, EventArgs e) {

		}
		private void OpenPlaylist(string filepath) {
			foreach (Launchpad padData in launchPads) {
				padData.FrameData.Clear();
			}
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
			//GeneratePixels(8);
			if (launchPads.Count < 1) {
				AddLightPad();
			}
			_lowestDivisor = 1;
			GeneratePads(launchPads, panel1);
			axWindowsMediaPlayer1 = MediaPlayerLoader.LoadMediaPlayer(""); 
			(axWindowsMediaPlayer1 as Control).Dock = System.Windows.Forms.DockStyle.Bottom;
			(axWindowsMediaPlayer1 as Control).Location = new System.Drawing.Point(0, 607);
			(axWindowsMediaPlayer1 as Control).Name = "panel2";
			(axWindowsMediaPlayer1 as Control).Size = new System.Drawing.Size(684, 55);
			(axWindowsMediaPlayer1 as Control).TabIndex = 92;
			axWindowsMediaPlayer1.DonePlaying += new EventHandler(axWindowsMediaPlayer1_DonePlaying);
			axWindowsMediaPlayer1.Paused += new EventHandler(axWindowsMediaPlayer1_Paused);
			axWindowsMediaPlayer1.Playing += new EventHandler(axWindowsMediaPlayer1_Playing);
			axWindowsMediaPlayer1.Ready += new EventHandler(axWindowsMediaPlayer1_Ready);
			axWindowsMediaPlayer1.Stopped += new EventHandler(axWindowsMediaPlayer1_Stopped);
			Controls.Add(axWindowsMediaPlayer1 as Control);
		}

		void axWindowsMediaPlayer1_Stopped(object sender, EventArgs e) {
			if (gotPlay) {
				gotPlay = false;
				timer1.Stop();
				stopwatch.Stop();
				foreach (Launchpad launchPad in launchPads) {
					launchPad.ListenToMidi = false;
				}
			}
		}

		void axWindowsMediaPlayer1_Ready(object sender, EventArgs e) {
			try {
				axWindowsMediaPlayer1.Play();
			} catch {
			}
		}

		void axWindowsMediaPlayer1_Playing(object sender, EventArgs e) {
			timer1.Start();
			stopwatch.Start();
			foreach (Launchpad launchPad in launchPads) {
				launchPad.ListenToMidi = false;
			}
			gotPlay = true;
		}

		void axWindowsMediaPlayer1_Paused(object sender, EventArgs e) {
			timer1.Stop();
			stopwatch.Stop();
			foreach (Launchpad launchPad in launchPads) {
				launchPad.ListenToMidi = true;
			}
		}

		void axWindowsMediaPlayer1_DonePlaying(object sender, EventArgs e) {
			if (gotPlay) {
				if (playlist.Count > 1) {
					if (playlistPosition < playlist.Count) {
						try {
							OpenFileDialog(playlist[playlistPosition++]);
						} catch {

						}
					}
				}
			}
		}

		private void AddLightPad() {
			Launchpad lightData = new Launchpad();
			lightData.Density = 8;
			launchPads.Add(lightData);
		}
		public void GeneratePads(List<Launchpad> lightDataList, Control control) {
			if (lightDataList.Count > _lowestDivisor * _lowestDivisor) {
				_lowestDivisor++;
			}
			int widthHeight = control.Height / _lowestDivisor;
			int widthProgression = 0;
			int heightProgression = 0;
			for (int i = 0; i < lightDataList.Count; i++) {
				LightPad lightPad = new LightPad();
				if (lightDataList[i].Port == null) {
					lightDataList[i].Port = MidiDriverLoader.LoadCoreMIDI("Virtual Launchpad " + (i + 1));
				}
				if (i > panel1.Controls.Count) {
					(panel1.Controls[i] as LightPad).Port = lightDataList[i].Port;
				}
				lightPad.LightData = lightDataList[i];
				lightPad.Index = i;
				lightPad.Display = display;
				lightPad.Size = new Size(widthHeight, widthHeight);
				lightPad.GotInteraction += delegate {
					lightPad.ReplaceFrame(frameListBox.SelectedIndex);
				};
				if (widthProgression >= _lowestDivisor) {
					heightProgression++;
					widthProgression = 0;
				}
				lightPad.Location = new Point(lightPad.Size.Height * widthProgression++, lightPad.Size.Height * heightProgression);
				control.Controls.Add(lightPad);
				if (_overlayImage != null) {
					CheckImage();
				}
			}
		}

		private int GetLowestDivisor(int number) {
			int result = 0;
			for (int i = number; i > 0; i--) {
				if (number % i == 0) {
					if (i > 1) {
						result = i;
					}
				}
			}
			return result;
		}

		private void displayButton66_Click(object sender, EventArgs e) {
			display.Creator = this;
			display.ShowDialog();
		}

		private void openDisplayFileButton_Load(object sender, EventArgs e) {

		}

		private void displayButton1_Click_1(object sender, EventArgs e) {

		}

		private void displayButton2_Click(object sender, EventArgs e) {
			//Sync Button.
			_changed = true;
			if (MessageBox.Show("Are you sure you want to syncronize frames? It will re-increment the selected frames based on a delay of " + textBox2.Text + ".", "Song Illustrator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
				int frameIndex = 0;
				List<FrameData> frameTimes = new List<FrameData>();
				foreach (FrameData item in frameListBox.CheckedItems) {
					frameTimes.Add(item);
				}
				foreach (Launchpad launchPad in launchPads) {
					launchPad.SyncFrames(decimal.Parse(textBox2.Text), frameTimes);
				}
			}
			UpdateFrames();
		}

		private void imageButton_Click(object sender, EventArgs e) {
			ImageList imagelist = new ImageList();
			OpenFileDialog dialog = new OpenFileDialog();
			List<List<DisplayButton>> displayButtonsList = new List<List<DisplayButton>>();
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				using (FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read)) {
					OverlayImage = new MemoryStream();
					stream.CopyTo(OverlayImage);
					stream.CopyTo(display.OverlayImage);
					foreach (LightPad launchPad in panel1.Controls) {
						List<DisplayButton> displayButtons = new List<DisplayButton>();
						foreach (DisplayButton displayButton in launchPad.LightCanvas.Controls) {
							displayButtons.Add(displayButton);
						}
						displayButtonsList.Add(displayButtons);
					}
					OverlayButtons(OverlayImage, displayButtonsList);
				}
			}
		}
		public void OverlayButtons(Stream bitmapStream, List<DisplayButton> controls) {
			List<Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.Size, new Size(pixelBar.Value, pixelBar.Value));
			for (int i = 0; i < controls.Count; i++) {
				controls[i].BackgroundImage = images[i];
			}
		}

		public void OverlayButtons(Stream bitmapStream, List<List<DisplayButton>> controls) {
			List<Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.Size, new Size(_lowestDivisor, _lowestDivisor));
			for (int i = 0; i < controls.Count; i++) {
				Stream imageStream = new MemoryStream();
				images[i].Save(imageStream, ImageFormat.Png);
				OverlayButtons(imageStream, controls[i]);
			}
		}

		private void Form1_Resize(object sender, EventArgs e) {
			timeline1.UpdateTimeline();
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

		private void shiftButton_Click(object sender, EventArgs e) {
			//Shift Button.
			_changed = true;
			if (frameListBox.CheckedItems.Count > 0) {
				if (MessageBox.Show("Are you sure you want to shift the frames? It will place the selected frames starting from " + textBox1.Text + "ms.", "Song Illustrator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
					if (!string.IsNullOrEmpty(textBox1.Text)) {
						try {
							decimal baseStamp = decimal.Parse(textBox1.Text);
							List<FrameData> frameTimes = new List<FrameData>();
							foreach (FrameData item in frameListBox.CheckedItems) {
								frameTimes.Add(item);
							}
							foreach (Launchpad launchPad in launchPads) {
								launchPad.ShiftFrames(decimal.Parse(textBox1.Text), frameTimes);
							}
							UpdateFrames();
						} catch {
							MessageBox.Show("Invalid number!", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					} else {
						MessageBox.Show("Can't shift frames by an empty value!", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			} else {
				MessageBox.Show("You haven't checked off any frames to shift!", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			foreach (LightPad launchpad in panel1.Controls) {
				launchpad.Port.ShutDown();
				launchpad.LightData.Thread.Abort();
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void toMIDIToolStripMenuItem_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				ExportMidi(padData.FrameData);
			}
		}
		private DialogResult ExportMidi(List<FrameData> midiFrames) {
#if DEBUG
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				MidiIO.WriteMidi(dialog.FileName, midiFrames, 120, 480);
				return DialogResult.OK;
			} else {
				return DialogResult.Cancel;
			}
#else
			MessageBox.Show("Incomplete Feature", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return DialogResult.Cancel;
#endif
		}

		private void toMIDIToolStripMenuItem1_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				if (ExportMidi(padData.FrameData) != DialogResult.OK) {
					break;
				}
			}
		}

		private void controlEditorToolStripMenuItem_Click(object sender, EventArgs e) {
			passiveMode = !passiveMode;
			if (passiveMode) {
				controlEditorToolStripMenuItem.Text = "Enable Passive Mode";
			} else {
				controlEditorToolStripMenuItem.Text = "Disable Passive Mode";
			}
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e) {
			passiveMode = false;
		}

		public void addLaunchpadToolStripMenuItem_Click(object sender, EventArgs e) {
			if (launchPads[0].FrameData.Count < 1) {
				AddLightPad();
				panel1.Controls.Clear();
				display.Creator = this;
				GeneratePads(launchPads, panel1);
			} else {
				MessageBox.Show("Cannot add Launchpads once frames have been added.", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveAs();
		}

		private void SaveAs() {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			if (dialog.ShowDialog() == DialogResult.OK) {
				SaveFileDialog(dialog.FileName, launchPads);
				filePath = dialog.FileName;
				_changed = false;
			}
		}

		private void removeLaunchpadToolStripMenuItem_Click(object sender, EventArgs e) {
			if (launchPads.Count > 1) {
				if (frameListBox.Items.Count <= 0) {
					panel1.Controls.Clear();
					_lowestDivisor--;
					launchPads[launchPads.Count - 1].Port.ShutDown();
					launchPads[launchPads.Count - 1].ListenToMidi = false;
					launchPads[launchPads.Count - 1].FrameData = null;
					launchPads[launchPads.Count - 1].Thread.Abort();
					launchPads.Remove(launchPads[launchPads.Count - 1]);
					GeneratePads(launchPads, panel1);
				} else {
					MessageBox.Show("Cannot remove Launchpads once frames have been added.", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			} else {
				MessageBox.Show("Cannot remove any more Launchpads.", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void launchpadToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void useWithFLStudioToolStripMenuItem_Click(object sender, EventArgs e) {
			TutorialForm tutForm = new TutorialForm();
			tutForm.TutorialPages = TutorialPage.FLPages();
			tutForm.ShowDialog();
		}

		private void addAFrameToolStripMenuItem_Click(object sender, EventArgs e) {
			FigurePainter figurePainter = new FigurePainter();
			figurePainter.Creator = this;
			figurePainter.TutorialFigures.Add(new TutorialFigure(panel1.Controls, "Create an image on the canvas here by double clicking the virtual buttons."));
			figurePainter.TutorialFigures.Add(new TutorialFigure(addFrameButton, "Once you're done making a frame, click the add frame button."));
			figurePainter.ShowDialog();
		}

		private void changeSpeedToolStripMenuItem_Click(object sender, EventArgs e) {
			FigurePainter figurePainter = new FigurePainter();
			figurePainter.Creator = this;
			figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Check off the frames you want to change the speed on."));
			figurePainter.TutorialFigures.Add(new TutorialFigure(textBox2, "Enter the millsecond delay you want between the selected frames."));
			figurePainter.TutorialFigures.Add(new TutorialFigure(syncButton, "Click the sync button."));
			figurePainter.ShowDialog();
		}

		private void shiftFramesToolStripMenuItem_Click(object sender, EventArgs e) {
			FigurePainter figurePainter = new FigurePainter();
			figurePainter.Creator = this;
			figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Check off the frames you want to shift"));
			figurePainter.TutorialFigures.Add(new TutorialFigure(textBox1, "Enter the millisecond position you want to shift the frames to."));
			figurePainter.TutorialFigures.Add(new TutorialFigure(shiftButton, "Click the shift button."));
			figurePainter.ShowDialog();
		}

		private void deleteFramesToolStripMenuItem_Click(object sender, EventArgs e) {
			FigurePainter figurePainter = new FigurePainter();
			figurePainter.Creator = this;
			figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Check off the frames you want to delete"));
			figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Right click, then click delete"));
			figurePainter.ShowDialog();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			if (launchPads[0].FrameData.Count > 0 && _changed) {
				bool saveDeniedOrDone = false;
				while (!saveDeniedOrDone) {
					if (launchPads[0].FrameData.Count > 0) {
						switch (MessageBox.Show("You have unsaved changes. Would you like to save them?", "Song Illustrator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)) {
							case DialogResult.Yes:
								if (Save() == DialogResult.OK) {
									saveDeniedOrDone = true;
								}
								break;
							case DialogResult.No:
								saveDeniedOrDone = true;
								break;
							case DialogResult.Cancel:
								saveDeniedOrDone = true;
								e.Cancel = true;
								break;
						}
					}
				}
			}
		}

		private void howDoIToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void useWithAbletonToolStripMenuItem_Click(object sender, EventArgs e) {
			TutorialForm tutForm = new TutorialForm();
			tutForm.TutorialPages = TutorialPage.AbletonPages();
			tutForm.ShowDialog();
		}

		private void reverseDuplicateToolStripMenuItem_Click(object sender, EventArgs e) {
			_changed = true;
			List<FrameData> frameTimes = new List<FrameData>();
			foreach (FrameData item in frameListBox.CheckedItems) {
				frameTimes.Add(item);
			}
			foreach (Launchpad launchPad in launchPads) {
				launchPad.ReverseDuplicateFrames(decimal.Parse(textBox2.Text), frameTimes);
			}
			UpdateFrames();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void editCurrentFrameToolStripMenuItem_Click(object sender, EventArgs e) {
			if (launchPads[0].FrameData.Count > 0) {
				LockControls();
				foreach (Launchpad launchpad in launchPads) {
					launchpad.EditMode = true;
				}
			} else {
				MessageBox.Show("No frames to edit!", "Song Illustrator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void UnlockControls() {
			frameListBox.Enabled
				= textBox1.Enabled
				= textBox2.Enabled
				= addFrameButton.Enabled
				= fullscreenButton.Enabled
				= shiftButton.Enabled
				= syncButton.Enabled = true;
			editCurrentFrameToolStripMenuItem.Enabled = true;
			stopEditingCurrentFrameToolStripMenuItem.Enabled = false;
			//axWindowsMediaPlayer1.enabled = true;
		}

		private void LockControls() {
			frameListBox.Enabled
				= textBox1.Enabled
				= textBox2.Enabled
				= addFrameButton.Enabled
				= fullscreenButton.Enabled
				= shiftButton.Enabled
				= syncButton.Enabled = false;
			editCurrentFrameToolStripMenuItem.Enabled = false;
			stopEditingCurrentFrameToolStripMenuItem.Enabled = true;
			//axWindowsMediaPlayer1.Ctlenabled = false;
		}

		private void stopEditingCurrentFrameToolStripMenuItem_Click(object sender, EventArgs e) {
			UnlockControls();
			foreach (Launchpad launchpad in launchPads) {
				launchpad.EditMode = false;
			}
		}
	}
}