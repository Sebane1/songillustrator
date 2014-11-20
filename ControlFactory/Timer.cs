using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface Timer : FormControl{
		int Interval {
			get;
			set;
		}
		event EventHandler Tick;
		void Stop();

		void Start();
	}
}
