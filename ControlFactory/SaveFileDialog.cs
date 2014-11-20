using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface SaveFileDialogView {
		PopupResult ShowDialog();

		string Filter {
			get;
			set;
		}

		string FileName {
			get;
			set;
		}
	}
}
