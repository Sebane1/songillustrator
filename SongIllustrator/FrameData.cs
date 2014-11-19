using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SongIllustrator
{
    public class FrameData
    {
        List<Color> _colours = new List<Color>();
        decimal _timeStamp;
				bool _fired = false;
				private int _index;

				public int Index {
					get {
						return _index;
					}
					set {
						_index = value;
					}
				}

				public bool Fired {
					get {
						return _fired;
					}
					set {
						_fired = value;
					}
				}

        public decimal TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        public List<Color> Colours
        {
            get { return _colours; }
            set { _colours = value; }
        }

				/// <summary>
				/// An override of the ToString() method.
				/// </summary>
				/// <returns>The frame data's index.</returns>
				public override string ToString() {
					return "Frame " + Index;
				}
    }
}
