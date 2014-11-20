using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface FormControlContainer {

		EventHandler Click {
			get;
			set;
		}
		EventHandler RightClicked {
			get;
			set;
		}
		EventHandler KeyDown {
			get;
			set;
		}
		EventHandler KeyUp {
			get;
			set;
		}
		EventHandler Resized {
			get;
			set;
		}
		void Initialize();
		int TabIndex {
			get;
			set;
		}
		FormControl ParentControl {
			get;
			set;
		}
		string Name {
			get;
			set;
		}
		ControlSize ControlSize {
			get;
			set;
		}
		ControlLocation ControlLocation {
			get;
			set;
		}
		event EventHandler BackColorChanged;
		int ControlWidth {
			get;
			set;
		}
		int ControlHeight {
			get;
			set;
		}
		bool Visible {
			get;
			set;
		}
		void Dispose(bool dispose);

		int Height {
			get;
			set;
		}

		bool Enabled {
			get;
			set;
		}


		System.EventHandler Load {
			get;
			set;
		}

		System.EventHandler Shown {
			get;
			set;
		}

		System.EventHandler DoubleClick {
			get;
			set;
		}

		string Text {
			get;
			set;
		}

		Color ControlBackColor {
			get;
			set;
		}
	}
}