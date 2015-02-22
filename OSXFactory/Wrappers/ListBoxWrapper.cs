using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Drawing;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace OSXFactory.Wrappers {
	public class ListBoxWrapper : ControlWrapper, IArrayView {
		NSComboBox tableColumn;
		FrameData _selectedItem;
		#region IArrayView Members
		public ListBoxWrapper() {
			//NSComboBox box = new NSComboBox ();
			tableColumn = new NSComboBox ();;
			tableColumn.Changed += delegate {
				if (SelectedIndexChanged != null) {
					SelectedIndexChanged (this, EventArgs.Empty);
				}
			};
			tableColumn.Changed += delegate(object sender, EventArgs e) {

			};
			this.Control = tableColumn;
		}

/*		void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
			_checkedItems.Add((Control as CheckedListBox).Items[e.Index] as IArrayViewItem);
			if (ItemCheck != null) {
				ItemCheck(this, EventArgs.Empty);
			}
		}*/

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
			//(Control as CheckedListBox).SetSelected(p, p_2);
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
				return _selectedItem;
				//return (Control as CheckedListBox).SelectedItem as FrameData;
			}
			set {
				_selectedItem = value;
				//(Control as CheckedListBox).SelectedItem = value;
			}
		}

		public int SelectedIndex {
			get {
				return -1;
				//return (Control as CheckedListBox).SelectedIndex;
			}
			set {
				int blah = value;
				//(Control as CheckedListBox).SelectedIndex = value;
			}
		}

		#endregion

		#region IArrayView Members


		public void Add(IArrayViewItem item) {
			_items.Add(item);
			tableColumn.Add (item as NSObject);
			//(Control as CheckedListBox).Items.Add(item);
		}

		public void Remove(IArrayViewItem item) {
			//(Control as CheckedListBox).Items.Remove(item);
			_items.Remove(item);
		}

		public void Remove(int index) {
			//(Control as CheckedListBox).Items.Remove(index);
			_items.RemoveAt(index);
		}

		#endregion

		#region IArrayView Members


		public void Clear() {
			_items.Clear();
			//Control as CheckedListBox).Items.Clear();
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
				return (Control as NSComboBox).Menu as IView;
			}
			set {
				(Control as NSComboBox).Menu = (value as IContextMenuView) as NSMenu;
			}
		}

		#endregion
	}
}
