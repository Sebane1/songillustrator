using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public class TutorialFigure {
		public TutorialFigure(Control control, string description) {
			_controlsToFocus.Add(control);
			_description = description;
		}
		public TutorialFigure(List<Control> controls, string description) {
			_controlsToFocus = controls;
			_description = description;
		}
		public TutorialFigure(Control.ControlCollection controls, string description) {
			foreach (Control control in controls) {
				_controlsToFocus.Add(control);
			}
			_description = description;
		}
		private List<Control> _controlsToFocus = new List<Control>();
		private string _description;

		public List<Control> ControlToFocus {
			get {
				return _controlsToFocus;
			}
			set {
				_controlsToFocus = value;
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
