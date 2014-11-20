using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;


namespace SongIllustrator {
	public class MacroButton : FormControl {
		int ignoreMessageCount = 0;
		private byte[] _lastMessage;
		private int _index;
		private bool _canSendMessage = true;
		private bool _launchpadEdit = false;
		private DateTime _lastColorChange = new DateTime();
		DateTime _lastButtonPush = DateTime.Now;
		Color lastColour;
		public bool LaunchpadEdit {
			get {
				return _launchpadEdit;
			}
			set {
				_launchpadEdit = value;
			}
		}
		public bool CanSendMessage {
			get {
				return _canSendMessage;
			}
			set {
				_canSendMessage = value;
			}
		}
		byte _lastVelocity = 0;
		public int ArrayPos {
			get {
				return _index;
			}
			set {
				_index = value;
			}
		}
		private int _colorCount = 4;
		private bool shiftDown = false;
		private bool rightClick = false;
		List<MacroButton> buttons = new List<MacroButton>();
		MidiDriver port;

		public MidiDriver Port {
			get {
				return port;
			}
			set {
				port = value;
			}
		}

		public bool ShiftDown {
			get {
				return shiftDown;
			}
			set {
				shiftDown = value;
			}
		}
		string _text = "";
		public string DisplayText {
			get {
				return _text;
			}
			set {
				_text = value;
			}
		}
		/// <summary>
		/// Tells the button to cycle to the next color.
		/// </summary>
		public bool InvokeInteraction {
			set {
				Interact(this, EventArgs.Empty);
			}
		}
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

		/// <summary>
		/// Cycles the buttons color.
		/// </summary>
		public void ChangeColor() {
			switch (_colorCount++) {
				case 0:
					ControlBackColor = Color.Red;
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
		private void DisplayButton_DoubleClick(object sender, EventArgs e) {
			//ControlBackColor = Color.Gray;
		}

		//private void DisplayButton_MouseDown(object sender, MouseEventArgs e) {
		//  //if (e.Button == MouseButtons.Left) {
		//  //  if (string.IsNullOrEmpty(DisplayText)) {
		//  //    mouseFollow.Start();
		//  //    cursorLocation = e.ControlLocation;
		//  //  }
		//  //}
		//  //if (e.Button == MouseButtons.Right) {
		//  //  buttons = new List<MacroButton>();
		//  //  foreach (MacroButton button in this.ParentControl.FormControls) {
		//  //    if (button.ControlBackColor == this.ControlBackColor) {
		//  //      buttons.Add(button);
		//  //    }
		//  //  }
		//  //  rightClick = true;
		//  //}
		//}

		//private void DisplayButton_MouseUp(object sender, MouseEventArgs e) {
		//  //if (string.IsNullOrEmpty(DisplayText)) {
		//  //  mouseFollow.Stop();
		//  //}
		//}

		private void mouseFollow_Tick(object sender, EventArgs e) {
			//ControlLocation cursorPosition = ControlLocationToClient(new ControlLocation(Cursor.Position.X, Cursor.Position.Y));
			//foreach (MacroButton button in this.ParentControl.FormControls) {
			//  ControlLocation buttonLocation = button.ControlLocation;
			//  if (cursorPosition.X + this.ControlLocation.X < buttonLocation.X + button.ControlWidth && cursorPosition.X + this.ControlLocation.X > buttonLocation.X && cursorPosition.Y + this.ControlLocation.Y < buttonLocation.Y + button.Height && cursorPosition.Y + this.ControlLocation.Y > buttonLocation.Y) {
			//    button.ControlBackColor = this.ControlBackColor;
			//    button._colorCount = _colorCount;
			//    ControlLocation i = button.ControlLocation;
			//  }
			//}
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
				sysMessage[1] =  2;
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
		/// <returns>Whether nor not the messages match.</returns>
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
		public bool CheckEqualColor(Color a, Color b) {
			return (a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B);
		}
		bool hitAlready = false;
		private void DisplayButton_BackColorChanged(object sender, EventArgs e) {
			if (!CheckEqualColor(lastColour, ControlBackColor)) {
				if (CheckEqualColor(ControlBackColor, Color.Red)) {
					_colorCount = 0;
					SendMessage();
				} else if (CheckEqualColor(ControlBackColor, Color.Orange)) {
					_colorCount = 1;
					SendMessage();
				} else if (CheckEqualColor(ControlBackColor, Color.Green)) {
					_colorCount = 2;
					SendMessage();
				} else if (CheckEqualColor(ControlBackColor, Color.Yellow)) {
					_colorCount = 3;
					SendMessage();
				} else if (CheckEqualColor(ControlBackColor, Color.Aqua) || CheckEqualColor(ControlBackColor, Color.Blue)) {
					_colorCount = 2;
					hitAlready = true;
					SendMessage();
				} else if (CheckEqualColor(ControlBackColor, Color.Black) || CheckEqualColor(ControlBackColor, Color.Gray) || CheckEqualColor(ControlBackColor, Color.Purple)) {
					_colorCount = 4;
					hitAlready = true;
					Reset();
					SendOff();
				}
			}
		}

		public Color ControlBackColor {
			get;
			set;
		}

		#region FormControl Members

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

		public FormControl ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		public ControlSize ControlSize {
			get {
				return _controlSize;
			}
			set {
				_controlSize = value;
			}
		}

		public ControlLocation ControlLocation {
			get {
				return _controlLocation;
			}
			set {
				_controlLocation = value;
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

		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
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
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
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
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


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

		#region FormControl Members


		public event EventHandler BackColorChanged;
		private SongIllustrator.ControlLocation _controlLocation;
		private SongIllustrator.ControlSize _controlSize;
		private string _name;
		private int _tabIndex;
		private EventHandler Loading;

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

