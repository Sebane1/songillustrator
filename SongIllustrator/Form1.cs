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
		int _portCount = 0;

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
			for (int i = 0; i < launchPads.Count; i++) {
				decimal currentPos = (decimal) axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
				for (int z = 0; z < launchPads[i].FrameData.Count; z++) {
					FrameData time = launchPads[i].FrameData[z];
					if (currentPos * 100 <= time.TimeStamp) {
						time.Fired = false;
					}
					if (currentPos * 100 >= time.TimeStamp) {
						if (!time.Fired) {
							frameLabel.Text = "Frame: " + time.TimeStamp;
							(panel1.Controls[i] as LightPad).SetFrame(z);
							time.Fired = true;
						}
					}
				}
			}
		}

		private void button39_Click(object sender, EventArgs e) {
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
				data.Index = launchPads[i].FrameData.Count - 1;
				launchPads[i].FrameData.Add(data);
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
			for (int i = 0; i < panel1.Controls.Count; i++) {
				(panel1.Controls[i] as LightPad).SetFrame(frameListBox.SelectedIndex);
				textBox1.Text = (frameListBox.SelectedItem as FrameData).TimeStamp.ToString();
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
				foreach (Launchpad launchPad in launchPads) {
					launchPad.ListenToMidi = false;
				}
				gotPlay = true;
			}
			if (e.newState == 2) {
				timer1.Stop();
				stopwatch.Stop();
				foreach (Launchpad launchPad in launchPads) {
					launchPad.ListenToMidi = true;
				}
			}
			if (gotPlay) {
				if (e.newState == 1) {
					gotPlay = false;
					timer1.Stop();
					stopwatch.Stop();
					foreach (Launchpad launchPad in launchPads) {
						launchPad.ListenToMidi = false;
					}
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
			foreach (Launchpad launchPad in launchPads) {
				decimal currentCount = 0;
				decimal difference = 0;
				currentCount = launchPad.FrameData[launchPad.FrameData.Count - 1].TimeStamp;
				for (int i = 0; i < frameListBox.CheckedItems.Count; i++) {
					int index = (frameListBox.CheckedItems[i] as FrameData).Index;
					FrameData item = launchPad.FrameData[(index - 1) < 0 ? 0 : (index - 1)];
					FrameData data = new FrameData();
					//	try {
					data.Colours = item.Colours;
					if (i < frameListBox.CheckedItems.Count - 1) {
						FrameData frame2 = (frameListBox.CheckedItems[i + 1] as FrameData);
						difference = frame2.TimeStamp - item.TimeStamp;
					}
					currentCount += difference;
					data.TimeStamp = currentCount;
					launchPad.FrameData.Add(data);
					//	} catch {
					//	MessageBox.Show("Nothing is selected.");
					//}
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
				SaveFileDialog(dialog.FileName, launchPads);
			}
		}
		private void OpenFileDialog(string filepath) {
			_lowestDivisor = 1;
			frameProgress = 0;
			timer1.Stop();
			stopwatch.Stop();
			stopwatch.Reset();
			launchPads.Clear();
			panel1.Controls.Clear();
			pixelBar.Enabled = false;
			using (FileStream openStream = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
				List<Launchpad> padData = SongIO.OpenFile(openStream);
				foreach (Launchpad lightData in padData) {
					LightPad lightPad = new LightPad();
					lightPad.LightData = lightData;
				}
				launchPads = MergeLightPads(padData, launchPads);
				axWindowsMediaPlayer1.URL = SongIO.Url;
			}
			//timeline1.UpdateTimeline();
			GeneratePads(launchPads);
			UpdateFrames();
		}

		private List<Launchpad> MergeLightPads(List<Launchpad> newList, List<Launchpad> existingList) {
			for (int i = 0; i < Math.Max(newList.Count, existingList.Count); i++) {
				Launchpad newLaunchPad = null;
				Launchpad existingLaunchPad = null;
				if (newList.Count < existingList.Count && i < newList.Count) {
					newLaunchPad = newList[i];
				} else if (newList.Count < existingList.Count && i >= newList.Count) {
					existingLaunchPad.Port.shutdown();
					existingLaunchPad.Thread.Abort();
					existingLaunchPad.Thread = null;
					existingLaunchPad.Port = null;
				}
				if (newList.Count > existingList.Count && i < existingList.Count) {
					existingLaunchPad = existingList[i];
				}

				if (newLaunchPad != null && existingLaunchPad != null) {
					newLaunchPad.Port = existingLaunchPad.Port;
					newLaunchPad.ListenToMidi = existingLaunchPad.ListenToMidi;
				}
			}
			return newList;
		}
		private void SaveFileDialog(string filePath, List<Launchpad> padData) {
			SongIO.SaveFile(filePath, padData, axWindowsMediaPlayer1.URL);
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

		private void displayButton65_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				padData.FrameData = new List<FrameData>();
			}
			frameListBox.Items.Clear();
			axWindowsMediaPlayer1.URL = "";
			pixelBar.Enabled = true;
		}

		private void deleteButton_DoubleClick(object sender, EventArgs e) {

		}

		private void deleteButton_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to delete these frames? (" + frameListBox.CheckedItems.Count + ")", "Delete Item?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				for (int i = frameListBox.CheckedItems.Count - 1; i >= 0; i--) {
					foreach (Launchpad launchpad in launchPads) {
						launchpad.FrameData.Remove(launchpad.FrameData[(frameListBox.CheckedItems[i] as FrameData).Index]);
					}
					frameListBox.Items.Remove(frameListBox.CheckedItems[i]);
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
			GeneratePads(launchPads);
		}

		private void AddLightPad() {
			Launchpad lightData = new Launchpad();
			lightData.Density = 8;
			launchPads.Add(lightData);
		}
		private void GeneratePads(List<Launchpad> lightDataList) {
			if (lightDataList.Count > _lowestDivisor * _lowestDivisor) {
				_lowestDivisor++;
			}
			int widthHeight = panel1.Height / _lowestDivisor;
			int widthProgression = 0;
			int heightProgression = 0;
			for (int i = 0; i < lightDataList.Count; i++) {
				LightPad lightPad = new LightPad();
				if (lightDataList[i].Port == null) {
					lightDataList[i].Port = new TeVirtualMIDI("Virtual Launchpad " + (i + 1));
				}
				lightPad.LightData = lightDataList[i];
				lightPad.Size = new Size(widthHeight, widthHeight);
				if (widthProgression >= _lowestDivisor) {
					heightProgression++;
					widthProgression = 0;
				}
				lightPad.Location = new Point(lightPad.Size.Height * widthProgression++, lightPad.Size.Height * heightProgression);
				panel1.Controls.Add(lightPad);
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
		//private void GeneratePixels(int pixels) {
		//  panel1.Controls.Clear();
		//  int arrayPos = 0;
		//  Size buttonSize = new Size(panel1.Width / pixels, panel1.Height / pixels);
		//  for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {

		//    for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
		//      DisplayButton button = new DisplayButton();
		//      button.ArrayPos = arrayPos++;
		//      button.Port = _port;
		//      button.Size = buttonSize;
		//      button.Location = new Point(buttonSize.Width * widthProgression, buttonSize.Height * heightProgression);
		//      panel1.Controls.Add(button);
		//    }
		//  }
		//  if (_overlayImage != null) {
		//    OverlayButtons(_overlayImage, panel1.Controls);
		//  }
		//  if (display.Visible) {
		//    display.Show();
		//    display.GeneratePixels(pixels);
		//  } else {
		//    display.Show();
		//    display.GeneratePixels(pixels);
		//    display.Hide();
		//  }
		//}
		private void displayButton66_Click(object sender, EventArgs e) {
			display.ShowDialog();
		}

		private void openDisplayFileButton_Load(object sender, EventArgs e) {

		}

		private void pixelBar_ValueChanged(object sender, EventArgs e) {
			//display.Pixels = pixelBar.Value;
			//GeneratePixels(pixelBar.Value);
		}

		//private void panel1_SizeChanged(object sender, EventArgs e) {
		//  List<Color> colours = new List<Color>();
		//  foreach (DisplayButton button in panel1.Controls) {
		//    colours.Add(button.BackColor);
		//  }
		//  panel1.Width = this.Width - 140;
		//  GeneratePixels(pixelBar.Value);
		//  for (int i = 0; i < colours.Count; i++) {
		//    panel1.Controls[i].BackColor = colours[i];
		//  }
		//}

		private void displayButton1_Click_1(object sender, EventArgs e) {

		}

		private void displayButton2_Click(object sender, EventArgs e) {
			//Sync Button.
			if (MessageBox.Show("Are you sure you want to syncronize frames? It will re-increment the selected frames based on a delay of " + textBox2.Text + ".", "Song Illustrator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
				int frameIndex = 0;
				List<FrameData> tempFrames = new List<FrameData>();
				FrameData data = new FrameData();
				try {
					data.TimeStamp = (frameListBox.CheckedItems[0] as FrameData).TimeStamp - decimal.Parse(textBox2.Text);
				} catch {
				}
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
			//_thread = new Thread(new ThreadStart(MidiDataCoordinator));
			//_thread.Start();

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

		//private void MidiDataCoordinator() {
		//  while (true) {
		//    if (_listenToMidi) {
		//      byte[] command = _port.getCommand();
		//      if (command.Length >= 3) {
		//        int process = command[0];
		//        int key = command[1];
		//        int velocity = command[2];
		//        string note = NoteIdentifier.GetNoteFromInt(key);
		//        int notePos = NoteIdentifier.GetNotePosition(note);
		//        //MessageBox.Show(process + "|" + key + "|" + velocity + "     " + stringCommand);
		//        #region MIDI Logic
		//        switch (process) {
		//          case 128:
		//            DisplayButton button;
		//            if (notePos >= 0) {
		//              Invoke(new MethodInvoker(
		//                delegate() {
		//                  if (display.Visible == false) {
		//                    button = (DisplayButton) panel1.Controls[NoteIdentifier.GetNotePosition(note)];
		//                  } else {
		//                    button = (DisplayButton) display.PadLights.Controls[NoteIdentifier.GetNotePosition(note)];
		//                  }
		//                  if (!passiveMode) {
		//                    button.Reset();
		//                    button.CanSendMessage = false;
		//                  } else {
		//                    if (velocity == 64) {
		//                      button.CanSendMessage = true;
		//                      button.ChangeColor();
		//                      button.SendMessage();
		//                    }
		//                  }
		//                }));
		//            }
		//            break;
		//          case 144:
		//            if (notePos >= 0) {
		//              Invoke(new MethodInvoker(
		//                delegate() {
		//                  button = panel1.Controls[notePos] as DisplayButton;
		//                  if (display.Visible == false) {
		//                    button = (DisplayButton) panel1.Controls[NoteIdentifier.GetNotePosition(note)];
		//                  } else {
		//                    button = (DisplayButton) display.PadLights.Controls[NoteIdentifier.GetNotePosition(note)];
		//                  }
		//                  switch (velocity) {
		//                    case 7:
		//                      button.BackColor = Color.Red;
		//                      break;
		//                    case 83:
		//                      button.BackColor = Color.Orange;
		//                      break;
		//                    case 124:
		//                      button.BackColor = Color.Green;
		//                      break;
		//                    case 127:
		//                      button.BackColor = Color.Yellow;
		//                      break;
		//                  }
		//                }));
		//            }
		//            break;
		//        }
		//      }
		//        #endregion MIDI Logic
		//    } else {
		//      _port.getCommand();
		//    }
		//  }
		//}
		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

		private void midiCheck_Tick(object sender, EventArgs e) {
			//MidiDataCoordinator();
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
			//_thread.Abort();
			//_port.shutdown();
		}

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void toMIDIToolStripMenuItem_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				ExportMidi(padData.FrameData);
			}
		}

		private void ExportMidi(List<FrameData> midiFrames) {
			SaveFileDialog dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				MidiIO.WriteMidi(dialog.FileName, midiFrames, 120, 4);
			}
		}

		private void toMIDIToolStripMenuItem1_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				ExportMidi(padData.FrameData);
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

		private void addLaunchpadToolStripMenuItem_Click(object sender, EventArgs e) {
			AddLightPad();
			panel1.Controls.Clear();
			GeneratePads(launchPads);
		}
	}
}
