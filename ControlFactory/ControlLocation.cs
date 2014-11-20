using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public class ControlLocation {
		public ControlLocation(int x, int y) {
			_x = x;
			_y = y;
		}

		int _x;
		int _y;

		public int X {
			get {
				return _x;
			}
			set {
				_x = value;
			}
		}
		public int Y {
			get {
				return _y;
			}
			set {
				_y = value;
			}
		}
	}
}
