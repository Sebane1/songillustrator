using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public partial class TimelineItem : UserControl {
		public TimelineItem() {
			InitializeComponent();
		}

		private FrameData _frame;
		private bool _canDrag;
		private bool _checked;
		private int _scaleOffset;
		private int _density;
		private bool _controlKeyDown;

		public bool ControlKeyDown {
			get {
				return _controlKeyDown;
			}
			set {
				_controlKeyDown = value;
			}
		}

		public bool Checked{
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
		public Image ImageIdentifier {
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
		public void ClickEvent(EventHandler value) {
			imageIdentifier.Click += value;
			Click += value;
		}
		private void TimelineItem_Load(object sender, EventArgs e) {
			if (_frame != null) {
				imageIdentifier.BackgroundImage = GeneratePreview(_frame, _density, imageIdentifier.Width);
			}
		}

		private void TimelineItem_MouseDown(object sender, MouseEventArgs e) {
			//_canDrag = true;
		}

		private void TimelineItem_MouseUp(object sender, MouseEventArgs e) {
			//_canDrag = false;
		}

		private void TimelineItem_MouseMove(object sender, MouseEventArgs e) {
			if (_canDrag) {
				if (_frame.TimeStamp != PointToClient(Cursor.Position).X) {
					_frame.TimeStamp = PointToClient(Cursor.Position).X;
					Location = new Point((int)_frame.TimeStamp, 0);
				}
			}
		}
		private Image GeneratePreview(FrameData frame, int Density, int widthHeight) {
			Bitmap bitmap = new Bitmap(Density, Density);
			Bitmap canvas = new Bitmap(widthHeight, widthHeight);
			int frameNumber = 0;
			for (int i = 0; i < Density; i++) {
				for (int z = 0; z < Density; z++) {
					bitmap.SetPixel(z, i, frame.Colours[frameNumber++]);
				}
			}
			Graphics graphics = Graphics.FromImage(canvas);
			graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			graphics.DrawImage(bitmap, 0, 0, widthHeight, widthHeight);
			return canvas;
		}

		private void TimelineItem_Resize(object sender, EventArgs e) {
			imageIdentifier.Width = this.Height;
			imageIdentifier.Height = this.Width;
		}

		private void TimelineItem_KeyDown(object sender, KeyEventArgs e) {
			_controlKeyDown = true;
		}

		private void TimelineItem_Click(object sender, EventArgs e) {
			if (_controlKeyDown) {
				_checked = true;
				BackColor = Color.YellowGreen;
			}
		}

		private void TimelineItem_KeyUp(object sender, KeyEventArgs e) {
			_controlKeyDown = false;
		}

		private void TimelineItem_MouseHover(object sender, EventArgs e) {
			Focus();
		}
	}
}
