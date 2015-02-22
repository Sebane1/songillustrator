using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.Windows.Forms;
using System.Drawing;

namespace Win32Factory.Wrappers {
	public class TrackBarWrapper : ControlWrapper, ITrackBarView {
		public TrackBarWrapper() {
			this.Control = new TrackBar();
			_trackbar = (Control as TrackBar);
		}
		TrackBar _trackbar;
		#region ITrackBarView Members

		public int Value {
			get {
				return _trackbar.Value;
			}
			set {
				_trackbar.Value = value;
			}
		}

		public int LargeChange {
			get {
				return _trackbar.LargeChange;
			}
			set {
				_trackbar.LargeChange = value;
			}
		}

		public int Maximum {
			get {
				return _trackbar.Maximum;
			}
			set {
				_trackbar.Maximum = value;
			}
		}

		public int SmallChange {
			get {
				return _trackbar.SmallChange;
			}
			set {
				_trackbar.SmallChange = value;
			}
		}

		public int Minimum {
			get {
				return _trackbar.Minimum;
			}
			set {
				_trackbar.Minimum = value;
			}
		}

		#endregion
	}
}
