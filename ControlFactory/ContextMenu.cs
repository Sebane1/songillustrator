﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IContextMenuView : IMenu{
		IView Control {
			get;
			set;
		}
	}
}
