using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IFormView : IView, IContainerView {
		void ShowDialog();
		event EventHandler Closing;
		IView MenuStrip {
			get;
			set;
		}

		void EnableFullscreen();

		void DisableFullScreen();
	}
}
