using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Drawing;

namespace OSXFactory.Wrappers {
	public class LabelWrapper : ControlWrapper, ILabelView {
		public LabelWrapper() {
			//this.Control = new NSLabel();
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
