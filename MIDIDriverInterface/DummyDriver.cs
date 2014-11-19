using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;

namespace SongIllustrator {
	internal class DummyDriver : MidiDriver {
		public DummyDriver() : base("", OperatingSystem.None) {
		}
	}
}
