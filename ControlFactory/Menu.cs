using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface Menu : FormControl {
		List<MenuItemView> Items {
			get;
			set;
		}
	}
}
