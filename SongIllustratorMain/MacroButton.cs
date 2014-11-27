using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;


namespace SongIllustrator {
	public class MacroButton : IView {
		IButtonView _button;
		Timer timer;
		//-------------------------------------------------------
		public IButtonView Button {
			get {
				return _button;
			}
			set {
				_button = value;
				_button.ParentControl = this.ParentControl;
				_button.Click += delegate {
					ChangeColor();
				};
				_button.BackColorChanged += new EventHandler(DisplayButton_BackColorChanged);
				_button.MouseLeftDown += delegate {
					timer = new Timer(new TimerCallback(MouseFollow), null, 1, 1);
					_mouseDown = true;
					cursorLocation = _factory.GetCursorPosition();
				};
				_button.MouseLeftUp += delegate {
					if (timer != null) {
						//timer.Change(Timeout.Infinite, Timeout.Infinite);
						timer.Dispose();
					}
					_mouseDown = false;
				};
				_button.MouseRightDown += delegate {
					buttons = new List<IView>();
					foreach (IView button in (ParentControl as IFormView).ViewList.Values) {
						if (button.ControlBackColor == this.ControlBackColor) {
							buttons.Add(button);
						}
					}
					rightClick = true;
				};
				_button.MouseRightUp += delegate {
					ChangeColor();
					//_mouseRightUp = true;
					lock (buttons) {
						foreach (IView item in buttons) {
							try {
								(item.ParentControl as MacroButton)._colorCount = this._colorCount;
								item.ControlBackColor = this.ControlBackColor;
							} catch {
							}
						}
					}
				};
			}
		}
		//-------------------------------------------------------
		int ignoreMessageCount = 0;
		private byte[] _lastMessage;
		private int _index;
		private bool _canSendMessage = true;
		private bool _launchpadEdit = false;
		private DateTime _lastColorChange = new DateTime();
		DateTime _lastButtonPush = DateTime.Now;
		Color lastColour;
		//-------------------------------------------------------
		public bool LaunchpadEdit {
			get {
				return _launchpadEdit;
			}
			set {
				_launchpadEdit = value;
			}
		}
		//-------------------------------------------------------
		public bool CanSendMessage {
			get {
				return _canSendMessage;
			}
			set {
				_canSendMessage = value;
			}
		}
		//-------------------------------------------------------
		byte _lastVelocity = 0;
		public int ArrayPos {
			get {
				return _index;
			}
			set {
				_index = value;
			}
		}
		//-------------------------------------------------------
		private int _colorCount = 4;
		private bool shiftDown = false;
		private bool rightClick = false;
		List<IView> buttons = new List<IView>();
		MidiDriver port;
		//-------------------------------------------------------
		public MidiDriver Port {
			get {
				return port;
			}
			set {
				port = value;
			}
		}
		//-------------------------------------------------------
		public bool ShiftDown {
			get {
				return shiftDown;
			}
			set {
				shiftDown = value;
			}
		}
		//-------------------------------------------------------
		string _text = "";
		//-------------------------------------------------------
		public string DisplayText {
			get {
				return _text;
			}
			set {
				_text = value;
			}
		}
		//-------------------------------------------------------
		/// <summary>
		/// Tells the _button to cycle to the next color.
		/// </summary>
		public bool InvokeInteraction {
			set {
				Interact(this, EventArgs.Empty);
			}
		}
		//-------------------------------------------------------
		private void DisplayButton_Load(object sender, EventArgs e) {
			ControlBackColor = Color.Gray;
			Interact += delegate {
				ChangeColor();
			};
		}
		ControlLocation cursorLocation = new ControlLocation(0, 0);
		public event EventHandler Interact;
		private void DisplayButton_Click(object sender, EventArgs e) {
			CanSendMessage = true;
			ChangeColor();
			if (rightClick) {
				foreach (MacroButton button in buttons) {
					button.ControlBackColor = this.ControlBackColor;
					button._colorCount = _colorCount;
				}
				rightClick = false;
			}
		}
		//-------------------------------------------------------
		public void Reset() {
			ControlBackColor = Color.Gray;
			/*if (port != null) {
				byte[] message = new byte[3];
				message[0] = 128;
				message[1] = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(_index));
				message[2] = 127;
				port.sendCommand(message);
				_canSendMessage = true;
			}*/
		}
		//-------------------------------------------------------
		/// <summary>
		/// Cycles the buttons color.
		/// </summary>
		public void ChangeColor() {
			switch (_colorCount++) {
				case 0:
					_button.ControlBackColor = Color.Red;
					break;
				case 1:
					ControlBackColor = Color.Orange;
					break;
				case 2:
					ControlBackColor = Color.Green;
					break;
				case 3:
					ControlBackColor = Color.Yellow;
					break;
				case 4:
					ControlBackColor = Color.Gray;
					break;
			}
			if (_colorCount > 4) {
				_colorCount = 0;
			}
		}
		//-------------------------------------------------------
		private void DisplayButton_DoubleClick(object sender, EventArgs e) {
			//ControlBackColor = Color.Gray;
		}
		//-------------------------------------------------------
		//private void DisplayButton_MouseDown(object sender, MouseEventArgs e) {
		//  if (e.Button == MouseButtons.Left) {
		//    if (string.IsNullOrEmpty(DisplayText)) {
		//      mouseFollow.Start();
		//      cursorLocation = e.ControlLocation;
		//    }
		//  }
		//  if (e.Button == MouseButtons.Right) {
		//    buttons = new List<MacroButton>();
		//    foreach (MacroButton _button in this.ParentControl.ViewItems) {
		//      if (_button.ControlBackColor == this.ControlBackColor) {
		//        buttons.Add(_button);
		//      }
		//    }
		//    rightClick = true;
		//  }
		//}

