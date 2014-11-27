using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SongIllustrator;

namespace Win32Factory.Wrappers {
	public class PictureBoxWrapper : ControlWrapper, IPictureView{
		public PictureBoxWrapper() {
			this.Control = new PictureBox();
		}
		#region IPictureView Members

		public System.IO.Stream Image {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool TabStop {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public System.IO.Stream BackgroundImage {
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
