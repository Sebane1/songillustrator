using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TobiasErichsen.teVirtualMIDI;
using System.Threading;

namespace SongIllustrator {
	public partial class LightPad : UserControl {
		public LightPad() {
			InitializeComponent();
		}
		private Launchpad lightData = new Launchpad();
		private bool passiveMode = false;
		private bool _listenToMidi = true;
		public Panel LightCanvas {
			get {
				return lightCanvas;
			}
			set {
				lightCanvas = value;
			}
		}
		public bool PassiveMode {
			get {
				return passiveMode;
			}
			set {
				passiveMode = value;
			}
		}
		public bool ListenToMidi {
			get {
				return _listenToMidi;
			}
			set {
				_listenToMidi = value;
			}
		}

		public Launchpad LightData {
			get {
				return lightData;
			}
			set {
				lightData = value;
				lightCanvas.Controls.Clear();
				GeneratePixels(lightData.Density);
			}
		}
		public TeVirtualMIDI Port {
			get {
				return lightData.Port;
			}
			set {
				lightData.Port = value;
			}
		}
		Thread _thread = null;
		private void panel1_SizeChanged(object sender, EventArgs e) {
			List<Color> colours = new List<Color>();
			foreach (DisplayButton button in lightCanvas.Controls) {
				colours.Add(button.BackColor);
			}
			lightCanvas.Width = this.Width - 140;
			GeneratePixels(lightData.Density);
			for (int i = 0; i < colours.Count; i++) {
				lightCanvas.Controls[i].BackColor = colours[i];
			}
		}
		public void SetFrame(int frameIndex) {
			if (frameIndex >= 0) {
				FrameData frameData = lightData.FrameData[frameIndex];
				for (int i = 0; i < frameData.Colours.Count; i++) {
					lightCanvas.Controls[i].BackColor = frameData.Colours[i];
				}
			}
		}
		private void GeneratePixels(int pixels) {
			lightCanvas.Controls.Clear();
			int arrayPos = 0;
			Size buttonSize = new Size(lightCanvas.Width / pixels, lightCanvas.Height / pixels);
			for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {
				for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
					DisplayButton button = new DisplayButton();
					button.ArrayPos = arrayPos++;
					button.Port = lightData.Port;
					button.Size = buttonSize;
					button.Location = new Point(buttonSize.Width * widthProgression, buttonSize.Height * heightProgression);
					lightCanvas.Controls.Add(button);
				}
			}
			/*
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
			 */
		}
		private void MidiDataCoordinator() {
			while (true) {
				if (!lightData.ListenToMidi) {
					object test;
				}
				if (_listenToMidi) {
					byte[] command = lightData.Port.getCommand();
					if (command.Length >= 3) {
						int process = command[0];
						int key = command[1];
						int velocity = command[2];
						string note = NoteIdentifier.GetNoteFromInt(key);
						int notePos = NoteIdentifier.GetNotePosition(note);
						#region MIDI Logic
						switch (process) {
							case 128:
								DisplayButton button;
								if (notePos >= 0) {
									Invoke(new MethodInvoker(
										delegate() {
											button = (DisplayButton) lightCanvas.Controls[NoteIdentifier.GetNotePosition(note)];
											if (!passiveMode) {
												button.Reset();
												button.CanSendMessage = false;
											} else {
												if (velocity == 64) {
													button.CanSendMessage = true;
													button.ChangeColor();
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
											button = lightCanvas.Controls[notePos] as DisplayButton;
											button = (DisplayButton) lightCanvas.Controls[NoteIdentifier.GetNotePosition(note)];
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
						}
					}
						#endregion MIDI Logic
				} else {
					lightData.Port.getCommand();
				}
			}
		}

		private void LightPad_Load(object sender, EventArgs e) {
			if (lightData.Thread == null) {
				lightData.Thread = new Thread(MidiDataCoordinator);
				lightData.Thread.IsBackground = true;
				lightData.Thread.Start();
			}
		}

		private void LightPad_Enter(object sender, EventArgs e) {

		}
	}
}
