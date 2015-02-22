using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	public class ContextMenuWrapper : IContextMenuView {
		public ContextMenuWrapper() {
			//ContextMenu menu = new ContextMenu();
			//this.Control = menu as IView;
		}
		#region IMenu Members

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

		#endregion

		#region IMenu Members

		public event EventHandler ItemAdded;

		public event EventHandler ItemRemoved;

		public event EventHandler ItemClicked;
		private List<IMenuItemView> _items = new List<IMenuItemView>();
		private Dictionary<int, IView> _viewList = new Dictionary<int, IView>();

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
			MenuItems.Add((item as MenuItemWrapper).MenuItem);
		}

		public void Remove(IView item) {
			//_viewList.Remove(item);
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

		#region IContainerView Members

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

		public ControlSize ControlSize {
			get {
				return _controlSize;
			}
			set {
				_controlSize = value;
			}
		}

		public ControlLocation ControlLocation {
			get {
				return _controlLocation;
			}
			set {
				_controlLocation = value;
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
		private IView _control;
		private ControlSize _controlSize;
		private ControlLocation _controlLocation;
		private string _name;

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

		#region IContextMenuView Members

		IView Control {
			get {
				return _control;
			}
			set {
				_control = value;
			}
		}

		#endregion

		#region IView Members


		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		#endregion

		#region IContextMenuView Members

		IView IContextMenuView.Control {
			get {
				return _control;
			}
			set {
				_control = value;
			}
		}

		#endregion
	}
}
