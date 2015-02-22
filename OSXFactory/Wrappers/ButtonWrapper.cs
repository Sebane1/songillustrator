using System;
using System.Collections.Generic;
using System.Text;
using MonoMac;
using SongIllustrator;
using System.IO;
using MonoMac.AppKit;
using System.Drawing;

namespace OSXFactory.Wrappers {
	public class ButtonWrapper : ControlWrapper, IButtonView {
		SongIllustrator.Color _color = SongIllustrator.Color.Gray;
		//-------------------------------------------------------
		public ButtonWrapper() {
			NSButton button = new NSButton();
			button.BezelStyle = NSBezelStyle.RoundRect;
			//button.ShouldDrawColor = System.Drawing.Color.Gray;
			try {
				//button.Image = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bevel.png"));
			} catch {
			}
			Click += delegate {
				//MessageBox.Show(button.Name + " " + button.Text + " " + button.TabIndex + " " + button.TabIndex);
			};
			_button = button;
			this.Control = button;
		}
		//-------------------------------------------------------
		private NSButton _button;

		#region IButtonView Members

		public SongIllustrator.Color ForeColor {
			get {
				return SongIllustrator.Color.Aquamarine;
			}
			set {
				_color = value;
			}
		}
		//-------------------------------------------------------
		#endregion
	}
}
