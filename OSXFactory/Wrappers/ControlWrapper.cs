using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Drawing;
using MonoMac.AppKit;

namespace OSXFactory.Wrappers {
	public class ControlWrapper : IView {
		#region IView Members
		private NSControl _control = new NSControl ();
		int _tabIndex;
		string _name;
		string _text;
		bool _visible;
		SongIllustrator.Color _backColor = SongIllustrator.Color.Gray;
		//-------------------------------------------------------
		public NSControl Control {
			get {
				return _control;
			}
			set {
				if (value != null) {
					_control = value;
				}
				_control.Activated += delegate {
					if (Click != null) {
						Click(this, EventArgs.Empty);
					}
				};
				/*_control+= delegate {
					if (Click != null) {
						Click(this, EventArgs.Empty);
					}
				};*/
				/*_control.MouseClick += delegate {
					if (Click != null) {
						//Click(this, EventArgs.Empty);
					}
				};
				_control.MouseDoubleClick += delegate {
					if (DoubleClick != null) {
						DoubleClick(this, EventArgs.Empty);
					}
				};*/
			/*
				_control.MouseUp += delegate {
					if (MouseLeftUp != null) {
						MouseLeftUp(this, EventArgs.Empty);
					}
				};
				_control.RightMouseUp += delegate {
					if (MouseRightUp != null) {
						MouseRightUp(this, EventArgs.Empty);
					}
				};
				_control.MouseDown += delegate {
					if (MouseLeftDown != null) {
						MouseLeftDown(this, EventArgs.Empty);
					}
				};
				_control.RightMouseDown += delegate {
					if (MouseRightDown != null) {
						MouseRightDown(this, EventArgs.Empty);
					}
				};*/
				//_control.MouseUp += new MouseEventHandler(_control_MouseUp);
				//_control.Visible = true;
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
			return new ControlSize((int)_control.Bounds.Width, (int)_control.Bounds.Height);
			}
			set {
			_control.Bounds = new RectangleF((int)_control.Bounds.X,(int)_control.Bounds.Y, (int)value.Width, (int)value.Height);
			}
		}
		//-------------------------------------------------------
		public ControlLocation ControlLocation {
			get {
			return new ControlLocation((int)_control.Bounds.X, (int)_control.Bounds.Y);
			}
			set {
			_control.Bounds = new RectangleF((int)value.X,(int)value.Y, (int)_control.Bounds.Width, (int)_control.Bounds.Height);
			}
		}
		//-------------------------------------------------------
		public int ControlWidth {
			get {
			return (int)_control.Bounds.Width;
				//return _control.Width;
			}
			set {
			_control.Bounds = new RectangleF((int)_control.Bounds.X,(int)_control.Bounds.Y, value, (int)_control.Bounds.Height);
				//_control.Width = value;
			}
		}
		//-------------------------------------------------------
		public int ControlHeight {
			get {
			return (int)_control.Bounds.Height;
				//return _control.Height;
			}
			set {
			_control.Bounds = new RectangleF((int)_control.Bounds.X,(int)value, _control.Bounds.X, (int)_control.Bounds.Height);
				//_control.Height = value;
			}
		}
		//-------------------------------------------------------
		public void Dispose(bool dispose) {
			_control.Dispose();
		}
		//-------------------------------------------------------
		public SongIllustrator.Color ControlBackColor {
			get {
				return _backColor;
			}
			set {
				_backColor = value;
				//_control.ShouldDrawColor = System.Drawing.Color.FromArgb(value.A, value.R, value.G, value.B);
				BackColorChanged(this, EventArgs.Empty);
			}
		}
		//-------------------------------------------------------
		#endregion

		#region IView Members


		public int TabIndex {
			get {
				return _tabIndex;
			}
			set {
				_tabIndex = value;
			}
		}
		//-------------------------------------------------------
		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}
		//-------------------------------------------------------
		public event EventHandler BackColorChanged;

		public bool Visible {
			get {
				return _visible;
			}
			set {
				_visible = value;
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
				return _text;
			}
			set {
				_text = value;
			}
		}
		//-------------------------------------------------------
		#endregion

		#region IView Members


		public void AddControl(IView control) {
			//_control.Controls.Add(control as Control);
		}

		public void RemoveControl(IView control) {
			//_control.Controls.Remove(control as Control);
		}

		public void RemoveControl(int index) {
			//_control.Controls.RemoveAt(index);
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
