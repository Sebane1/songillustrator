using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	class ToolStripMenuItemWrapper : MenuItem, MenuItemView {
		#region MenuItemView Members


		public string Caption {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<MenuItemView> MenuItems {
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

		public new EventHandler Click {
			get {
				return null;
			}
			set {
				base.Click += value;
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


		#endregion

		#region MenuItemView Members


		public ControlSize Size {
			get {
				return new ControlSize(0, 0);
			}
			set {
				object val = value;
			}
		}

		#endregion
	}
}
