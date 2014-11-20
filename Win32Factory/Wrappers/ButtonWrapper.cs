using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class ButtonWrapper : Button, ButtonView {
		private EventHandler Loading;

		#region FormControl Members

		public void Initialize() {
			//throw new NotImplementedException();
		}

		public FormControl ParentControl {
			get {
				return this.Parent as FormControl;
			}
			set {
				this.Parent = value as Control;
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

		public EventHandler Load {
			get {
				return this.Loading;
			}
			set {
				this.Loading += value;
			}
		}

		public EventHandler Shown {
			get {
				return this.Shown;
			}
			set {
				this.Shown = value;
			}
		}


		#endregion

		#region FormControl Members


		public int ControlWidth {
			get {
				return Width;
			}
			set {
				Width = value;
			}
		}

		public SongIllustrator.Color ControlBackColor {
			get {
				return SongIllustrator.Color.FromArgb(BackColor.ToArgb());
			}
			set {
				BackColor = System.Drawing.Color.FromArgb(value.ToArgb());
			}
		}

		#endregion

		#region FormControl Members

		public new EventHandler Click {
			get {
				return null;
			}
			set {
				base.Click += value;
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

		EventHandler FormControl.Resized {
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
	}
}
