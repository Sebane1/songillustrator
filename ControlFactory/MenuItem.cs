using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IMenuItemView : IContainerView, IView {
		string Caption {
			get;
			set;
		}

		ControlSize Size {
			get;
			set;
		}
	}
}
