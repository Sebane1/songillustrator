using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IRichTextBoxView : IView {
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