		//private void DisplayButton_MouseUp(object sender, MouseEventArgs e) {
		//  //if (string.IsNullOrEmpty(DisplayText)) {
		//  //  mouseFollow.Stop();
		//  //}
		//}

		private void MouseFollow(object blah) {
			if (_mouseDown) {
				if (_button != null) {
					ControlLocation location = (this.ParentControl as IFormView).ControlLocation;
					ControlLocation cursorPosition = new ControlLocation(_factory.GetCursorPosition().X - location.X, _factory.GetCursorPosition().Y - location.Y);
					foreach (IView button in (_parent as IFormView).ViewList.Values) {
						if (button != null) {
							try {
								//if (button.GetType() == typeof(IButtonView)) {
								ControlLocation buttonLocation = button.ControlLocation;
								if (cursorPosition.X <= buttonLocation.X + button.ControlSize.Width && cursorPosition.X >= buttonLocation.X && cursorPosition.Y <= buttonLocation.Y + button.ControlSize.Height && cursorPosition.Y >= buttonLocation.Y) {
									(button.ParentControl as MacroButton)._colorCount = _colorCount;
									button.ControlBackColor = this.ControlBackColor;
									ControlLocation i = button.ControlLocation;
								}
								//}
							} catch {
							}
						}
					}
				}
			} else if (_mouseRightUp) {

			}
			timer = timer;
		}

		//private void DisplayButton_KeyDown(object sender, EventArgs e) {
		//  if (e.KeyCode == Keys.Shift) {
		//    shiftDown = true;
		//  }
		//}

		//private void DisplayButton_KeyUp(object sender, EventArgs e) {
		//  shiftDown = false;
		//}

