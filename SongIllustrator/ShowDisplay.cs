using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SongIllustrator {
	public partial class ShowDisplay : Form {
		public ShowDisplay() {
			InitializeComponent();
		}
		private Stream _overlayImage;

		public Stream OverlayImage {
			get {
				return _overlayImage;
			}
			set {
				_overlayImage = value;
			}
		}

		public Panel PadLights {
			get {
				return panel1;
			}
			set {
				panel1 = value;
			}
		}
		int _pixels = 8;
		public Form1 Creator;
		public Panel Canvas {
			get {
				return panel1;
			}
			set {
				panel1 = value;
			}
		}

		private void CheckImage() {
			List<List<DisplayButton>> displayButtonsList = new List<List<DisplayButton>>();
			foreach (LightPad launchPad in Canvas.Controls) {
				List<DisplayButton> displayButtons = new List<DisplayButton>();
				foreach (DisplayButton displayButton in launchPad.LightCanvas.Controls) {
					displayButtons.Add(displayButton);
				}
				displayButtonsList.Add(displayButtons);
			}
			if (displayButtonsList.Count > 0) {
				Creator.OverlayButtons(_overlayImage, displayButtonsList);
			}
		}

		private void ShowDisplay_Load(object sender, EventArgs e) {
			panel1.Width = this.Height;
			panel1.Location = new Point((this.Width / 2) - (panel1.Width / 2), this.Location.Y);
		}

		private void ShowDisplay_Shown(object sender, EventArgs e) {
			panel1.Controls.Clear();
			if (Creator.LaunchPads != null) {
				Creator.GeneratePads(Creator.LaunchPads, panel1);
				if (_overlayImage != null) {
					CheckImage();
				}
			}
		}
		//public void GeneratePixels(int pixels)
		//{
		//    panel1.Controls.Clear();
		//    Size buttonSize = new Size(panel1.Width / pixels, panel1.Height / pixels);
		//    for (int heightProgression = 0; heightProgression < pixels; heightProgression++)
		//    {

		//        for (int widthProgression = 0; widthProgression < pixels; widthProgression++)
		//        {
		//            DisplayButton button = new DisplayButton();
		//            button.Size = buttonSize;
		//            button.Location = new Point(buttonSize.Width * widthProgression, buttonSize.Height * heightProgression);
		//            panel1.Controls.Add(button);
		//        }
		//    }
		//    Form1 form = (Form1)this.Parent;
		//    if (OverlayImage != null)
		//    {
		//        OverlayButtons(OverlayImage, PadLights.Controls);
		//    }
		//}
		//public void OverlayButtons(Stream bitmapStream, Control.ControlCollection controls)
		//{
		//    List<Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.Size, new Size(Pixels, Pixels));
		//    for (int i = 0; i < controls.Count; i++)
		//    {
		//        controls[i].BackgroundImage = images[i];
		//    }
		//}

		private void ShowDisplay_DoubleClick(object sender, EventArgs e) {
			this.Hide();
		}
	}
}
