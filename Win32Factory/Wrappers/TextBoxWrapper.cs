using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class TextBoxWrapper : TextBox, TextBoxView {

		#region TextBoxView Members


		#endregion

		#region FormControl Members


		public event EventHandler RightClicked;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public FormControl ParentControl {
			get {
				return Parent as FormControl;
			}
			set {
				Parent = value as Control;
			}
		}

		public ControlSize ControlSize {
			get {
				return new ControlSize(Size.Width, Size.Height);
			}
			set {
				Size = new Size(value.Width, value.Height);
			}
		}

		public ControlLocation ControlLocation {
			get {
				return new ControlLocation(Location.X, Location.Y);
			}
			set {
				Location = new Point(value.X, value.Y);
			}
		}

		public int ControlWidth {
			get {
				return Width;
			}
			set {
				Width = value;
			}
		}

		public int ControlHeight {
			get {
				return Height;
			}
			set {
				Height = value;
			}
		}

		public List<FormControl> FormControls {
			get {
				return FormControls;
			}
			set {
				FormControls = value;
			}
		}

		public new void Dispose(bool dispose) {
			Dispose(dispose);
		}

		public event EventHandler Load;

		public event EventHandler Shown;

		public SongIllustrator.Color ControlBackColor {
			get {
				return SongIllustrator.Color.FromArgb(BackColor.ToArgb());
			}
			set {
				BackColor = System.Drawing.Color.FromArgb(value.ToArgb());
			}
		}

		#endregion

		#region TextBoxView Members

		public new EventHandler TextChanged {
			get {
				return null;
			}
			set {
				base.TextChanged += value;
			}
		}

		#endregion

		#region FormControl Members

		public new EventHandler Click {
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


		EventHandler FormControl.Resized {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Load {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Shown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new EventHandler DoubleClick {
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


		public new EventHandler KeyDown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new EventHandler KeyUp {
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
