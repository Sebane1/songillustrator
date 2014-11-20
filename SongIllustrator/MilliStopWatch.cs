using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public class MilliStopWatch : Timer {
		int _elapsed;

		public int Elapsed {
			get {
				return _elapsed;
			}
		}
		public MilliStopWatch() {
			this.Interval = 1;
			this.Tick += new EventHandler(MilliStopWatch_Tick);
		}

		private void MilliStopWatch_Tick(object sender, EventArgs e) {
			_elapsed++;
		}

		public void Reset() {
			_elapsed = 0;
		}

		#region Timer Members

		public int Interval {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public event EventHandler Tick;

		public void Stop() {
			throw new NotImplementedException();
		}

		public void Start() {
			throw new NotImplementedException();
		}

		#endregion

		#region FormControl Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public int TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public FormControl ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Name {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlSize ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ControlLocation ControlLocation {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public event EventHandler BackColorChanged;

		public int ControlWidth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public int ControlHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public List<FormControl> FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public void Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		public int Height {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public bool Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler Load {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler Shown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public EventHandler DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


		#endregion

		#region FormControl Members

		EventHandler FormControl.Click {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.RightClicked {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.KeyDown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.KeyUp {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Resized {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
