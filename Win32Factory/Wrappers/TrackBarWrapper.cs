using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class TrackBarWrapper : TrackBar, TrackBarView {
		#region FormControl Members

		public new EventHandler Click {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler RightClicked {
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

		public EventHandler Resized {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public void Initialize() {
			throw new NotImplementedException();
		}

		public FormControl ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
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

		public List<FormControl> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new void Dispose(bool dispose) {
			throw new NotImplementedException();
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

		public new EventHandler DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
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
	}
}
