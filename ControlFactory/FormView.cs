using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IFormView : IView, IContainerView {
		void ShowDialog();
		IView MenuStrip {
			get;
			set;
		}

		void EnableFullscreen();

		void DisableFullScreen();
	}
}
