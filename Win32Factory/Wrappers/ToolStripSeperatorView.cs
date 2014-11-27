using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class ToolStripSeparatorWrapper : ControlWrapper, IMenuItemSeperator{
		#region IMenuItemView Members


		public string Caption {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<IMenuItemView> MenuItems {
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
		#endregion

		#region IContainerView Members

		public Dictionary<int, IView> ViewList {
			get {
				throw new NotImplementedException();
			}
		}

		public void Clear() {
			throw new NotImplementedException();
		}

		public void Add(IView item) {
			throw new NotImplementedException();
		}

		public void Remove(IView item) {
			throw new NotImplementedException();
		}

		public void Remove(int index) {
			throw new NotImplementedException();
		}

		public int Count {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IContainerView Members


		public void AddRange(IView[] items) {
			throw new NotImplementedException();
		}

		public void AddRange(List<IView> items) {
			throw new NotImplementedException();
		}

		#endregion

		#region IMenuItemView Members


		public ControlSize Size {
			get {
				return new ControlSize(this.Control.Width, this.Control.Height);
			}
			set {
				this.Control.Size = new Size(value.Width, value.Height);
			}
		}

		#endregion
	}
}
