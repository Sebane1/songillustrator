using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator {
	public partial class FigurePainter : Form {
		public FigurePainter() {
			InitializeComponent();
		}
		private List<TutorialFigure> _tutorialFigures = new List<TutorialFigure>();
		private List<Size> _sizes = new List<Size>();
		private List<Point> _locations = new List<Point>();
		private int _currentFigure = 0;
		public Form1 Creator;
		public List<TutorialFigure> TutorialFigures {
			get {
				return _tutorialFigures;
			}
			set {
				_tutorialFigures = value;
			}
		}
		int _startSpeed = 5;
		private void animation_Tick(object sender, EventArgs e) {
			int validPositions = 0;
			if (Creator != null) {
				Location = Creator.Location;
				Size = Creator.Size;
			}
			TutorialFigure figure = _tutorialFigures[_currentFigure];
			while (_sizes.Count < figure.ControlToFocus.Count) {
				Size size = _sizes.Count > 1 ? _sizes[0] : new Size();
				_sizes.Add(size);
			}
			while (_locations.Count < figure.ControlToFocus.Count) {
				Point location = _locations.Count > 1 ? _locations[0] : new Point();
				_locations.Add(location);
			}
			for (int i = 0; i < figure.ControlToFocus.Count; i++) {
				Size size = _sizes[i];
				Point location = _locations[i];
				Control controlToFocus = figure.ControlToFocus[i];
				this.Refresh();
				if ((size.Height >= controlToFocus.Height - 5 && size.Height <= controlToFocus.Height) || (size.Height <= controlToFocus.Height + 5 && size.Height >= controlToFocus.Height)) {
					size.Height = controlToFocus.Height;
					validPositions++;
				} else {
					if (size.Height > controlToFocus.Height) {
						size.Height -= _startSpeed;
					} else if (size.Height < controlToFocus.Height) {
						size.Height += _startSpeed;
					} else {
						validPositions++;
					}
				}
				if ((size.Width >= controlToFocus.Width - 5 && size.Width <= controlToFocus.Width) || (size.Width <= controlToFocus.Width + 5 && size.Width >= controlToFocus.Width)) {
					size.Width = controlToFocus.Width;
					validPositions++;
				} else {
					if (size.Width > controlToFocus.Width) {
						size.Width -= _startSpeed;
					} else if (size.Width < controlToFocus.Width) {
						size.Width += _startSpeed;
					} else {
						validPositions++;
					}
				}
				Point itemPoint = controlToFocus.Location;
				if ((location.X >= itemPoint.X - 10 && location.X <= itemPoint.X) || (location.X <= itemPoint.X + 10 && location.X >= itemPoint.X)) {
					_locations[i] = new Point(itemPoint.X, _locations[i].Y);
					validPositions++;
				} else {
					if (location.X > controlToFocus.Location.X) {
						location = new Point(location.X - _startSpeed, location.Y);
					} else if (location.X < itemPoint.X) {
						location = new Point(location.X + _startSpeed, location.Y);
					} else {
						validPositions++;
					}
				}

				if ((location.Y >= itemPoint.Y - 10 && location.Y <= itemPoint.Y) || (location.Y <= itemPoint.Y + 10 && location.Y >= itemPoint.Y)) {
					_locations[i] = new Point(_locations[i].X, itemPoint.Y);
					validPositions++;
				} else {
					if (location.Y > itemPoint.Y) {
						location = new Point(location.X, location.Y - _startSpeed);
					} else if (location.Y < itemPoint.Y) {
						location = new Point(location.X, location.Y + _startSpeed);
					} else {
						validPositions++;
					}
				}
				_sizes[i] = size;
				_locations[i] = location;
				if (validPositions >= 4 * figure.ControlToFocus.Count) {
					_sizes[i] = controlToFocus.Size;
					_locations[i] = controlToFocus.Location;
				}
			}
			descriptionLabel.Text = "";
			if (!pauseTimer.Enabled) {
				if (validPositions >= 4 * figure.ControlToFocus.Count) {
					pauseTimer.Start();
					this.Refresh();
				}
			} else {
				if (pauseTimer.Enabled) {
					descriptionLabel.Text = _tutorialFigures[_currentFigure].Description;
				}
			}
		}

		private Point GetAbsolutePosition(Control controlToFocus) {
			if (controlToFocus.Parent != null) {
				Point absolute = GetAbsolutePosition(controlToFocus);
				return new Point(controlToFocus.Location.X + absolute.X, controlToFocus.Location.Y + absolute.Y);
			} else {
				return new Point();
			}
		}

		private void FigurePainter_Paint(object sender, PaintEventArgs e) {
			Draw(e.Graphics);
		}

		private void Draw(Graphics e) {
			Graphics graphics = e;
			Bitmap bitmap = new Bitmap(this.Width, this.Height);
			Graphics canvasDrawer = Graphics.FromImage(bitmap);
			if (_locations.Count > 0 && _sizes.Count > 0) {
				for (int i = 0; i < _tutorialFigures[_currentFigure].ControlToFocus.Count; i++) {
					canvasDrawer.DrawRectangle(new Pen(Brushes.Red, 5), new Rectangle(_locations[i], _sizes[i]));
				}
			}
			graphics.DrawImage(bitmap, new Point(0, 0));
		}

		private void pauseTimer_Tick(object sender, EventArgs e) {
			if (_currentFigure < _tutorialFigures.Count - 1) {
				_currentFigure++;
			} else {
				this.Close();
			}
			pauseTimer.Stop();
			animation.Start();
		}

		private void FigurePainter_Shown(object sender, EventArgs e) {
			animation.Start();
		}

		private void launchpadToolStripMenuItem_Paint(object sender, PaintEventArgs e) {

		}

		private void descriptionLabel_Click(object sender, EventArgs e) {

		}

		private void FigurePainter_Load(object sender, EventArgs e) {

		}
	}
}
