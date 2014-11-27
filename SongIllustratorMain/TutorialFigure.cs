using System;
using System.Collections.Generic;
using System.Text;


namespace SongIllustrator {
	public class TutorialFigure {
		public TutorialFigure(IView FormControl, string description) {
			_FormControlsToFocus.Add(FormControl);
			_description = description;
		}
		public TutorialFigure(List<IView> FormControls, string description) {
			_FormControlsToFocus = FormControls;
			_description = description;
		}
		//public TutorialFigure(IView.ControlCollection ViewItems, string description) {
		//  foreach (IView IView in ViewItems) {
		//    _FormControlsToFocus.Add(IView);
		//  }
		//  _description = description;
		//}
		private List<IView> _FormControlsToFocus = new List<IView>();
		private string _description;

		public List<IView> FormControlToFocus {
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
