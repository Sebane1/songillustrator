using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class ListBoxWrapper : ListBox, SongIllustrator.ArrayView {

		#region ArrayView Members

		public FrameData SelectedItem {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public int SelectedIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<ArrayViewItem> ControlItems {
			get {
				List<ArrayViewItem> items = new List<ArrayViewItem>();
				foreach (ArrayViewItem item in items) {
					items.Add(item);
				}
				return items;
			}
			set {
				Items.Add(value[Items.Count - 1].ToString());
			}
		}

		public List<ArrayViewItem> CheckedItems {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public void SetItemChecked(int p, bool p_2) {
			throw new NotImplementedException();
		}

		#endregion

		#region FormControl Members

		public EventHandler Click {
			get {
				return null;
			}
			set {
				base.Click += value;
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

		public EventHandler KeyDown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler KeyUp {
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

		public int TabIndex {
			get {
				return base.TabIndex;
			}
			set {
				base.TabIndex = value;
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
				return base.Name;
			}
			set {
				base.Name = value;
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

		//public event EventHandler BackColorChanged;

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
