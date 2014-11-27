using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;

namespace Win32Factory.Wrappers {
	public class MenuItemWrapper : IMenuItemView {
		MenuItem _menuItem;
		public MenuItemWrapper(){
			MenuItem = new MenuItem();
		}

		#region IMenuItemView Members

		public string Caption {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlSize Size {
			get {
				return _size;
			}
			set {
				_size = value;
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

		public void AddRange(IView[] items) {
			
		}

		public void AddRange(List<IView> items) {
			
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

		#region IView Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;

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
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public event EventHandler Load;

		public event EventHandler Shown;

		public event EventHandler DoubleClick;
		private SongIllustrator.ControlSize _size;

		public string Text {
			get {
				return _menuItem.Text;
			}
			set {
				_menuItem.Text = value;
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

		public MenuItem MenuItem {
			get {
				return _menuItem;
			}
			set {
				_menuItem = value;
				_menuItem.Click += delegate {
					if (Click != null) {
						Click(this, EventArgs.Empty);
					}
				};
			}
		}
	}
}
