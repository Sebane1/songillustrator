using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public partial class DisplayButton : UserControl {
		public DisplayButton() {
			InitializeComponent();
		}
		int ignoreMessageCount = 0;
		private byte[] _lastMessage;
		private int _index;
		private bool _canSendMessage = true;
		private bool _launchpadEdit = false;
		private DateTime _lastColorChange = new DateTime();
		DateTime _lastButtonPush = DateTime.Now;
		Color lastColour = new Color();
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
		List<DisplayButton> buttons = new List<DisplayButton>();
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
			BackColor = Color.Gray;
			Interact += delegate {
				ChangeColor();
			};
		}
		Point cursorLocation = new Point(0, 0);
		public event EventHandler Interact;
		private void DisplayButton_Click(object sender, EventArgs e) {
			CanSendMessage = true;
			ChangeColor();
			if (rightClick) {
				foreach (DisplayButton button in buttons) {
					button.BackColor = this.BackColor;
					button._colorCount = _colorCount;
				}
				rightClick = false;
			}
		}
		public void Reset() {
			BackColor = Color.Gray;
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
					BackColor = Color.Red;
					break;
				case 1:
					BackColor = Color.Orange;
					break;
				case 2:
					BackColor = Color.Green;
					break;
				case 3:
					BackColor = Color.Yellow;
					break;
				case 4:
					BackColor = Color.Gray;
					break;
			}
			if (_colorCount > 4) {
				_colorCount = 0;
			}
		}
		private void DisplayButton_DoubleClick(object sender, EventArgs e) {
			//BackColor = Color.Gray;
		}

		private void DisplayButton_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (string.IsNullOrEmpty(DisplayText)) {
					mouseFollow.Start();
					cursorLocation = e.Location;
				}
			}
			if (e.Button == MouseButtons.Right) {
				buttons = new List<DisplayButton>();
				foreach (DisplayButton button in this.Parent.Controls) {
					if (button.BackColor == this.BackColor) {
						buttons.Add(button);
					}
				}
				rightClick = true;
			}
		}

		private void DisplayButton_MouseUp(object sender, MouseEventArgs e) {
			if (string.IsNullOrEmpty(DisplayText)) {
				mouseFollow.Stop();
			}
		}

		private void mouseFollow_Tick(object sender, EventArgs e) {
			Point cursorPosition = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
			foreach (DisplayButton button in this.Parent.Controls) {
				Point buttonLocation = button.Location;
				if (cursorPosition.X + this.Location.X < buttonLocation.X + button.Width && cursorPosition.X + this.Location.X > buttonLocation.X && cursorPosition.Y + this.Location.Y < buttonLocation.Y + button.Height && cursorPosition.Y + this.Location.Y > buttonLocation.Y) {
					button.BackColor = this.BackColor;
					button._colorCount = _colorCount;
					Point i = button.Location;
				}
			}
		}

		private void DisplayButton_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Shift) {
				shiftDown = true;
			}
		}

		private void DisplayButton_KeyUp(object sender, KeyEventArgs e) {
			shiftDown = false;
		}

		private void DisplayButton_Paint(object sender, PaintEventArgs e) {
			Graphics graphics = e.Graphics;
			graphics.DrawString(_text, new Font(new FontFamily("Arial"), 12), Brushes.Black, new PointF(0, 0));
		}
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
			if (!CheckEqualColor(lastColour, BackColor)) {
				if (CheckEqualColor(BackColor, Color.Red)) {
					_colorCount = 0;
					SendMessage();
				} else if (CheckEqualColor(BackColor, Color.Orange)) {
					_colorCount = 1;
					SendMessage();
				} else if (CheckEqualColor(BackColor, Color.Green)) {
					_colorCount = 2;
					SendMessage();
				} else if (CheckEqualColor(BackColor, Color.Yellow)) {
					_colorCount = 3;
					SendMessage();
				} else if (CheckEqualColor(BackColor, Color.Aqua) || CheckEqualColor(BackColor, Color.Blue)) {
					_colorCount = 2;
					hitAlready = true;
					SendMessage();
				} else if (CheckEqualColor(BackColor, Color.Black) || CheckEqualColor(BackColor, Color.Gray) || CheckEqualColor(BackColor, Color.Purple)) {
					_colorCount = 4;
					hitAlready = true;
					Reset();
					SendOff();
				}
			}
		}
	}
}

