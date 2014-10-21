using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator
{
    public class MilliStopWatch:Timer
    {
        int _elapsed;

        public int Elapsed
        {
            get { return _elapsed; }
        }
        public MilliStopWatch() {
            this.Interval = 1;
            this.Tick += new EventHandler(MilliStopWatch_Tick);
        }

        private void MilliStopWatch_Tick(object sender, EventArgs e)
        {
            _elapsed++;
        }

        public void Reset() {
            _elapsed = 0;
        }
    }
}
