using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO;

namespace SongIllustrator {
	public partial class ShowDisplay : FormControl{
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

		//public FormControl PadLights {
		//  get {
		//    return panel1;
		//  }
		//  set {
		//    panel1 = value;
		//  }
		//}
		int _pixels = 8;
		public BaseForm Creator;
		//public FormControl Canvas {
		//  //get {
		//  //  return panel1;
		//  //}
		//  //set {
		//  //  panel1 = value;
		//  //}
		//}

		private void CheckImage() {
			//List<List<MacroButton>> displayButtonsList = new List<List<MacroButton>>();
			//foreach (LightPad launchPad in Canvas.FormControls) {
			//  List<MacroButton> displayButtons = new List<MacroButton>();
			//  foreach (MacroButton displayButton in launchPad.LightCanvas.FormControls) {
			//    displayButtons.Add(displayButton);
			//  }
			//  displayButtonsList.Add(displayButtons);
			//}
			//if (displayButtonsList.Count > 0) {
			//  Creator.OverlayButtons(_overlayImage, displayButtonsList);
			//}
		}

		private void ShowDisplay_Load(object sender, EventArgs e) {
			//panel1.ControlWidth = this.Height;
			//panel1.ControlLocation = new ControlLocation((this.ControlWidth / 2) - (panel1.ControlWidth / 2), this.ControlLocation.Y);
		}

		private void ShowDisplay_Shown(object sender, EventArgs e) {
			//panel1.FormControls.Clear();
			//if (Creator.LaunchPads != null) {
			//  Creator.GeneratePads(Creator.LaunchPads, panel1);
			//  if (_overlayImage != null) {
			//    CheckImage();
			//  }
			//}
		}
		//public void GeneratePixels(int pixels)
		//{
		//    panel1.FormControls.Clear();
		//    ControlSize buttonSize = new ControlSize(panel1.ControlWidth / pixels, panel1.Height / pixels);
		//    for (int heightProgression = 0; heightProgression < pixels; heightProgression++)
		//    {

		//        for (int widthProgression = 0; widthProgression < pixels; widthProgression++)
		//        {
		//            MacroButton button = new MacroButton();
		//            button.ControlSize = buttonSize;
		//            button.ControlLocation = new Point(buttonSize.ControlWidth * widthProgression, buttonSize.Height * heightProgression);
		//            panel1.FormControls.Add(button);
		//        }
		//    }
		//    BaseForm form = (BaseForm)this.ParentControl;
		//    if (OverlayImage != null)
		//    {
		//        OverlayButtons(OverlayImage, PadLights.FormControls);
		//    }
		//}
		//public void OverlayButtons(Stream bitmapStream, FormControl.FormControlCollection FormControls)
		//{
		//    List<Image> images = ImageSlicer.SliceImage(new Bitmap(bitmapStream), panel1.ControlSize, new ControlSize(Pixels, Pixels));
		//    for (int i = 0; i < FormControls.Count; i++)
		//    {
		//        FormControls[i].BackgroundImage = images[i];
		//    }
		//}

		private void ShowDisplay_DoubleClick(object sender, EventArgs e) {
			this.Hide();
		}

		private void Hide() {
			throw new NotImplementedException();
		}

		public bool Visible {
			get;
			set;
		}

		#region FormControl Members

		public event EventHandler Clicked;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
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

		void FormControl.Dispose(bool dispose) {
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

		#endregion

		#region FormControl Members

		public event EventHandler Click;

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

		internal void ShowDialog() {
			throw new NotImplementedException();
		}

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
