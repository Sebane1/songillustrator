using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.Mime;
using System.IO;

namespace SongIllustrator {
	public partial class TimelineItem : IView {
		public TimelineItem() {
			InitializeComponent();
		}

		private FrameData _frame;
		private bool _canDrag;
		private bool _checked;
		private int _scaleOffset;
		private int _density;
		private bool _FormControlKeyDown;

		public bool FormControlKeyDown {
			get {
				return _FormControlKeyDown;
			}
			set {
				_FormControlKeyDown = value;
			}
		}
		public void ClickEvent(EventHandler item) {
			Click += item;
		}
		public bool Checked {
			get {
				return _checked;
			}
			set {
				_checked = value;
			}
		}
		public int Density {
			get {
				return _density;
			}
			set {
				_density = value;
			}
		}
		public int ScaleOffset {
			get {
				return _scaleOffset;
			}
			set {
				_scaleOffset = value;
			}
		}
		public Stream ImageIdentifier {
			get {
				return imageIdentifier.Image;
			}
			set {
				imageIdentifier.Image = value;
			}
		}
		public FrameData Frame {
			get {
				return _frame;
			}
			set {
				_frame = value;
			}
		}
		private void TimelineItem_Load(object sender, EventArgs e) {
			if (_frame != null) {
				imageIdentifier.BackgroundImage = GeneratePreview(_frame, _density, imageIdentifier.ControlWidth);
			}
		}

		//private void TimelineItem_MouseDown(object sender, MouseEventArgs e) {
		//  //_canDrag = true;
		//}

		//private void TimelineItem_MouseUp(object sender, MouseEventArgs e) {
		//  //_canDrag = false;
		//}

		//private void TimelineItem_MouseMove(object sender, MouseEventArgs e) {
		//  //if (_canDrag) {
		//  //  if (_frame.TimeStamp != PointToClient(Cursor.Position).X) {
		//  //    _frame.TimeStamp = PointToClient(Cursor.Position).X;
		//  //    ControlLocation = new Point((int) _frame.TimeStamp, 0);
		//  //  }
		//  //}
		//}
		private Stream GeneratePreview(FrameData frame, int Density, int widthHeight) {
			//Bitmap bitmap = new Bitmap(Density, Density);
			//Bitmap canvas = new Bitmap(widthHeight, widthHeight);
			//int frameNumber = 0;
			//for (int i = 0; i < Density; i++) {
			//  for (int z = 0; z < Density; z++) {
			//    bitmap.SetPixel(z, i, frame.Colours[frameNumber++]);
			//  }
			//}
			//Graphics graphics = Graphics.FromImage(canvas);
			//graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor;
			//graphics.DrawImage(bitmap, 0, 0, widthHeight, widthHeight);
			//return canvas;
			return null;
		}

		private void TimelineItem_Resize(object sender, EventArgs e) {
			//imageIdentifier.ControlWidth = this.Height;
			//imageIdentifier.Height = this.ControlWidth;
		}

		//private void TimelineItem_KeyDown(object sender, KeyEventArgs e) {
		//  _FormControlKeyDown = true;
		//}

		private void TimelineItem_Click(object sender, EventArgs e) {
			//if (_FormControlKeyDown) {
			//  _checked = true;
			//  ControlBackColor = Color.YellowGreen;
			//}
		}

		//private void TimelineItem_KeyUp(object sender, KeyEventArgs e) {
		//  _FormControlKeyDown = false;
		//}

		//private void TimelineItem_MouseHover(object sender, EventArgs e) {
		//  Focus();
		//}

		#region IView Members

		public event EventHandler Click;

		public event EventHandler RightClicked;

		public event EventHandler KeyDown;

		public event EventHandler KeyUp;

		public event EventHandler Resized;

		public event EventHandler BackColorChanged;

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

		public IView ParentControl {
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

		public void AddControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(int index) {
			throw new NotImplementedException();
		}

		public bool Visible {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		void IView.Dispose(bool dispose) {
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

		public event EventHandler Load;

		public event EventHandler Shown;

		public event EventHandler DoubleClick;

		public string Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public Color ControlBackColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IView Members


		public event EventHandler MouseLeftUp;

		public event EventHandler MouseRightUp;

		public event EventHandler MouseLeftDown;

		public event EventHandler MouseRightDown;

		#endregion
	}
}
