using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IArrayView : IView{


		event EventHandler ItemCheck;
		event EventHandler SelectedIndexChanged;
		event EventHandler SelectedValueChanged;
		IView ContextMenu {
			get;
			set;
		}
		FrameData SelectedItem {
			get;
			set;
		}

		int SelectedIndex {
			get;
			set;
		}
		List<IArrayViewItem> ControlItems {
			get;
		}
		List<IArrayViewItem> CheckedItems {
			get;
		}
		void Clear();
		void Add(IArrayViewItem item);
		void AddRange(IArrayViewItem[] items);
		void AddRange(List<IArrayViewItem> items);
		void Remove(IArrayViewItem item);
		void Remove(int index);
		void SetItemChecked(int p, bool p_2);
	}
}
