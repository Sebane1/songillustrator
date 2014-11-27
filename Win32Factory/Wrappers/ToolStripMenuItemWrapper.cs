using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	class ToolStripMenuItemWrapper : IMenuItemView {
		private Dictionary<int, IView> _items = new Dictionary<int, IView>();
		ToolStripMenuItem _menuItem = new ToolStripMenuItem();
		private string _name;

		public ToolStripMenuItem MenuItem {
			get {
				return _menuItem;
			}
			set {
				_menuItem = value;
			}
		}
		public ToolStripMenuItemWrapper() {
			_menuItem = new ToolStripMenuItem();
			_menuItem.Name = _name;
			_menuItem.Click += delegate {
				if (Click != null) {
					Click(this, EventArgs.Empty);
				}
			};
		}
		#region IMenuItemView Members


		public string Text {
			get {
				return _menuItem.Text;
			}
			set {
				_menuItem.Text = value;
			}
		}



		#endregion

		#region IMenuItemView Members


		public ControlSize Size {
			get {
				return new ControlSize(0, 0);
			}
			set {
				object val = value;
			}
		}

		#endregion

		#region IContainerView Members

		public Dictionary<int, IView> ViewList {
			get {
				return _items;
			}
		}

		public void Clear() {
			_items.Clear();
		}

		public void Add(IView item) {
			_items.Add(_items.Count, item);
			//_menuItem.HasDropDownItems = true;
			ToolStripMenuItemWrapper menuItem = (item as ToolStripMenuItemWrapper);
			if (menuItem != null) {
				_menuItem.DropDownItems.Add(menuItem.MenuItem);
			}
		}

		public void Remove(IView item) {
			//m_items.Remove(item);
		}

		public void Remove(int index) {
			_items.Remove(index);
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
			foreach (IView item in items) {
				Add(item);
			}
		}

		public void AddRange(List<IView> items) {
			AddRange(items.ToArray());
		}

		#endregion

		#region IMenuItemView Members

		public string Caption {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public event EventHandler BackColorChanged;

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

		public IView ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Name {
			get {
				return _menuItem.Name;
			}
			set {
				_menuItem.Name = value;
			}
		}

		public ControlSize ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlLocation ControlLocation {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
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

		public void AddControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(int index) {
			throw new NotImplementedException();
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
				return _menuItem.Enabled;
			}
			set {
				_menuItem.Enabled = value;
			}
		}

		public event EventHandler Load;

		public event EventHandler Shown;

		public event EventHandler DoubleClick;

		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;

		#endregion
	}
}
