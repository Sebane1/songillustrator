using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IMenu : IView, IContainerView {
		event EventHandler ItemAdded;
		event EventHandler ItemRemoved;
		event EventHandler ItemClicked;
	}
}
