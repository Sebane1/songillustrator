using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;

namespace SongIllustrator {
	public partial class LightPad : FormControl {
		//public LightPad() {
		//  InitializeComponent();
		//}
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
		FormControl lightCanvas;
		public FormControl LightCanvas {
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
				if (lightData.Density * lightData.Density != lightCanvas.FormControls.Count) {
					lightCanvas.FormControls.Clear();
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
			foreach (MacroButton button in lightCanvas.FormControls) {
				colours.Add(button.ControlBackColor);
			}
			lightCanvas.ControlWidth = this.ControlWidth - 140;
			GeneratePixels(lightData.Density);
			for (int i = 0; i < colours.Count; i++) {
				lightCanvas.FormControls[i].ControlBackColor = colours[i];
			}
		}
		public void SetFrame(int frameIndex) {
			if (frameIndex >= 0 && frameIndex < lightData.FrameData.Count) {
				if (lightData.FrameData.Count > 0) {
					FrameData frameData = lightData.FrameData[frameIndex];
					for (int i = 0; i < frameData.Colours.Count; i++) {
						lightCanvas.FormControls[i].ControlBackColor = frameData.Colours[i];
					}
				}
			}
		}

		private void GeneratePixels(int pixels) {
			if (pixels > 0) {
				lightCanvas.FormControls.Clear();
				int arrayPos = 0;
				ControlSize buttonSize = new ControlSize(lightCanvas.ControlWidth / pixels, lightCanvas.Height / pixels);
				for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {
					for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
						MacroButton button = new MacroButton();
						button.ArrayPos = arrayPos++;
						button.Port = lightData.Port;
						button.ControlSize = buttonSize;
						button.ControlLocation = new ControlLocation(buttonSize.Width * widthProgression, buttonSize.Height * heightProgression);
						button.BackColorChanged += delegate {
							if (lightData.EditMode) {
								GotInteraction(this, EventArgs.Empty);
							}
						};
						lightCanvas.FormControls.Add(button);
					}
				}
			}
		}
		public void ReplaceFrame(int index) {
			for (int i = 0; i < lightCanvas.FormControls.Count; i++) {
				lightData.FrameData[index].Colours[i] = (lightCanvas.FormControls[i] as MacroButton).ControlBackColor;
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
									MacroButton button;
									if (notePos >= 0) {
										try {
											button = !_display.Visible ? lightCanvas.FormControls[notePos] as MacroButton : (_display.FormControls[Index] as LightPad).FormControls[notePos] as MacroButton;
										} catch {
											button = lightCanvas.FormControls[notePos] as MacroButton;
										}
										button.Reset();
										button.CanSendMessage = true;
									}
									break;
								case 144:
									if (notePos >= 0) {
										try {
											button = !_display.Visible ? lightCanvas.FormControls[notePos] as MacroButton : (_display.FormControls[Index] as LightPad).FormControls[notePos] as MacroButton;
										} catch {
											button = lightCanvas.FormControls[notePos] as MacroButton;
										}
										if (button != null) {
											switch (velocity) {
												case 7:
													if (!button.CheckEqualColor(button.ControlBackColor, Color.Red)) {
														button.ControlBackColor = Color.Red;
													}
													break;
												case 83:
													if (!button.CheckEqualColor(button.ControlBackColor, Color.Orange)) {
														button.ControlBackColor = Color.Orange;
													}
													break;
												case 124:
													if (!button.CheckEqualColor(button.ControlBackColor, Color.Green)) {
														button.ControlBackColor = Color.Green;
													}
													break;
												case 127:
													if (!button.CheckEqualColor(button.ControlBackColor, Color.Yellow)) {
														button.ControlBackColor = Color.Yellow;
													}
													break;
											}
										}
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

		public int ControlWidth {
			get;
			set;
		}

		#region FormControl Members

		public event EventHandler Clicked;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public string Name {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlSize ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlLocation ControlLocation {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<FormControl> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		void FormControl.Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		public int Height {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members

		public event EventHandler Click;

		public int TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public FormControl ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler Load {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler Shown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


		public int ControlHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


		public event EventHandler BackColorChanged;

		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members

		#endregion

		#region FormControl Members

		EventHandler FormControl.Click {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.RightClicked {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.KeyDown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.KeyUp {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Resized {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
