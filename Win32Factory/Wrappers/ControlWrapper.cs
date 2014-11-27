using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class ControlWrapper : IView {
		#region IView Members
		private Control _control = new Control();
		//-------------------------------------------------------
		public Control Control {
			get {
				return _control;
			}
			set {
				if (value != null) {
					_control = value;
				}
				_control.Click += delegate {
					if (Click != null) {
						Click(this, EventArgs.Empty);
					}
				};
				_control.BackColorChanged += delegate {
					if (BackColorChanged != null) {
						BackColorChanged(this, EventArgs.Empty);
					}
				};
				_control.MouseClick += delegate {
					if (Click != null) {
						//Click(this, EventArgs.Empty);
					}
				};
				_control.MouseDoubleClick += delegate {
					if (DoubleClick != null) {
						DoubleClick(this, EventArgs.Empty);
					}
				};
				_control.MouseDown += new MouseEventHandler(_control_MouseDown);
				_control.MouseUp += new MouseEventHandler(_control_MouseUp);
				_control.Visible = true;
			}
		}
		//-------------------------------------------------------
		void _control_MouseUp(object sender, MouseEventArgs e) {
			switch (e.Button) {
				case MouseButtons.Left:
					if (MouseLeftUp != null) {
						MouseLeftUp(this, EventArgs.Empty);
					}
					break;
				case MouseButtons.Right:
					if (MouseRightUp != null) {
						MouseRightUp(this, EventArgs.Empty);
					}
					break;
			}
		}
		//-------------------------------------------------------
		void _control_MouseDown(object sender, MouseEventArgs e) {
			switch (e.Button) {
				case MouseButtons.Left:
					if (MouseLeftDown != null) {
						MouseLeftDown(this, EventArgs.Empty);
					}
					break;
				case MouseButtons.Right:
					if (MouseRightDown != null) {
						MouseRightDown(this, EventArgs.Empty);
					}
					break;
			}
		}
		//-------------------------------------------------------
		public void Initialize() {
			throw new NotImplementedException();
		}
		//-------------------------------------------------------
		public IView ParentControl {
			get {
				return _parent;
			}
			set {
				_parent = value;
			}
		}
		//-------------------------------------------------------
		public ControlSize ControlSize {
			get {
				return new ControlSize(_control.Width, _control.Height);
			}
			set {
				_control.Size = new Size(value.Width, value.Height);
			}
		}
		//-------------------------------------------------------
		public ControlLocation ControlLocation {
			get {
				return new ControlLocation(_control.Location.X, _control.Location.Y);
			}
			set {
				_control.Location = new Point(value.X, value.Y);
			}
		}
		//-------------------------------------------------------
		public int ControlWidth {
			get {
				return _control.Width;
			}
			set {
				_control.Width = value;
			}
		}
		//-------------------------------------------------------
		public int ControlHeight {
			get {
				return _control.Height;
			}
			set {
				_control.Height = value;
			}
		}
		//-------------------------------------------------------
		public void Dispose(bool dispose) {
			_control.Dispose();
		}
		//-------------------------------------------------------
		public SongIllustrator.Color ControlBackColor {
			get {
				return SongIllustrator.Color.FromArgb(_control.BackColor.A, _control.BackColor.R, _control.BackColor.G, _control.BackColor.B);
			}
			set {
				_control.BackColor = System.Drawing.Color.FromArgb(value.A, value.R, value.G, value.B);
			}
		}
		//-------------------------------------------------------
		#endregion

		#region IView Members


		public int TabIndex {
			get {
				return _control.TabIndex;
			}
			set {
				_control.TabIndex = value;
			}
		}
		//-------------------------------------------------------
		public string Name {
			get {
				return _control.Name;
			}
			set {
				_control.Name = value;
			}
		}
		//-------------------------------------------------------
		public event EventHandler BackColorChanged;

		public bool Visible {
			get {
				return _control.Visible;
			}
			set {
				_control.Visible = value;
			}
		}
		//-------------------------------------------------------
		public int Height {
			get {
				return _control.Height;
			}
			set {
				_control.Height = value;
			}
		}
		//-------------------------------------------------------
		public bool Enabled {
			get {
				return _control.Enabled;
			}
			set {
				_control.Enabled = value;
			}
		}
		//-------------------------------------------------------
		public virtual string Text {
			get {
				return _control.Text;
			}
			set {
				_control.Text = value;
			}
		}
		//-------------------------------------------------------
		#endregion

		#region IView Members


		public void AddControl(IView control) {
			_control.Controls.Add(control as Control);
		}

		public void RemoveControl(IView control) {
			_control.Controls.Remove(control as Control);
		}

		public void RemoveControl(int index) {
			_control.Controls.RemoveAt(index);
		}


		#endregion

		#region IView Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public event EventHandler Load;

		public event EventHandler Shown;

		public event EventHandler DoubleClick;
		private IView _parent;

		#endregion

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;

		#endregion
	}
}
