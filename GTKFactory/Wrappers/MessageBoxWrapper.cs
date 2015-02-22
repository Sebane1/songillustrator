using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory {
	public class MessageBoxWrapper : IMessageBox {
		#region IMessageBox Members

		public SongIllustrator.PopupResult SendMessage(string message, string title, SongIllustrator.AlertButtons buttons, SongIllustrator.TypeOfAlert alertType) {
			MessageBoxButtons buttonLayout = MessageBoxButtons.OK;;
			MessageBoxIcon icon = MessageBoxIcon.None;
			switch(buttons){
				case SongIllustrator.AlertButtons.None:
					break;
				case SongIllustrator.AlertButtons.Ok:
					buttonLayout = MessageBoxButtons.OK;
					break;
				case SongIllustrator.AlertButtons.OkCancel:
					buttonLayout = MessageBoxButtons.OKCancel;
					break;
				case SongIllustrator.AlertButtons.YesCancel:
					buttonLayout = MessageBoxButtons.YesNoCancel;
					break;
				case SongIllustrator.AlertButtons.YesNo:
					buttonLayout = MessageBoxButtons.YesNo;
					break;
				case SongIllustrator.AlertButtons.YesNoCancel:
					buttonLayout = MessageBoxButtons.YesNoCancel;
					break;
			}
			switch(alertType){
				case SongIllustrator.TypeOfAlert.Error:
					icon = MessageBoxIcon.Error;
					break;
				case SongIllustrator.TypeOfAlert.Information:
					icon = MessageBoxIcon.Information;
					break;
				case SongIllustrator.TypeOfAlert.None:
					icon = MessageBoxIcon.None;
					break;
				case SongIllustrator.TypeOfAlert.Question:
					icon = MessageBoxIcon.Question;
					break;
				case SongIllustrator.TypeOfAlert.Warning:
					icon = MessageBoxIcon.Warning;
					break;
			}
			switch (MessageBox.Show(message, title, buttonLayout, icon)) {
				case DialogResult.Abort:
					return PopupResult.Abort;
				case DialogResult.Cancel:
					return PopupResult.Cancel;
				case DialogResult.Ignore:
					return PopupResult.Ignore;
				case DialogResult.No:
					return PopupResult.No;
				case DialogResult.None:
					return PopupResult.None;
				case DialogResult.OK:
					return PopupResult.Ok;
				case DialogResult.Retry:
					return PopupResult.Retry;
				case DialogResult.Yes:
					return PopupResult.Yes;
			}
			return PopupResult.None;

		}

		#endregion
	}
}
