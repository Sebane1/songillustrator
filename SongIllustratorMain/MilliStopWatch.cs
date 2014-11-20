using System;
using System.Collections.Generic;
using System.Text;

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

		public int Interval {
			get;
			set;
		}

		public EventHandler Tick {
			get;
			set;
		}

		internal void Stop() {
			throw new NotImplementedException();
		}

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

		#endregion

		internal void Start() {
			throw new NotImplementedException();
		}

		#region Timer Members


		void Timer.Stop() {
			throw new NotImplementedException();
		}

		void Timer.Start() {
			throw new NotImplementedException();
		}

		#endregion

		#region Timer Members


		event EventHandler Timer.Tick {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


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

		#endregion

		#region FormControl Members


		public event EventHandler BackColorChanged;

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

		#region Timer Members

		int Timer.Interval {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region FormControl Members


		void FormControl.Initialize() {
			throw new NotImplementedException();
		}

		int FormControl.TabIndex {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		FormControl FormControl.ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		string FormControl.Name {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		ControlSize FormControl.ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		ControlLocation FormControl.ControlLocation {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		event EventHandler FormControl.BackColorChanged {
			add {
				throw new NotImplementedException();
			}
			remove {
				throw new NotImplementedException();
			}
		}

		int FormControl.ControlWidth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		int FormControl.ControlHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		List<FormControl> FormControl.FormControls {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		bool FormControl.Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		void FormControl.Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		int FormControl.Height {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		bool FormControl.Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Load {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.Shown {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		EventHandler FormControl.DoubleClick {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		string FormControl.Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		Color FormControl.ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

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
