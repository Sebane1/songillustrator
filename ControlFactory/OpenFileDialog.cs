using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface OpenFileDialogView {
		string Filter {
			get;
			set;
		}

		PopupResult ShowDialog();

		IEnumerable<string> FileNames {
			get;
			set;
		}

		string FileName {
			get;
			set;
		}
	}
}
