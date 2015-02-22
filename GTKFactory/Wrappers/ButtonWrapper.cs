using System;
using System.Collections.Generic;
using System.Text;
using SongIllustrator;
using System.IO;
using Gtk;

namespace Win32Factory.Wrappers {
	public class ButtonWrapper : ControlWrapper, IButtonView {
		//-------------------------------------------------------
		public ButtonWrapper() {
			Button button = new Button();
			//button.FlatStyle = FlatStyle.Flat;
			//button.BackColor = System.Drawing.Color.Gray;
			//button.BackgroundImageLayout = ImageLayout.Stretch;
			try {
				//button.BackgroundImage = new Bitmap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bevel.png"));
			} catch {
			}
			Click += delegate {
				//MessageBox.Show(button.Name + " " + button.Text + " " + button.TabIndex + " " + button.TabIndex);
			};
			_button = button;
			this.Control = button;
		}
		//-------------------------------------------------------
		private Button _button;

		#region IButtonView Members

		public SongIllustrator.Color ForeColor {
			get {
				return SongIllustrator.Color.FromArgb(_button.ForeColor.ToArgb());
			}
			set {
				_button.ForeColor = System.Drawing.Color.FromArgb(value.ToArgb());
			}
		}
		//-------------------------------------------------------
		#endregion
	}
}
