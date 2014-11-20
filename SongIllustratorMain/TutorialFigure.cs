using System;
using System.Collections.Generic;
using System.Text;


namespace SongIllustrator {
	public class TutorialFigure {
		public TutorialFigure(FormControl FormControl, string description) {
			_FormControlsToFocus.Add(FormControl);
			_description = description;
		}
		public TutorialFigure(List<FormControl> FormControls, string description) {
			_FormControlsToFocus = FormControls;
			_description = description;
		}
		//public TutorialFigure(FormControl.ControlCollection FormControls, string description) {
		//  foreach (FormControl FormControl in FormControls) {
		//    _FormControlsToFocus.Add(FormControl);
		//  }
		//  _description = description;
		//}
		private List<FormControl> _FormControlsToFocus = new List<FormControl>();
		private string _description;

		public List<FormControl> FormControlToFocus {
			get {
				return _FormControlsToFocus;
			}
			set {
				_FormControlsToFocus = value;
			}
		}
		public string Description {
			get {
				return _description;
			}
			set {
				_description = value;
			}
		}
	}
}
