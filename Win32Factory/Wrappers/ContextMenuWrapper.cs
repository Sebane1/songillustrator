using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	public class ContextMenuWrapper : ContextMenu, ContextMenuView {

		#region Menu Members

		public List<SongIllustrator.MenuItemView> Items {
			get {
				List<SongIllustrator.MenuItemView> list = new List<MenuItemView>();
				foreach (MenuItemView view in base.MenuItems) {
					list.Add(view);
				}
				return list;
			}
			set {
				base.MenuItems.Add(value[base.MenuItems.Count].ToString());
			}
		}

		#endregion

		#region FormControl Members

		public EventHandler Click {
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
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
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

		public ControlSize ControlSize {
			get {
				return new ControlSize(0, 0);
			}
			set {
				object val = value;
			}
		}

		public ControlLocation ControlLocation {
			get {
				return new ControlLocation(0, 0);
			}
			set {
				object val = value;
			}
		}

		public event EventHandler BackColorChanged;

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

		public new void Dispose(bool dispose) {
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

		public Color ControlBackColor {
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
