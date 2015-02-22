using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace OSXFactory.Wrappers {
	public class OpenFileDialogWrapper : OpenFileDialogView {
		#region OpenFileDialogView Members
		NSOpenPanel dialog = new NSOpenPanel();
		public string Filter {
			get {
				return dialog.AllowedFileTypes[0];
			}
			set {
				dialog.AllowedFileTypes[0] = value;
			}
		}

		public PopupResult ShowDialog() {
			switch (dialog.RunModal()) {
				case 1:
					return PopupResult.Ok;
			}
			return PopupResult.None;
		}

		public IEnumerable<string> FileNames {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string FileName {
			get {
				return dialog.DirectoryUrl.AbsoluteString;
			}
			set {
				dialog.DirectoryUrl = new NSUrl(value);
			}
		}

		#endregion
	}
}
