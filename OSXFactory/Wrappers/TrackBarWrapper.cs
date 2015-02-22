using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Drawing;
using MonoMac.AppKit;

namespace OSXFactory.Wrappers {
	public class TrackBarWrapper : ControlWrapper, ITrackBarView {
		public TrackBarWrapper() {
			//this.Control = new ();
			//_trackbar = (Control as TrackBar);
		}
		//TrackBar _trackbar;
		#region ITrackBarView Members

		public int Value {
			get {
				//return _trackbar.Value;
				return 0;
			}
			set {
				int blah = 0;
				//_trackbar.Value = value;
			}
		}

		public int LargeChange {
			get {
				throw new NotImplementedException ();
				//return _trackbar.LargeChange;
			}
			set {
				throw new NotImplementedException ();
				//_trackbar.LargeChange = value;
			}
		}

		public int Maximum {
			get {
				return 0;
				//return _trackbar.Maximum;
			}
			set {
				int blah = 0;
				//_trackbar.Maximum = value;
			}
		}

		public int SmallChange {
			get {
				throw new NotImplementedException ();
				//return _trackbar.SmallChange;
			}
			set {
				throw new NotImplementedException ();
				//_trackbar.SmallChange = value;
			}
		}

		public int Minimum {
			get {
				throw new NotImplementedException ();
				//return _trackbar.Minimum;
			}
			set {
				throw new NotImplementedException ();
				//_trackbar.Minimum = value;
			}
		}

		#endregion
	}
}
