using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	public class RichTextBoxWrapper  : ControlWrapper, IRichTextBoxView {
		public RichTextBoxWrapper() {
			this.Control = new RichTextBox();
		}
		#region IRichTextBoxView Members

		#endregion

		#region IView Members
		public new void Dispose(bool dispose) {
			throw new NotImplementedException();
		}
		#endregion

		#region IRichTextBoxView Members


		public EventHandler TextChanged {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
