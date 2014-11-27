using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;

namespace SongIllustrator {
	public interface IMessageBox {
		PopupResult SendMessage(string message, string title, AlertButtons buttons, TypeOfAlert alertType);
	}
}
