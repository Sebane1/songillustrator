using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SongIllustrator {
	public interface IPictureView : IView {
		Stream Image {
			get;
			set;
		}

		bool TabStop {
			get;
			set;
		}

		Stream BackgroundImage {
			get;
			set;
		}
	}
}
