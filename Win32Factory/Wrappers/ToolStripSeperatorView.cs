using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	public class ToolStripSeparatorWrapper : ToolStripSeparator, MenuItemSeperator{
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
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new EventHandler Click {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new ControlSize Size {
			get {
				return new ControlSize(0, 0);
			}
			set {
				object text = value;
			}
		}

		#endregion
	}
}
