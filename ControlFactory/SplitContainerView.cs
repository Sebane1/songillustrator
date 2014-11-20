using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface SplitContainerView : FormControlContainer {
		int SplitterDistance {
			get;
			set;
		}
	}
}
