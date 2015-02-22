using System;
using System.Collections.Generic;
using System.Text;

namespace SongIllustrator {
	public interface IView {
		event EventHandler Click;
		event EventHandler RightClicked;
		event EventHandler MouseLeftUp;
		event EventHandler MouseRightUp;
		event EventHandler MouseLeftDown;
		event EventHandler MouseRightDown;
		event EventHandler KeyDown;
		event EventHandler KeyUp;
		event EventHandler Resized;
		event EventHandler BackColorChanged;
		void Initialize();
		int TabIndex {
			get;
			set;
		}
		IView ParentControl {
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

		int ControlWidth {
			get;
			set;
		}
		int ControlHeight {
			get;
			set;
		}
		void AddControl(IView control);
		void RemoveControl(IView control);
		void RemoveControl(int index);
		bool Visible {
			get;
			set;
		}
		void Dispose(bool dispose);

		bool Enabled {
			get;
			set;
		}


		event System.EventHandler Load;

		event System.EventHandler Shown;

		event System.EventHandler DoubleClick;

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
