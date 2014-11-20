using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface TextBoxView : FormControl{
		EventHandler TextChanged {
			get;
			set;
		}

		bool ReadOnly {
			get;
			set;
		}

		bool Multiline {
			get;
			set;
		}

		bool HideSelection {
			get;
			set;
		}
	}
}
