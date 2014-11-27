using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public struct ControlSize {
		private int _width;
		private int _height;
		public ControlSize(int width, int height) {
			_width = width;
			_height = height;
		}

		public int Width {
			get {
				return _width;
			}
			set {
				_width = value;
			}
		}
		public int Height {
			get {
				return _height;
			}
			set {
				_height = value;
			}
		}
	}
}
