using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class ListBoxWrapper : ControlWrapper, IArrayView {
		#region IArrayView Members
		public ListBoxWrapper() {
			CheckedListBox checkedListBox = new CheckedListBox();
			checkedListBox.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
			checkedListBox.SelectedIndexChanged += delegate {
				if (SelectedIndexChanged != null) {
					SelectedIndexChanged(this, EventArgs.Empty);
				}
			};
			checkedListBox.SelectedValueChanged += delegate {
				if (SelectedValueChanged != null) {
					//SelectedValueChanged(this, EventArgs.Empty);
				}
			};
			this.Control = checkedListBox;
		}

		void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
			_checkedItems.Add((Control as CheckedListBox).Items[e.Index] as IArrayViewItem);
			if (ItemCheck != null) {
				ItemCheck(this, EventArgs.Empty);
			}
		}

		public List<IArrayViewItem> ControlItems {
			get {
				return _items;
			}
			set {
				_items = value;
			}
		}

		public List<IArrayViewItem> CheckedItems {
			get {
				return _checkedItems;
			}
			set {
				_checkedItems = value;
			}
		}

		public void SetItemChecked(int p, bool p_2) {
			(Control as CheckedListBox).SetSelected(p, p_2);
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
		#endregion

		#region IArrayView Members

		public event EventHandler ItemCheck;

		public event EventHandler SelectedIndexChanged;

		public event EventHandler SelectedValueChanged;
		private List<IArrayViewItem> _items = new List<IArrayViewItem>();
		private List<IArrayViewItem> _checkedItems = new List<IArrayViewItem>();

		public FrameData SelectedItem {
			get {
				return (Control as CheckedListBox).SelectedItem as FrameData;
			}
			set {
				(Control as CheckedListBox).SelectedItem = value;
			}
		}

		public int SelectedIndex {
			get {
				return (Control as CheckedListBox).SelectedIndex;
			}
			set {
				(Control as CheckedListBox).SelectedIndex = value;
			}
		}

		#endregion

		#region IArrayView Members


		public void Add(IArrayViewItem item) {
			_items.Add(item);
			(Control as CheckedListBox).Items.Add(item);
		}

		public void Remove(IArrayViewItem item) {
			(Control as CheckedListBox).Items.Remove(item);
			_items.Remove(item);
		}

		public void Remove(int index) {
			(Control as CheckedListBox).Items.Remove(index);
			if (index < _items.Count) {
				_items.RemoveAt(index);
			}
		}

		#endregion

		#region IArrayView Members


		public void Clear() {
			_items.Clear();
			(Control as CheckedListBox).Items.Clear();
			_checkedItems.Clear();
		}

		public void AddRange(IArrayViewItem[] items) {
			foreach (IArrayViewItem item in items) {
				Add(item);
			}
		}

		public void AddRange(List<IArrayViewItem> items) {
			AddRange(items.ToArray());
		}

		#endregion

		#region IArrayView Members


		public IView ContextMenu {
			get {
				return (Control as CheckedListBox).ContextMenu as IView;
			}
			set {
				(Control as CheckedListBox).ContextMenu = (value as IContextMenuView) as ContextMenu;
			}
		}

		#endregion
	}
}
