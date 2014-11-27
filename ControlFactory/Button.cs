using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IButtonView : IView {
		Color ForeColor {
			get;
			set;
		}
	}
}
