using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Drawing;
using MonoMac.AppKit;

namespace OSXFactory.Wrappers {
	public class TextBoxWrapper : ControlWrapper, ITextBoxView {
		public TextBoxWrapper() {
			this.Control = new NSTextField();
		}
		#region ITextBoxView Members


		#endregion

		#region IView Members

		public List<IView> FormControls {
			get {
				return FormControls;
			}
			set {
				FormControls = value;
			}
		}

		public new void Dispose(bool dispose) {
			Dispose(dispose);
		}


		#endregion

		#region ITextBoxView Members

		#endregion

		#region IView Members

		public new EventHandler Click {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new EventHandler DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		#endregion

		#region IView Members


		public new EventHandler KeyDown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new EventHandler KeyUp {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members

		#endregion

		#region ITextBoxView Members


		public bool ReadOnly {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Multiline {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool HideSelection {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region ITextBoxView Members

		public event EventHandler TextChanged;

		#endregion

		#region ITextBoxView Members

		#endregion
	}
}
