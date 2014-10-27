using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobiasErichsen.teVirtualMIDI;

namespace SongIllustrator {
	public class Launchpad {
		private int _density;

		public int Density {
			get {
				return _density;
			}
			set {
				_density = value;
			}
		}
		private List<FrameData> _frameData = new List<FrameData>();

		public List<FrameData> FrameData {
			get {
				return _frameData;
			}
			set {
				_frameData = value;
			}
		}
		TeVirtualMIDI _port;
		private System.Threading.Thread _thread;

		public System.Threading.Thread Thread {
			get {
				return _thread;
			}
			set {
				_thread = value;
			}
		}
		private bool _listenToMidi = true;

		public bool ListenToMidi {
			get {
				return _listenToMidi;
			}
			set {
				_listenToMidi = value;
			}
		}
		public TeVirtualMIDI Port {
			get {
				return _port;
			}
			set {
				_port = value;
			}
		}

	}
}
