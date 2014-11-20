using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface TrackBarView : FormControl{
		int Value {
			get;
			set;
		}

		int LargeChange {
			get;
			set;
		}

		int Maximum {
			get;
			set;
		}

		int SmallChange {
			get;
			set;
		}

		int Minimum {
			get;
			set;
		}
	}
}