		//private void DisplayButton_Paint(object sender, PaintEventArgs e) {
		//  Graphics graphics = e.Graphics;
		//  graphics.DrawString(_text, new Font(new FontFamily("Arial"), 12), Brushes.Black, new ControlLocationF(0, 0));
		//}
		/// <summary>
		/// Sends a MIDI on event for the associated note.
		/// </summary>
		public void SendMessage() {
			//if (_canSendMessage) {
			if (port != null) {
				byte[] message = new byte[3];
				byte[] sysMessage = new byte[2];
				byte velocity = 0;
				switch (_colorCount) {
					case 0:
						velocity = 7;
						break;
					case 1:
						velocity = 83;
						break;
					case 2:
						velocity = 124;
						break;
					case 3:
						velocity = 127;
						break;
					case 4:
						Reset();
						//SendOff();
						break;
				}
				sysMessage[0] = 240;
				sysMessage[1] = 2;
				port.SendCommand(sysMessage);
				//..............
				message[0] = 128;
				message[1] = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(_index));
				message[2] = _lastVelocity;
				port.SendCommand(message);
				//..............
				sysMessage[0] = 240;
				sysMessage[1] = 2;
				port.SendCommand(sysMessage);
				//..............
				message[0] = 144;
				message[1] = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(_index));
				message[2] = velocity;
				port.SendCommand(message);
				//..............
				_lastMessage = message;
				_lastVelocity = velocity;
			}
			//	}
		}

		/// <summary>
		/// Compares MIDI messages to see if theres a match.
		/// </summary>
		/// <param name="_lastMessage">The last MIDI message sent.</param>
		/// <param name="message">The current MIDI message to send.</param>
		/// <returns>Whether or not the messages match.</returns>
		private bool CompareMessage(byte[] _lastMessage, byte[] message) {
			return _lastMessage[0] == message[0] && _lastMessage[1] == message[1] && _lastMessage[2] == message[2];
		}
		/// <summary>
		/// Sends a MIDI off event for the buttons associated note.
		/// </summary>
		public void SendOff() {
			if (port != null) {
				byte[] message = new byte[3];
				message[0] = 128;
				message[1] = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(_index));
				message[2] = _lastVelocity;
				port.SendCommand(message);
			}
		}
		public bool CheckEqualColor(Color colourA, Color b) {
			if (b.A == 255 && b.R == 255 && b.G == 255) {
				object test = new object();
			}
			object col = colourA;
			lock (col) {
				Color a = (Color) col;
				return (ToleratedCompare(a.R, b.R, 20) && ToleratedCompare(a.G, b.G, 20) && ToleratedCompare(a.B, b.B, 20));
			}
		}
		public bool ToleratedCompare(int a, int b, int tolerance) {
			return (a == b);
		}
		bool hitAlready = false;
		private void DisplayButton_BackColorChanged(object sender, EventArgs e) {
			lock (_button) {
				if (!CheckEqualColor(lastColour, ControlBackColor)) {
					if (CheckEqualColor(ControlBackColor, Color.Red)) {
						_colorCount = 0;
						SendMessage();
					} else if (CheckEqualColor(_button.ControlBackColor, Color.Orange)) {
						_colorCount = 1;
						SendMessage();
					} else if (CheckEqualColor(_button.ControlBackColor, Color.Green)) {
						_colorCount = 2;
						SendMessage();
					} else if (CheckEqualColor(_button.ControlBackColor, Color.Yellow)) {
						_colorCount = 3;
						SendMessage();
					} else if (CheckEqualColor(_button.ControlBackColor, Color.Gray)) {
						_colorCount = 4;
						hitAlready = true;
						Reset();
						SendOff();
					} else {
						Color color = _button.ControlBackColor;
					}
				}
			}
		}

		public Color ControlBackColor {
			get {
				return _button.ControlBackColor;
			}
			set {
				_button.ControlBackColor = value;
			}
		}

		#region IView Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public int TabIndex {
			get {
				return _tabIndex;
			}
			set {
				_tabIndex = value;
			}
		}

		public IView ParentControl {
			get {
				return _parent;
			}
			set {
				_parent = value;
			}
		}

		public string Name {
			get {
				return _button.Name;
			}
			set {
				_button.Name = value;
			}
		}

		public ControlSize ControlSize {
			get {
				return _button.ControlSize;
			}
			set {
				_button.ControlSize = value;
			}
		}

		public ControlLocation ControlLocation {
			get {
				return _button.ControlLocation;
			}
			set {
				_button.ControlLocation = value;
			}
		}

		public List<IView> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Visible {
			get {
				return _button.Visible;
			}
			set {
				_button.Visible = true;
			}
		}

		public void Dispose(bool dispose) {
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

		public bool Enabled {
			get {
				return _button.Enabled;
			}
			set {
				_button.Enabled = value;
			}
		}

		public EventHandler Load {
			get {
				return null;
			}
			set {
				Loading = value;
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
				return _button.Text;
			}
			set {
				_button.Text = value;
			}
		}

		#endregion

		#region IView Members


		public int ControlWidth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

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
		private SongIllustrator.ControlLocation _controlLocation;
		private SongIllustrator.ControlSize _controlSize;
		private string _name;
		private int _tabIndex;
		private EventHandler Loading;
		private ControlFactory.IFactory _factory;

		public MacroButton(ControlFactory.IFactory _factory) {
			// TODO: Complete member initialization
			this._factory = _factory;
			Button = _factory.BuildButton();
			_button.ParentControl = this;
			_button.Visible = true;
			_button.ControlBackColor = Color.Gray;
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

		#endregion

		#region IView Members


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

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;
		private IView _parent;
		private bool _mouseDown;
		private bool _mouseRightUp;

		#endregion
	}
}

