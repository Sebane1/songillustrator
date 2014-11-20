using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface ArrayView : FormControl {
		FrameData SelectedItem {
			get;
			set;
		}

		int SelectedIndex {
			get;
			set;
		}
		List<ArrayViewItem> ControlItems {
			get;
			set;
		}
		List<ArrayViewItem> CheckedItems {
			get;
			set;
		}

		void SetItemChecked(int p, bool p_2);
	}
}
