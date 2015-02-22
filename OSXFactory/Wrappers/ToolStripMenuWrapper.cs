using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Drawing;
using MonoMac.AppKit;

namespace OSXFactory.Wrappers {
	public class ToolStripMenuWrapper : ControlWrapper, IToolStripMenuView {
		NSMenu _menuStrip;
		#region IMenu Members
		public ToolStripMenuWrapper() {
			_menuStrip = new NSMenu();
			if (this.Control != null) {
				this.Control.Dispose();
			}
			//this.Control = _menuStrip;
			/*_menuStrip.ItemAdded += delegate {
				if (ItemAdded != null) {
					ItemAdded(this, EventArgs.Empty);
				}
			};*/
			/*
			_menuStrip.c += delegate {
				if (ItemClicked != null) {
					ItemClicked(this, EventArgs.Empty);
				}
			};*/
			/*
				_menuStrip.ItemRemoved += delegate {
					if (ItemRemoved != null) {
						ItemRemoved(this, EventArgs.Empty);
					}
				};*/
		}
		#endregion

		#region IView Members

		public List<IView> FormControls {
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
		public new EventHandler DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IToolStripMenuView Members

		public event EventHandler ItemAdded;

		public event EventHandler ItemRemoved;

		public event EventHandler ItemClicked;
		private List<IMenuItemView> _items = new List<IMenuItemView>();
		private Dictionary<int, IView> _viewList = new Dictionary<int, IView>();

		#endregion

		#region IMenu Members
		#endregion

		#region IMenu Members


		public List<IMenuItemView> Items {
			get {
				return _items;
			}
			set {
				_items = value;
			}
		}

		#endregion

		#region IContainerView Members

		public Dictionary<int, IView> ViewList {
			get {
				return _viewList;
			}
		}

		public void Clear() {
			_viewList.Clear();
		}

		public void Add(IView item) {
			_viewList.Add(_viewList.Count, item);
			_menuStrip.AddItem((item as ToolStripMenuItemWrapper).MenuItem);
		}

		public void Remove(IView item) {
			//viewList.Remove(item);
		}

		public void Remove(int index) {
			_viewList.Remove(index);
		}

		public void AddRange(IView[] items) {
			foreach (IView view in items) {
				Add(view);
			}
		}

		public void AddRange(List<IView> items) {
			AddRange(items.ToArray());
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
	}
}
