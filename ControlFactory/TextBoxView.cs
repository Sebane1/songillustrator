using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface ITextBoxView : IView{
		event EventHandler TextChanged;

		bool ReadOnly {
			get;
			set;
		}

		bool Multiline {
			get;
			set;
		}

		bool HideSelection {
			get;
			set;
		}
	}
}
