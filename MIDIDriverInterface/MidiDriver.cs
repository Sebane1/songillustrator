using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public abstract class MidiDriver {
		private string _name = DateTime.Now.Ticks + "";

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}
		private OperatingSystem _supportedOS;

		public OperatingSystem SupportedOS {
			get {
				return _supportedOS;
			}
		}
		public enum OperatingSystem {
			None = 0,
			Windows = 1,
			Linux = 2,
			Mac = 3
		}
		public MidiDriver(string name, OperatingSystem supportedOS) {
			_name = name;
			_supportedOS = supportedOS;
		}
		public virtual void SendCommand(byte[] command) {

		}
		public virtual byte[] ReceiveCommand() {
			return null;
		}
		public virtual void ShutDown() {

		}
	}
}
