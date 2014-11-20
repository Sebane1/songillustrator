using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;

namespace Win32Factory.Wrappers {
	public class SaveDialogWrapper : SaveFileDialogView {
		#region SaveFileDialogView Members

		SaveFileDialog dialog = new SaveFileDialog();
		public string Filter {
			get {
				return dialog.Filter;
			}
			set {
				dialog.Filter = value;
			}
		}

		public PopupResult ShowDialog() {
			switch (dialog.ShowDialog()) {
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

		public IEnumerable<string> FileNames {
			get {
				return dialog.FileNames;
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string FileName {
			get {
				return dialog.FileName;
			}
			set {
				dialog.FileName = value;
			}
		}

		#endregion
	}
}
