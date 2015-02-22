using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TypingConnector;
using MediaPlayerModuleBase;
using ControlFactory;

namespace SongIllustrator {
	public partial class MainForm {
		int currentFrame = 0;
		//-------------------------------------------------------
		public MainForm() {
			InitializeComponent();
		}
		//-------------------------------------------------------
		Timer _timer;
		IMediaPlayer mediaPlayer;
		private Stream _overlayImage;
		int _portCount = 0;
		string filePath = "";
		bool _changed = true;
		//-------------------------------------------------------
		public bool Changed {
			get {
				return _changed;
			}
			set {
				_changed = value;
			}
		}
		//-------------------------------------------------------
		public Stream OverlayImage {
			get {
				return _overlayImage;
			}
			set {
				_overlayImage = value;
				//display.OverlayImage = _overlayImage;
			}
		}
		//-------------------------------------------------------
		public IArrayView FrameList {
			get {
				return frameListBox;
			}
			set {
				frameListBox = value;
			}
		}
		//-------------------------------------------------------
		private FrameData _refFrame1;
		private FrameData _refFrame2;
		int _frameReferences = 0;
		private const int SysExBufferSize = 128;


		private SynchronizationContext context;
		//-------------------------------------------------------
		public MainForm(string filename) {
			InitializeComponent();
			if (filename != null) {
				if (filename.Length > 0) {
					OpenFileDialog(filename);
				}
			}
		}
		//-------------------------------------------------------
		public MainForm(IFactory globalSongIllustratorWin32Factory) {
			this._factory = globalSongIllustratorWin32Factory;
			InitializeComponent();
			AddLightPad();
			_formView = _factory.BuildFormView();
			if (_factory.GetType() != typeof(DummyFactory)) {
				_formView.MenuStrip = menuStrip1;
				_formView.AddRange(_viewItems);
				_formView.ControlWidth = 700;
				_formView.ControlHeight = 700;
				if (launchPads.Count < 1) {
					AddLightPad();
				}
				_lowestDivisor = 1;
				GeneratePads(launchPads, panel1);
				mediaPlayer = _factory.BuildMediaPlayer(_formView);
				mediaPlayer.ControlLocation = new ControlLocation(0, 607);
				mediaPlayer.ControlSize = new ControlSize(684, 55);
				mediaPlayer.TabIndex = 92;
				mediaPlayer.DonePlaying += new EventHandler(axWindowsMediaPlayer1_DonePlaying);
				mediaPlayer.Paused += new EventHandler(axWindowsMediaPlayer1_Paused);
				mediaPlayer.Playing += new EventHandler(axWindowsMediaPlayer1_Playing);
				mediaPlayer.Ready += new EventHandler(axWindowsMediaPlayer1_Ready);
				mediaPlayer.Stopped += new EventHandler(axWindowsMediaPlayer1_Stopped);
				frameListBox.ContextMenu = contextMenuStrip1;
				_formView.Add(mediaPlayer);
				_timer = new Timer(new TimerCallback(CheckFrames), new object(), 1, 1);
				_formView.ShowDialog();
			}
		}
		//-------------------------------------------------------
		int frameProgress = 0;
		int playlistPosition = 1;
		bool gotPlay = false;
		List<string> playlist = new List<string>();
		Stopwatch stopwatch = new Stopwatch();
		List<Launchpad> launchPads = new List<Launchpad>();
		private bool _shiftDown;
		private bool passiveMode = true;
		private int _lowestDivisor = 1;
		private bool shiftDown;
		//-------------------------------------------------------
		private void CheckImage() {
			List<List<MacroButton>> displayButtonsList = new List<List<MacroButton>>();
			foreach (LightPad launchPad in panel1.ViewList.Values) {
				List<MacroButton> displayButtons = new List<MacroButton>();
				foreach (MacroButton displayButton in launchPad.LightCanvas.ViewList.Values) {
					displayButtons.Add(displayButton);
				}
				displayButtonsList.Add(displayButtons);
			}
			if (displayButtonsList.Count > 0) {
				OverlayButtons(_overlayImage, displayButtonsList);
			}
		}
		//-------------------------------------------------------
		public List<Launchpad> LaunchPads {
			get {
				return launchPads;
			}
			set {
				launchPads = value;
			}
		}
		//-------------------------------------------------------
		public bool FormControlEditor {
			get {
				return passiveMode;
			}
			set {
				passiveMode = value;
			}
		}
		//-------------------------------------------------------

