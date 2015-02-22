using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class LabelWrapper : ControlWrapper, ILabelView {
		public LabelWrapper() {
			this.Control = new Label();
		}
		#region IView Members

		public List<IView> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public new void Dispose(bool dispose) {
			throw new NotImplementedException();
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
	}
}
