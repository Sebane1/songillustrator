using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface ITrackBarView : IView{
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
