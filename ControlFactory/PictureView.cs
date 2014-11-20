using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SongIllustrator {
	public interface PictureView : FormControl {
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
