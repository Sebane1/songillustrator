using System;
using System.Collections.Generic;
using System.Text;
using ControlFactory;

namespace SongIllustrator {
	public class Alert {
		public static PopupResult Send(string caption, string title, TypeOfAlert alertType, AlertButtons buttons, IFactory factory) {
			return factory.BuildPopup().SendMessage(caption,title,buttons,alertType);
		}
	}
}
