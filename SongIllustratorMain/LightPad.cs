using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using ControlFactory;

namespace SongIllustrator {
	public partial class LightPad : IView {
		public LightPad(IFactory factory, IFormView formView, ControlSize size, ControlLocation location) {
			_factory = factory;
			_formView = formView;
			if (lightCanvas == null) {
				lightCanvas = _factory.BuildPanel();
			}
			lightCanvas.ControlSize = size;
			lightCanvas.ControlLocation = location;
			Load += new EventHandler(LightPad_Load);
		}
		private Launchpad lightData = new Launchpad();
		private bool passiveMode = false;
		private bool _listenToMidi = true;
		public event EventHandler GotInteraction;
		IPanelView lightCanvas;
		public IPanelView LightCanvas {
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
				if (lightData.Density * lightData.Density != lightCanvas.Count) {
					if (lightCanvas.Count > 0) {
						if (_created) {
							RescalePixels(lightData.Density);
						}
					} else {
						lightCanvas.Clear();
						if (_created) {
							GeneratePixels(lightData.Density);
						}
					}
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
			foreach (MacroButton button in lightCanvas.ViewList.Values) {
				colours.Add(button.ControlBackColor);
			}
			lightCanvas.ControlWidth = this.ControlWidth - 140;
			GeneratePixels(lightData.Density);
			for (int i = 0; i < colours.Count; i++) {
				lightCanvas.ViewList[i].ControlBackColor = colours[i];
			}
		}
		public void SetFrame(int frameIndex) {
			if (frameIndex >= 0 && frameIndex < lightData.FrameData.Count) {
				lock (lightData.FrameData) {
					if (lightData.FrameData.Count > 0) {
						FrameData frameData = lightData.FrameData[frameIndex];
						for (int i = 0; i < frameData.Colours.Count; i++) {
							if (!Color.CheckEqualColor(lightCanvas.ViewList[i].ControlBackColor, frameData.Colours[i])) {
								lightCanvas.ViewList[i].ControlBackColor = frameData.Colours[i];
							}
						}
					}
				}
			}
		}

		private void GeneratePixels(int pixels) {
			if (pixels > 0) {
				lightCanvas.Clear();
				int arrayPos = 0;
				ControlSize buttonSize = new ControlSize(lightCanvas.ControlHeight/ pixels, lightCanvas.ControlHeight / pixels);
				for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {
					for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
						MacroButton button = new MacroButton(_factory);
						button.ArrayPos = arrayPos++;
						button.ParentControl = _formView;
						button.Port = lightData.Port;
						button.Button.ControlSize = buttonSize;
						button.Button.ControlLocation = new ControlLocation(buttonSize.Width * widthProgression + lightCanvas.ControlLocation.X, buttonSize.Height * heightProgression + lightCanvas.ControlLocation.Y);
						button.Button.BackColorChanged += delegate {
							if (lightData.EditMode) {
								GotInteraction(this, EventArgs.Empty);
							}
						};
						//button.Button.Text = arrayPos.ToString();
						button.Name = arrayPos.ToString() + DateTime.Now.Millisecond;
						button.TabIndex = _formView.Count;
						lightCanvas.Add(button);
						_formView.Add(button.Button);
						if (!_created) {
							_created = true;
						}
					}
				}
			}
		}
		public void RescalePixels(int pixels) {
			if (pixels > 0) {
				int arrayPos = 0;
				ControlSize buttonSize = new ControlSize(lightCanvas.ControlHeight / pixels, lightCanvas.ControlHeight / pixels);
				for (int heightProgression = 0; heightProgression < pixels; heightProgression++) {
					for (int widthProgression = 0; widthProgression < pixels; widthProgression++) {
						MacroButton button = lightCanvas.ViewList[arrayPos++] as MacroButton;
						button.ControlSize = buttonSize;
						button.Button.ControlLocation = new ControlLocation(buttonSize.Width * widthProgression + lightCanvas.ControlLocation.X, buttonSize.Height * heightProgression + lightCanvas.ControlLocation.Y);
						//button.Button.Text = arrayPos.ToString();
					}
				}
			}
		}
		public void ReplaceFrame(int index) {
			if (index > -1) {
				for (int i = 0; i < lightCanvas.Count; i++) {
					lightData.FrameData[index].Colours[i] = (lightCanvas.ViewList[i] as MacroButton).Button.ControlBackColor;
				}
			}
		}
		private void MidiDataCoordinator() {
			while (true) {
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
										button = lightCanvas.ViewList[notePos] as MacroButton;
										lock (button) {
											button.Reset();
											button.CanSendMessage = true;
										}
									}
									break;
								case 144:
									if (notePos >= 0) {
										button = lightCanvas.ViewList[notePos] as MacroButton;
										if (button != null) {
											lock (button) {
												switch (VelocityRange(velocity)) {
													case 7:
														if (!button.CheckEqualColor(button.ControlBackColor, Color.Red)) {
															button.Button.ControlBackColor = Color.Red;
														}
														break;
													case 83:
														if (!button.CheckEqualColor(button.ControlBackColor, Color.Orange)) {
															button.Button.ControlBackColor = Color.Orange;
														}
														break;
													case 124:
														if (!button.CheckEqualColor(button.ControlBackColor, Color.Green)) {
															button.Button.ControlBackColor = Color.Green;
														}
														break;
													case 127:
														if (!button.CheckEqualColor(button.ControlBackColor, Color.Yellow)) {
															button.Button.ControlBackColor = Color.Yellow;
														}
														break;
												}
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

		private int VelocityRange(int velocity) {
			if (velocity <= 7) {
				return 7;
			}
			if (velocity > 7 & velocity <= 83) {
				return 83;
			}
			if (velocity > 83 && velocity <= 124) {
				return 124;
			}
			if (velocity > 124 && 124 <= 127) {
				return 127;
			}
			return -1;
		}

		private void LightPad_Load(object sender, EventArgs e) {
			GeneratePixels(8);
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

		#region IView Members

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
				return lightCanvas.ControlSize;
			}
			set {
				lightCanvas.ControlSize = value;
			}
		}

		public ControlLocation ControlLocation {
			get {
				return lightCanvas.ControlLocation;
			}
			set {
				lightCanvas.ControlLocation = value;
			}
		}

		public Dictionary<int, IView> ViewItems {
			get {
				return lightCanvas.ViewList;
			}
			set {
				object dummy = value;
			}
		}

		void IView.Dispose(bool dispose) {
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

		#region IView Members

		public event EventHandler Click;

		public int TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public IView ParentControl {
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

		public event EventHandler Load;

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

		#region IView Members


		public int ControlHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		public event EventHandler BackColorChanged;
		private IFactory _factory;
		private IFormView _formView;
		private bool _created;

		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members

		#endregion

		#region IView Members


		#endregion

		#region IView Members


		public void AddControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(int index) {
			throw new NotImplementedException();
		}

		event EventHandler IView.Load {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		event EventHandler IView.Shown {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		event EventHandler IView.DoubleClick {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		#endregion

		public bool Trigger {
			get {
				return false;
			}
			set {
				Load(this, EventArgs.Empty);
			}

		}

		internal void Destroy() {
			for (int i = lightCanvas.Count - 1; i > -1; i--) {
				_formView.Remove((lightCanvas.ViewList[i] as MacroButton).Button);
				lightCanvas.Remove(lightCanvas.ViewList[i]);
				lightCanvas.ViewList[i].Dispose(true);
			}
		}

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;

		#endregion
	}
}
