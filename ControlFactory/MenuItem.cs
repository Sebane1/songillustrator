using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface MenuItemView {
		string Name {
			get;
			set;
		}
		string Caption {
			get;
			set;
		}
		List<MenuItemView> MenuItems {
			get;
			set;
		}

		EventHandler Click {
			get;
			set;
		}

		string Text {
			get;
			set;
		}

		ControlSize Size {
			get;
			set;
		}

		bool Enabled {
			get;
			set;
		}
	}
}
