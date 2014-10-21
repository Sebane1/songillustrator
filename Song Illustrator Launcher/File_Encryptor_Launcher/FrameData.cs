using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SongIllustrator
{
    public class FrameData
    {
        List<Color> _colours = new List<Color>();
        int _timeStamp;

        public int TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        public List<Color> Colours
        {
            get { return _colours; }
            set { _colours = value; }
        }
    }
}