		public IPanelView Canvas {
			get {
				return panel1;
			}
			set {
				panel1 = value;
			}
		}
		//-------------------------------------------------------
		public string Timestamp {
			get {
				return textBox1.Text;
			}
			set {
				textBox1.Text = value;
			}
		}
		//-------------------------------------------------------
		public int Density {
			get {
				return pixelBar.Value;
			}
			set {
				pixelBar.Value = value;
			}
		}
		//-------------------------------------------------------
		private void button38_Click(object sender, EventArgs e) {
		}
		//-------------------------------------------------------
		private void refreshButton_Click(object sender, EventArgs e) {
			UpdateFrames();
		}
		//-------------------------------------------------------
		private void NoteToButton(string note) {

		}
		//-------------------------------------------------------
		private void pauseButton_Click(object sender, EventArgs e) {
			stopwatch.Stop();
		}
		//-------------------------------------------------------
		private void stopButton_Click(object sender, EventArgs e) {
			//timer1.Stop();
			stopwatch.Reset();
		}
		//-------------------------------------------------------
		private void CheckFrames(object something) {
			try {
				if (_playing) {
					for (int i = 0; i < launchPads.Count; i++) {
						decimal currentPos = (decimal) mediaPlayer.CurrentPosition;
						lock (launchPads) {
							for (int z = 0; z < launchPads[i].FrameData.Count; z++) {
								FrameData time = launchPads[i].FrameData[z];
								if (currentPos * 100 <= time.TimeStamp) {
									time.Fired = false;
								}
								if (currentPos * 100 >= time.TimeStamp) {
									if (!time.Fired) {
										if (frameLabel != null) {
											frameLabel.Text = "Frame: " + time.Index;
										}
										if (panel1.Count > 0) {
											(panel1.ViewList[i] as LightPad).SetFrame(z);
										}
										//if (display.Canvas.ViewItems.Count > 0) {
										//  LightPad pad = (display.Canvas.ViewItems[i] as LightPad);
										//  if (pad != null) {
										//    pad.SetFrame(z);
										//  }
										//}
										time.Fired = true;
									}
								}
							}
						}
					}
				}
			} catch {
				_timer = _timer;
			}
		}
		//-------------------------------------------------------
		private void addFrameButton_Click(object sender, EventArgs e) {
			_changed = true;
			for (int i = 0; i < launchPads.Count; i++) {
				launchPads[i].AddFrame(decimal.Parse(textBox2.Text), panel1.ViewList[i] as LightPad);
			}
			UpdateFrames();

		}
		//-------------------------------------------------------
		private void UpdateFrames() {
			frameListBox.Clear();
			for (int i = 0; i < launchPads.Count; i++) {
				launchPads[i].FrameData.Sort(delegate(FrameData data1, FrameData data2) {
					return (int) data1.Index - (int) data2.Index;
				});
			}
			if (launchPads.Count > 0) {
				foreach (FrameData frame in launchPads[0].FrameData) {
					frameListBox.Add(frame);
				}
			}
			if (frameListBox.ControlItems.Count > 0) {
				pixelBar.Enabled = false;
			}
			//timeline1.UpdateTimeline();
		}
		//-------------------------------------------------------
		private void checkedListBox1_Click(object sender, EventArgs e) {
			_changed = true;
			for (int i = 0; i < panel1.Count; i++) {
				(panel1.ViewList[i] as LightPad).SetFrame(frameListBox.SelectedIndex);
				FrameData item = (frameListBox.SelectedItem as FrameData);
				if (item != null && frameLabel != null) {
					frameLabel.Text = "Frame " + item.Index;
					textBox1.Text = item.TimeStamp.ToString();
				}
			}
		}
		//-------------------------------------------------------
		private void songButton_Click(object sender, EventArgs e) {
			_changed = true;
			OpenFileDialogView dialog = _factory.BuildOpenFileDialog();
			if (dialog.ShowDialog() == PopupResult.Ok) {
				mediaPlayer.MediaPath = dialog.FileName;
			}
		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void saveButton_Click(object sender, EventArgs e) {
			Save();
		}
		//-------------------------------------------------------
		private PopupResult Save() {
			SaveFileDialogView dialog = _factory.BuildSaveDialog();
			dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			if (string.IsNullOrEmpty(filePath)) {
				if (dialog.ShowDialog() == PopupResult.Ok) {
					SaveFileDialog(dialog.FileName, launchPads);
					filePath = dialog.FileName;
					_changed = false;
					return PopupResult.Ok;
				}
			} else {
				_changed = false;
				SaveFileDialog(filePath, launchPads);
				return PopupResult.Ok;
			}
			return PopupResult.None;
		}
		//-------------------------------------------------------
		private void OpenFileDialog(string filepath) {
			int oldCount = launchPads.Count;
			int newCount = 0;
			_lowestDivisor = 1;
			frameProgress = 0;
			//timer1.Stop();
			stopwatch.Stop();
			stopwatch.Reset();
			pixelBar.Enabled = false;
			using (FileStream openStream = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
				List<Launchpad> padData = SongIO.OpenFile(openStream);
				foreach (Launchpad lightData in padData) {
					LightPad lightPad = new LightPad(_factory, _formView, new ControlSize(panel1.ControlWidth / _lowestDivisor, panel1.ControlHeight / _lowestDivisor), panel1.ControlLocation);
					lightPad.LightData = lightData;
				}
				newCount = padData.Count;
				launchPads = MergeLightPads(padData, launchPads);
				mediaPlayer.MediaPath = SongIO.Url;
			}
			//timeline1.UpdateTimeline();
			if (oldCount != newCount) {
				//panel1.Clear();
				GeneratePads(launchPads, panel1);
			} else {
				OverWritePadFrame(launchPads, panel1);
			}
			UpdateFrames();
		}
		//-------------------------------------------------------
		private void OverWritePadFrame(List<Launchpad> launchPads, IPanelView panel1) {
			for (int i = 0; i < panel1.Count; i++) {
				(panel1.ViewList[i] as LightPad).LightData.FrameData = launchPads[i].FrameData;
			}
		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void SaveFileDialog(string filePath, List<Launchpad> padData) {
			SongIO.SaveFile(filePath, padData, mediaPlayer.MediaPath);
		}
		//-------------------------------------------------------
		private void openDisplayFileButton_Click(object sender, EventArgs e) {
			bool continueWithNewFile = true;
			bool saveDeniedOrDone = false;
			_changed = false;
			if (launchPads[0].FrameData.Count > 0 && _changed) {

				while (!saveDeniedOrDone) {
					switch (Alert.Send("You have unsaved changes. Would you like to save them?", "Song Illustrator", TypeOfAlert.Information, AlertButtons.YesNoCancel, _factory)) {
						case PopupResult.Yes:
							if (Save() == PopupResult.Ok) {
								saveDeniedOrDone = true;
							}
							break;
						case PopupResult.No:
							saveDeniedOrDone = true;
							break;
						case PopupResult.Cancel:
							saveDeniedOrDone = true;
							continueWithNewFile = false;
							break;
					}
				}
			}
			if (continueWithNewFile) {
				OpenFileDialogView dialog = _factory.BuildOpenFileDialog();
				dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
				if (dialog.ShowDialog() == PopupResult.Ok) {
					OpenFileDialog(dialog.FileName);
					filePath = dialog.FileName;
				}
			}
		}
		//-------------------------------------------------------
		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
			switch (_frameReferences) {
				case 0:
					_refFrame1 = frameListBox.SelectedItem as FrameData;
					if (frameListBox.SelectedIndex >= 0) {
						//frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						mediaPlayer.CurrentPosition = (double) (frameListBox.SelectedItem as FrameData).TimeStamp / 100;
					}
					_frameReferences++;
					break;
				case 1:
					if (_shiftDown) {
						_refFrame2 = frameListBox.SelectedItem as FrameData;
						for (int i = 0; i < frameListBox.ControlItems.Count; i++) {
							FrameData item = frameListBox.ControlItems[i] as FrameData;
							if (_refFrame2 != null) {
								if (item.TimeStamp >= _refFrame1.TimeStamp && item.TimeStamp <= _refFrame2.TimeStamp) {
									//frameListBox.SetItemChecked(i, true);
								}
							}
						}
						try {
							//frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						} catch {
						}
					} else {
						_refFrame1 = frameListBox.SelectedItem as FrameData;
						if (frameListBox.SelectedIndex != -1) {
							//frameListBox.SetItemChecked(frameListBox.SelectedIndex, true);
						}
					}
					break;
			}
		}
		//-------------------------------------------------------
		//private void Form1_KeyDown(object sender, KeyEventArgs e) {
		//  if (e.KeyCode == Keys.Shift) {
		//    shiftDown = true;
		//    foreach (MacroButton _button in panel1.ViewItems) {
		//      _button.ShiftDown = true;
		//    }
		//  }
		//}
		//-------------------------------------------------------
		//private void Form1_KeyUp(object sender, KeyEventArgs e) {
		//  foreach (MacroButton _button in panel1.ViewItems) {
		//    _button.ShiftDown = false;
		//  }
		//}
		//-------------------------------------------------------
		private void button39_Load(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void new_Click(object sender, EventArgs e) {
			bool continueWithNewFile = true;
			bool saveDeniedOrDone = false;
			_changed = false;
			if (launchPads[0].FrameData.Count > 0 && _changed) {
				while (!saveDeniedOrDone) {
					switch (Alert.Send("You have unsaved changes. Would you like to save them?", "Song Illustrator", TypeOfAlert.Information, AlertButtons.YesNoCancel, _factory)) {
						case PopupResult.Yes:
							if (Save() == PopupResult.Ok) {
								saveDeniedOrDone = true;
							}
							break;
						case PopupResult.No:
							saveDeniedOrDone = true;
							break;
						case PopupResult.Cancel:
							saveDeniedOrDone = true;
							continueWithNewFile = false;
							break;
					}
				}
			}
			if (continueWithNewFile) {
				for (int i = 0; i < launchPads.Count; i++) {
					launchPads[i].FrameData.Clear();
					(panel1.ViewList[i] as LightPad).LightData.FrameData.Clear();
				}
				frameListBox.ControlItems.Clear();
				mediaPlayer.MediaPath = "";
				pixelBar.Enabled = true;
				UpdateFrames();
			}
		}
		//-------------------------------------------------------
		private void deleteButton_DoubleClick(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void deleteButton_Click(object sender, EventArgs e) {
			_changed = true;
			if (Alert.Send("Are you sure you want to delete these frames? (" + frameListBox.CheckedItems.Count + ")",
				"Delete Item?",
				TypeOfAlert.Information,
				AlertButtons.YesNo,
				_factory) == PopupResult.Yes) {
				for (int i = frameListBox.CheckedItems.Count - 1; i >= 0; i--) {
					foreach (Launchpad launchpad in launchPads) {
						try {
							launchpad.FrameData.Remove(launchpad.FrameData[(frameListBox.CheckedItems[i] as FrameData).Index]);
						} catch {
							object failed = new object();
						}
					}
					frameListBox.Remove((frameListBox.CheckedItems[i] as FrameData).Index);
					foreach (LightPad lightPad in panel1.ViewList.Values) {
						lightPad.IndexFrames();
					}
					if (frameListBox.ControlItems.Count < 1) {
						pixelBar.Enabled = false;
					}
				}
			}
			UpdateFrames();
		}
		//-------------------------------------------------------
		private void deleteButton_Load(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void listButton_Load(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void listButton_Click(object sender, EventArgs e) {
			OpenFileDialogView dialog = _factory.BuildOpenFileDialog();
			dialog.Filter = "Song Illustrator Playlist (*.slpl)|*.slpl";
			if (dialog.ShowDialog() == PopupResult.Ok) {
				OpenPlaylist(dialog.FileName);
			}
		}
		//-------------------------------------------------------
		private void createListButton_Click(object sender, EventArgs e) {
			List<string> songList = new List<string>();
			bool loop = true;
			OpenFileDialogView openDialog = _factory.BuildOpenFileDialog();
			openDialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			while (loop) {
				if (openDialog.ShowDialog() == PopupResult.Ok) {
					songList.AddRange(openDialog.FileNames);
				}
				switch (Alert.Send("Would you like to add more display files?", "Create Playlist", TypeOfAlert.Question, AlertButtons.YesNo, _factory)) {
					case PopupResult.No:
						loop = false;
						break;
				}
			}
			SaveFileDialogView saveDialog = _factory.BuildSaveDialog();
			saveDialog.Filter = "Song Illustrator Playlist (*.slpl)|*.slpl";
			if (saveDialog.ShowDialog() == PopupResult.Ok) {
				SavePlaylist(saveDialog.FileName, songList);
			}
		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void Form1_Load(object sender, EventArgs e) {
			//GeneratePixels(8);

		}
		//-------------------------------------------------------
		void axWindowsMediaPlayer1_Stopped(object sender, EventArgs e) {
			if (gotPlay) {
				gotPlay = false;
				_playing = false;
				//timer1.Stop();
				stopwatch.Stop();
				foreach (Launchpad launchPad in launchPads) {
					launchPad.ListenToMidi = false;
				}
			}
		}
		//-------------------------------------------------------
		void axWindowsMediaPlayer1_Ready(object sender, EventArgs e) {
			try {
				mediaPlayer.Play();
			} catch {
			}
		}
		//-------------------------------------------------------
		void axWindowsMediaPlayer1_Playing(object sender, EventArgs e) {
			//timer1.Start();
			stopwatch.Start();
			foreach (Launchpad launchPad in launchPads) {
				launchPad.ListenToMidi = false;
			}
			gotPlay = true;
			_playing = true;
		}
		//-------------------------------------------------------
		void axWindowsMediaPlayer1_Paused(object sender, EventArgs e) {
			//timer1.Stop();
			stopwatch.Stop();
			foreach (Launchpad launchPad in launchPads) {
				launchPad.ListenToMidi = true;
				_playing = false;
			}
		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void AddLightPad() {
			Launchpad lightData = new Launchpad();
			lightData.Density = 8;
			launchPads.Add(lightData);
		}
		public void GeneratePads(List<Launchpad> lightDataList, IPanelView canvas) {
			foreach (LightPad lightPad in canvas.ViewList.Values) {
				lightPad.Destroy();
			}
			panel1.Clear();
			if (lightDataList.Count > _lowestDivisor * _lowestDivisor) {
				_lowestDivisor++;
			}
			int widthHeight = canvas.ControlHeight / _lowestDivisor;
			int widthProgression = 0;
			int heightProgression = 0;
			for (int i = 0; i < lightDataList.Count; i++) {
				LightPad lightPad = new LightPad(_factory, _formView, new ControlSize(widthHeight, widthHeight), panel1.ControlLocation);
				if (lightDataList[i].Port == null) {
					lightDataList[i].Port = MidiDriverLoader.LoadMIDIDriver("Virtual Launchpad " + (i + 1));
				}
				if (i > panel1.Count) {
					(panel1.ViewList[i] as LightPad).Port = lightDataList[i].Port;
				}
				lightPad.LightData = lightDataList[i];
				lightPad.Index = i;
				lightPad.GotInteraction += delegate {
					lightPad.ReplaceFrame(frameListBox.SelectedIndex);
				};
				if (widthProgression >= _lowestDivisor) {
					heightProgression++;
					widthProgression = 0;
				}
				lightPad.ControlLocation = new ControlLocation(widthHeight * widthProgression++, 13 + widthHeight * heightProgression);
				canvas.Add(lightPad);
				if (_overlayImage != null) {
					CheckImage();
				}
				lightPad.Trigger = false;
			}
		}
		public void RescalePads(List<Launchpad> lightDataList, IPanelView canvas) {
			if (lightDataList.Count > _lowestDivisor * _lowestDivisor) {
				_lowestDivisor++;
			}
			int widthHeight = canvas.ControlHeight / _lowestDivisor;
			int widthProgression = 0;
			int heightProgression = 0;
			for (int i = 0; i < lightDataList.Count; i++) {
				LightPad lightPad = canvas.ViewList[i] as LightPad;
				if (widthProgression >= _lowestDivisor) {
					heightProgression++;
					widthProgression = 0;
				}
				lightPad.ControlLocation = new ControlLocation(canvas.ControlLocation.X + (widthHeight * widthProgression++), canvas.ControlLocation.Y + (widthHeight * heightProgression));
				lightPad.ControlSize = new ControlSize(widthHeight, widthHeight);
				lightPad.RescalePixels(8);
			}
		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void fullscreen_Click(object sender, EventArgs e) {
			//display.Creator = this;
			EnableFullScreen();
		}
		//-------------------------------------------------------
		private void openDisplayFileButton_Load(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void displayButton1_Click_1(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void displayButton2_Click(object sender, EventArgs e) {
			//Sync IButtonView.
			_changed = true;
			if (Alert.Send("Are you sure you want to syncronize frames? It will re-increment the selected frames based on a delay of " + textBox2.Text + ".", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.YesNo, _factory) == PopupResult.Yes) {
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
		//-------------------------------------------------------
		private void imageButton_Click(object sender, EventArgs e) {
			//ImageList imagelist = new ImageList();
			//OpenFileDialogView dialog = new OpenFileDialogView();
			//List<List<MacroButton>> displayButtonsList = new List<List<MacroButton>>();
			//if (dialog.ShowDialog() == System.Windows.Forms.PopupResult.OK) {
			//  using (FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read)) {
			//    OverlayImage = new MemoryStream();
			//    stream.CopyTo(OverlayImage);
			//    stream.CopyTo(display.OverlayImage);
			//    foreach (LightPad launchPad in panel1.ViewItems) {
			//      List<MacroButton> displayButtons = new List<MacroButton>();
			//      foreach (MacroButton displayButton in launchPad.LightCanvas.ViewItems) {
			//        displayButtons.Add(displayButton);
			//      }
			//      displayButtonsList.Add(displayButtons);
			//    }
			//    OverlayButtons(OverlayImage, displayButtonsList);
			//  }
			//}
		}
		//-------------------------------------------------------
		public void OverlayButtons(Stream bitmapStream, List<MacroButton> FormControls) {
			//List<MediaTypeNames.Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.ControlSize, new ControlSize(pixelBar.Value, pixelBar.Value));
			//for (int i = 0; i < ViewItems.Count; i++) {
			//  ViewItems[i].BackgroundImage = images[i];
			//}
		}
		//-------------------------------------------------------
		public void OverlayButtons(Stream bitmapStream, List<List<MacroButton>> FormControls) {
			//List<Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.ControlSize, new ControlSize(_lowestDivisor, _lowestDivisor));
			//for (int i = 0; i < ViewItems.Count; i++) {
			//  Stream imageStream = new MemoryStream();
			//  images[i].Save(imageStream, ImageFormat.Png);
			//  OverlayButtons(imageStream, ViewItems[i]);
			//}
		}
		//-------------------------------------------------------
		private void Form1_Resize(object sender, EventArgs e) {
			timeline1.UpdateTimeline();
		}
		//-------------------------------------------------------
		private void checkedListBox1_KeyDown(object sender, EventArgs e) {
			_shiftDown = true;
		}
		//-------------------------------------------------------
		private void checkedListBox1_KeyUp(object sender, EventArgs e) {
			_shiftDown = false;
			_frameReferences = 0;
			_refFrame1 = null;
			_refFrame2 = null;
		}
		//-------------------------------------------------------
		private void shiftButton_Click(object sender, EventArgs e) {
			//Shift IButtonView.
			_changed = true;
			if (frameListBox.CheckedItems.Count > 0) {
				if (Alert.Send("Are you sure you want to shift the frames? It will place the selected frames starting from " + textBox1.Text + "ms.", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.YesNo, _factory) == PopupResult.Yes) {
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
							Alert.Send("Invalid number!", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
						}
					} else {
						Alert.Send("Can't shift frames by an empty value!", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
					}
				}
			} else {
				Alert.Send("You haven't checked off any frames to shift!", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
			}
		}
		//-------------------------------------------------------
		//private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
		//  foreach (LightPad launchpad in panel1.ViewItems) {
		//    launchpad.Port.ShutDown();
		//    launchpad.LightData.Thread.Abort();
		//  }
		//}

		//private void panel1_Paint(object sender, PaintEventArgs e) {

		//}
		//-------------------------------------------------------
		private void toMIDIToolStripMenuItem_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				ExportMidi(padData.FrameData);
			}
		}//-------------------------------------------------------
		private PopupResult ExportMidi(List<FrameData> midiFrames) {
#if DEBUG
			//SaveFileDialogView dialog = new SaveFileDialogView();
			//if (dialog.ShowDialog() == PopupResult.Ok) {
			//  MidiIO.WriteMidi(dialog.FileName, midiFrames, 120, 480);
			//  return PopupResult.Ok;
			//} else {
			//  return PopupResult.Cancel;
			//}
			return PopupResult.None;
#else
			Alert.Send("Incomplete Feature", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
			return PopupResult.Cancel;
#endif
		}
		//-------------------------------------------------------
		private void toMIDIToolStripMenuItem1_Click(object sender, EventArgs e) {
			foreach (Launchpad padData in launchPads) {
				if (ExportMidi(padData.FrameData) != PopupResult.Ok) {
					break;
				}
			}
		}
		//-------------------------------------------------------
		private void FormControlEditorToolStripMenuItem_Click(object sender, EventArgs e) {
			//passiveMode = !passiveMode;
			//if (passiveMode) {
			//  FormControlEditorToolStripMenuItem.Text = "Enable Passive Mode";
			//} else {
			//  FormControlEditorToolStripMenuItem.Text = "Disable Passive Mode";
			//}
		}
		//-------------------------------------------------------
		//private void Form1_MouseDown(object sender, MouseEventArgs e) {
		//  passiveMode = false;
		//}
		//-------------------------------------------------------
		public void addLaunchpadToolStripMenuItem_Click(object sender, EventArgs e) {
			if (launchPads[0].FrameData.Count < 1) {
				AddLightPad();
				GeneratePads(launchPads, panel1);
			} else {
				Alert.Send("Cannot add Launchpads once frames have been added.", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
			}
		}
		//-------------------------------------------------------
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveAs();
		}
		//-------------------------------------------------------
		private void SaveAs() {
			SaveFileDialogView dialog = _factory.BuildSaveDialog();
			dialog.Filter = "Song Illustrator Files (*.slif)|*.slif";
			if (dialog.ShowDialog() == PopupResult.Ok) {
				SaveFileDialog(dialog.FileName, launchPads);
				filePath = dialog.FileName;
				_changed = false;
			}
		}
		//-------------------------------------------------------
		private void removeLaunchpadToolStripMenuItem_Click(object sender, EventArgs e) {
			if (launchPads.Count > 1) {
				if (frameListBox.ControlItems.Count <= 0) {
					_lowestDivisor--;
					launchPads[launchPads.Count - 1].Port.ShutDown();
					launchPads[launchPads.Count - 1].ListenToMidi = false;
					launchPads[launchPads.Count - 1].FrameData = null;
					if (launchPads[launchPads.Count - 1].Thread != null) {
						launchPads[launchPads.Count - 1].Thread.Abort();
					}
					launchPads.Remove(launchPads[launchPads.Count - 1]);
					GeneratePads(launchPads, panel1);
				} else {
					Alert.Send("Cannot remove Launchpads once frames have been added.", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
				}
			} else {
				Alert.Send("Cannot remove any more Launchpads.", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, Factory);
			}
		}
		//-------------------------------------------------------
		private void launchpadToolStripMenuItem_Click(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void useWithFLStudioToolStripMenuItem_Click(object sender, EventArgs e) {
			TutorialForm tutForm = new TutorialForm(_factory);
			tutForm.TutorialPages = TutorialPage.FLPages();
			tutForm.ShowDialog();
		}
		//-------------------------------------------------------
		private void addAFrameToolStripMenuItem_Click(object sender, EventArgs e) {
			//FigurePainter figurePainter = new FigurePainter();
			//figurePainter.Creator = this;
			//figurePainter.TutorialFigures.Add(new TutorialFigure(panel1.ViewItems, "Create an image on the canvas here by double clicking the virtual buttons."));
			//figurePainter.TutorialFigures.Add(new TutorialFigure(addFrameButton, "Once you're done making a frame, click the add frame _button."));
			//figurePainter.ShowDialog();
		}
		//-------------------------------------------------------
		private void changeSpeedToolStripMenuItem_Click(object sender, EventArgs e) {
			//FigurePainter figurePainter = new FigurePainter();
			//figurePainter.Creator = this;
			//figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Check off the frames you want to change the speed on."));
			//figurePainter.TutorialFigures.Add(new TutorialFigure(textBox2, "Enter the millsecond delay you want between the selected frames."));
			//figurePainter.TutorialFigures.Add(new TutorialFigure(syncButton, "Click the sync _button."));
			//figurePainter.ShowDialog();
		}
		//-------------------------------------------------------
		private void shiftFramesToolStripMenuItem_Click(object sender, EventArgs e) {
			//FigurePainter figurePainter = new FigurePainter();
			//figurePainter.Creator = this;
			//figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Check off the frames you want to shift"));
			//figurePainter.TutorialFigures.Add(new TutorialFigure(textBox1, "Enter the millisecond position you want to shift the frames to."));
			//figurePainter.TutorialFigures.Add(new TutorialFigure(shiftButton, "Click the shift _button."));
			//figurePainter.ShowDialog();
		}
		//-------------------------------------------------------
		private void deleteFramesToolStripMenuItem_Click(object sender, EventArgs e) {
			//FigurePainter figurePainter = new FigurePainter();
			//figurePainter.Creator = this;
			//figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Check off the frames you want to delete"));
			//figurePainter.TutorialFigures.Add(new TutorialFigure(frameListBox, "Right click, then click delete"));
			//figurePainter.ShowDialog();
		}
		//-------------------------------------------------------
		private void Form1_FormClosing(object sender, EventArgs e) {
			if (launchPads[0].FrameData.Count > 0 && _changed) {
				bool saveDeniedOrDone = false;
				while (!saveDeniedOrDone) {
					if (launchPads[0].FrameData.Count > 0) {
						switch (Alert.Send("You have unsaved changes. Would you like to save them?", "Song Illustrator", TypeOfAlert.Information, AlertButtons.YesNoCancel, Factory)) {
							case PopupResult.Yes:
								if (Save() == PopupResult.Ok) {
									saveDeniedOrDone = true;
								}
								break;
							case PopupResult.No:
								saveDeniedOrDone = true;
								break;
							case PopupResult.Cancel:
								saveDeniedOrDone = true;
								//e.Cancel = true;
								break;
						}
					}
				}
			}
		}
		//-------------------------------------------------------
		private void howDoIToolStripMenuItem_Click(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void useWithAbletonToolStripMenuItem_Click(object sender, EventArgs e) {
			TutorialForm tutForm = new TutorialForm(_factory);
			tutForm.TutorialPages = TutorialPage.AbletonPages();
			tutForm.ShowDialog();
		}
		//-------------------------------------------------------
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
		//-------------------------------------------------------
		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {

		}
		//-------------------------------------------------------
		private void editCurrentFrameToolStripMenuItem_Click(object sender, EventArgs e) {
			if (launchPads[0].FrameData.Count > 0) {
				LockFormControls();
				foreach (Launchpad launchpad in launchPads) {
					launchpad.EditMode = true;
				}
			} else {
				Alert.Send("No frames to edit!", "Song Illustrator", TypeOfAlert.Warning, AlertButtons.Ok, _factory);
			}
		}
		//-------------------------------------------------------
		private void UnlockFormControls() {
			frameListBox.Enabled
				= textBox1.Enabled
				= textBox2.Enabled
				= addFrameButton.Enabled
				= fullscreenButton.Enabled
				= shiftButton.Enabled
				= syncButton.Enabled = true;
			editCurrentFrameMenuItem.Enabled = true;
			stopEditingCurrentFrameMenuItem.Enabled = false;
			foreach (LightPad lightPad in Canvas.ViewList.Values) {
				lightPad.ReplaceFrame(frameListBox.SelectedIndex);
			}
			mediaPlayer.Enabled = true;
		}
		//-------------------------------------------------------
		private void LockFormControls() {
			frameListBox.Enabled
				= textBox1.Enabled
				= textBox2.Enabled
				= addFrameButton.Enabled
				= fullscreenButton.Enabled
				= shiftButton.Enabled
				= syncButton.Enabled = false;
			editCurrentFrameMenuItem.Enabled = false;
			stopEditingCurrentFrameMenuItem.Enabled = true;
			mediaPlayer.Enabled = false;
		}
		//-------------------------------------------------------
		private void EnableFullScreen() {
			_formView.EnableFullscreen();
			frameListBox.Visible
		= textBox1.Visible
		= textBox2.Visible
		= addFrameButton.Visible
		= fullscreenButton.Visible
		= shiftButton.Visible
		= syncButton.Visible = false;
			menuStrip1.Visible = false;
			mediaPlayer.Visible = false;
			_panelOriginalSize = panel1.ControlSize;
			_panelOriginalLocation = panel1.ControlLocation;
			panel1.ControlSize = new ControlSize((int) ((decimal) _formView.ControlSize.Height * (decimal) 0.9), (int) ((decimal) _formView.ControlSize.Height * (decimal) 0.9));
			panel1.ControlLocation = new ControlLocation((_formView.ControlWidth / 2) - (panel1.ControlWidth / 2), panel1.ControlLocation.Y);
			_formView.Click += delegate {
				DisableFullScreen();
			};
			RescalePads(launchPads, panel1);
		}
		//-------------------------------------------------------
		private void DisableFullScreen() {
			_formView.DisableFullScreen();
			frameListBox.Visible
		= textBox1.Visible
		= textBox2.Visible
		= addFrameButton.Visible
		= fullscreenButton.Visible
		= shiftButton.Visible
		= syncButton.Visible
		= menuStrip1.Visible = true;
			mediaPlayer.Visible = true;
			panel1.ControlSize = _panelOriginalSize;
			panel1.ControlLocation = new SongIllustrator.ControlLocation(_panelOriginalLocation.X, 22);
			RescalePads(launchPads, panel1);
		}
		//-------------------------------------------------------
		private void stopEditingCurrentFrameToolStripMenuItem_Click(object sender, EventArgs e) {
			UnlockFormControls();
			foreach (Launchpad launchpad in launchPads) {
				launchpad.EditMode = false;
			}
		}
		//-------------------------------------------------------
		public event EventHandler Clicked;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;
		//-------------------------------------------------------
		public void Initialize() {
			throw new NotImplementedException();
		}
		//-------------------------------------------------------
		public string Name {
			get {
				return "";
			}
			set {
				string name = value;
			}
		}
		//-------------------------------------------------------
		public ControlSize ControlSize {
			get {
				return _controlSize;
			}
			set {
				_controlSize = value;
			}
		}
		//-------------------------------------------------------
		public ControlLocation ControlLocation {
			get {
				return _controlLocation;
			}
			set {
				_controlLocation = value;
			}
		}
		//-------------------------------------------------------
		public List<IView> ViewItems {
			get {
				return _viewItems;
			}
			set {
				_viewItems = value;
			}
		}
		//-------------------------------------------------------
		private IFactory _factory;
		//-------------------------------------------------------
		public IFactory Factory {
			get {
				return _factory;
			}
			set {
				_factory = value;
			}
		}
		//-------------------------------------------------------
		#region IFormView Members

		public void ShowDialog() {
			throw new NotImplementedException();
		}

		#endregion
		public event EventHandler BackColorChanged;
		private List<IView> _viewItems = new List<IView>();
		private string _text;
		private EventHandler Loading;
		private ControlLocation _controlLocation = new ControlLocation(0, 0);
		private ControlSize _controlSize = new ControlSize(700, 600);
		//-------------------------------------------------------
		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		//-------------------------------------------------------
		public event EventHandler Click;
		//-------------------------------------------------------
		public int TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		//-------------------------------------------------------
		public IView ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		//-------------------------------------------------------
		public int ControlWidth {
			get {
				return _width;
			}
			set {
				_width = value;
			}
		}
		//-------------------------------------------------------
		public int ControlHeight {
			get {
				return _height;
			}
			set {
				_height = value;
			}
		}
		//-------------------------------------------------------
		public void AddControl(IView control) {
			throw new NotImplementedException();
		}
		//-------------------------------------------------------
		public void RemoveControl(IView control) {
			throw new NotImplementedException();
		}
		//-------------------------------------------------------
		public void RemoveControl(int index) {
			throw new NotImplementedException();
		}
		//-------------------------------------------------------
		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		//-------------------------------------------------------
		public int Height {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		//-------------------------------------------------------
		public bool Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		//-------------------------------------------------------
		public event EventHandler Load;

		public event EventHandler Shown;

		public event EventHandler DoubleClick;
		private int _width;
		private int _height;
		private IFormView _formView;
		private bool _playing;
		private ControlSize _panelOriginalSize;
		private ControlLocation _panelOriginalLocation;
		//-------------------------------------------------------
		public string Text {
			get {
				return _text;
			}
			set {
				_text = value;
			}
		}
		//-------------------------------------------------------
	}
}