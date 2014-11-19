using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SongIllustrator {
	public partial class LightPad : UserControl {
		public LightPad() {
			InitializeComponent();
		}
		private Launchpad lightData = new Launchpad();
		private bool passiveMode = false;
		private bool _listenToMidi = true;
		ShowDisplay _display;
		public event EventHandler GotInteraction;
		public ShowDisplay Display {
			get {
				return _display;
			}
			set {
				_display = value;
			}
		}
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
				if (lightData.Density * lightData.Density != lightCanvas.Controls.Count) {
					lightCanvas.Controls.Clear();
					GeneratePixels(lightData.Density);
				}
			}
		}
		public MidiDriver Port {
			get {
				return lightData.Port;
			}
			set {
				lightData.Port = value;
			}
		}
		public void IndexFrames() {
			for (int i = 0; i < lightData.FrameData.Count; i++) {
				lightData.FrameData[i].Index = i;
			}
		}
		Thread _thread = null;
		public int Index;
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
			if (frameIndex >= 0 && frameIndex < lightData.FrameData.Count) {
				if (lightData.FrameData.Count > 0) {
					FrameData frameData = lightData.FrameData[frameIndex];
					for (int i = 0; i < frameData.Colours.Count; i++) {
						lightCanvas.Controls[i].BackColor = frameData.Colours[i];
					}
				}
			}
		}

		private void GeneratePixels(int pixels) {
			if (pixels > 0) {
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
						button.BackColorChanged += delegate {
							if (lightData.EditMode) {
								GotInteraction(this, EventArgs.Empty);
							}
						};
						lightCanvas.Controls.Add(button);
					}
				}
			}
		}
		public void ReplaceFrame(int index) {
			for (int i = 0; i < lightCanvas.Controls.Count; i++) {
				lightData.FrameData[index].Colours[i] = (lightCanvas.Controls[i] as DisplayButton).BackColor;
			}
		}
		private void MidiDataCoordinator() {
			while (true) {
				if (!lightData.ListenToMidi) {
					object test;
				}
				if (_listenToMidi) {
					byte[] command = lightData.Port.ReceiveCommand();
					if (command != null) {
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
												try {
													button = !_display.Visible ? lightCanvas.Controls[notePos] as DisplayButton : (_display.Canvas.Controls[Index] as LightPad).LightCanvas.Controls[notePos] as DisplayButton;
												} catch {
													button = lightCanvas.Controls[notePos] as DisplayButton;
												}
												button.Reset();
												button.CanSendMessage = true;
											}));
									}
									break;
								case 144:
									if (notePos >= 0) {
										Invoke(new MethodInvoker(
											delegate() {
												try {
													button = !_display.Visible ? lightCanvas.Controls[notePos] as DisplayButton : (_display.Canvas.Controls[Index] as LightPad).LightCanvas.Controls[notePos] as DisplayButton;
												} catch {
													button = lightCanvas.Controls[notePos] as DisplayButton;
												}
												if (button != null) {
													switch (velocity) {
														case 7:
															if (!button.CheckEqualColor(button.BackColor, Color.Red)) {
																button.BackColor = Color.Red;
															}
															break;
														case 83:
															if (!button.CheckEqualColor(button.BackColor, Color.Orange)) {
																button.BackColor = Color.Orange;
															}
															break;
														case 124:
															if (!button.CheckEqualColor(button.BackColor, Color.Green)) {
																button.BackColor = Color.Green;
															}
															break;
														case 127:
															if (!button.CheckEqualColor(button.BackColor, Color.Yellow)) {
																button.BackColor = Color.Yellow;
															}
															break;
													}
												}
											}));
									}
									break;
								case 240:
									if (key == 2) {
										_listenToMidi = false;
									}
									break;
								default:
									object test = new object();
									break;
							}
						}
							#endregion MIDI Logic
					} else {
						lightData.Port.ReceiveCommand();
						_listenToMidi = true;
					}
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
