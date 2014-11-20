using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface RichTextBoxView : FormControl {
		string Text {
			get;
			set;
		}

		EventHandler TextChanged {
			get;
			set;
		}
	}
}
