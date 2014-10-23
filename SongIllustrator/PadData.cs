using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongIllustrator {
	public class LightData {
		private int _density;

		public int Density {
			get {
				return _density;
			}
			set {
				_density = value;
			}
		}
		private List<FrameData> _frameData;

		public List<FrameData> FrameData {
			get {
				return _frameData;
			}
			set {
				_frameData = value;
			}
		}
		

	}
}
