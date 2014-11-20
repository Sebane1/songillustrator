//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Text;

//namespace SongIllustrator {
//  public interface FigurePainter : FormControl {
//    private List<TutorialFigure> _tutorialFigures = new List<TutorialFigure>();
//    private List<ControlSize> _sizes = new List<ControlSize>();
//    private List<ControlLocation> _locations = new List<ControlLocation>();
//    private int _currentFigure = 0;
//    public BaseForm Creator;
//    public List<TutorialFigure> TutorialFigures {
//      get {
//        return _tutorialFigures;
//      }
//      set {
//        _tutorialFigures = value;
//      }
//    }
//    int _startSpeed = 5;
//    private void animation_Tick(object sender, EventArgs e) {
//      int validPositions = 0;
//      if (Creator != null) {
//        ControlLocation = Creator.ControlLocation;
//        ControlSize = Creator.ControlSize;
//      }
//      TutorialFigure figure = _tutorialFigures[_currentFigure];
//      while (_sizes.Count < figure.FormControlToFocus.Count) {
//        ControlSize size = _sizes.Count > 1 ? _sizes[0] : new ControlSize();
//        _sizes.Add(size);
//      }
//      while (_locations.Count < figure.FormControlToFocus.Count) {
//        FormControl.ControlLocation = _locations.Count > 1 ? _locations[0] : new ControlLocation();
//        _locations.Add(location);
//      }
//      for (int i = 0; i < figure.FormControlToFocus.Count; i++) {
//        ControlSize size = _sizes[i];
//        ControlLocationFormControlLocation= _locations[i];
//        FormControl FormControlToFocus = figure.FormControlToFocus[i];
//        this.Refresh();
//        if ((size.Height >= FormControlToFocus.Height - 5 && size.Height <= FormControlToFocus.Height) || (size.Height <= FormControlToFocus.Height + 5 && size.Height >= FormControlToFocus.Height)) {
//          size.Height = FormControlToFocus.Height;
//          validPositions++;
//        } else {
//          if (size.Height > FormControlToFocus.Height) {
//            size.Height -= _startSpeed;
//          } else if (size.Height < FormControlToFocus.Height) {
//            size.Height += _startSpeed;
//          } else {
//            validPositions++;
//          }
//        }
//        if ((size.ControlWidth >= FormControlToFocus.ControlWidth - 5 && size.ControlWidth <= FormControlToFocus.ControlWidth) || (size.ControlWidth <= FormControlToFocus.ControlWidth + 5 && size.ControlWidth >= FormControlToFocus.ControlWidth)) {
//          size.ControlWidth = FormControlToFocus.ControlWidth;
//          validPositions++;
//        } else {
//          if (size.ControlWidth > FormControlToFocus.ControlWidth) {
//            size.ControlWidth -= _startSpeed;
//          } else if (size.ControlWidth < FormControlToFocus.ControlWidth) {
//            size.ControlWidth += _startSpeed;
//          } else {
//            validPositions++;
//          }
//        }
//        ControlLocation itemControlLocation = FormControlToFocus.ControlLocation;
//        if ((location.X >= itemControlLocation.X - 10 && location.X <= itemControlLocation.X) || (location.X <= itemControlLocation.X + 10 && location.X >= itemControlLocation.X)) {
//          _locations[i] = new ControlLocation(itemControlLocation.X, _locations[i].Y);
//          validPositions++;
//        } else {
//          if (location.X > FormControlToFocus.ControlLocation.X) {
//            location = new ControlLocation(location.X - _startSpeed, location.Y);
//          } else if (location.X < itemControlLocation.X) {
//            location = new ControlLocation(location.X + _startSpeed, location.Y);
//          } else {
//            validPositions++;
//          }
//        }

//        if ((location.Y >= itemControlLocation.Y - 10 && location.Y <= itemControlLocation.Y) || (location.Y <= itemControlLocation.Y + 10 && location.Y >= itemControlLocation.Y)) {
//          _locations[i] = new ControlLocation(_locations[i].X, itemControlLocation.Y);
//          validPositions++;
//        } else {
//          if (location.Y > itemControlLocation.Y) {
//            location = new ControlLocation(location.X, location.Y - _startSpeed);
//          } else if (location.Y < itemControlLocation.Y) {
//            location = new ControlLocation(location.X, location.Y + _startSpeed);
//          } else {
//            validPositions++;
//          }
//        }
//        _sizes[i] = size;
//        _locations[i] = location;
//        if (validPositions >= 4 * figure.FormControlToFocus.Count) {
//          _sizes[i] = FormControlToFocus.ControlSize;
//          _locations[i] = FormControlToFocus.ControlLocation;
//        }
//      }
//      descriptionLabel.Text = "";
//      if (!pauseTimer.Enabled) {
//        if (validPositions >= 4 * figure.FormControlToFocus.Count) {
//          pauseTimer.Start();
//          this.Refresh();
//        }
//      } else {
//        if (pauseTimer.Enabled) {
//          descriptionLabel.Text = _tutorialFigures[_currentFigure].Description;
//        }
//      }
//    }

//    private ControlLocation GetAbsolutePosition(FormControl FormControlToFocus) {
//      if (FormControlToFocus.ParentControl != null) {
//        ControlLocation absolute = GetAbsolutePosition(FormControlToFocus);
//        return new ControlLocation(FormControlToFocus.ControlLocation.X + absolute.X, FormControlToFocus.ControlLocation.Y + absolute.Y);
//      } else {
//        return new ControlLocation();
//      }
//    }

//    private void FigurePainter_Paint(object sender, PaintEventArgs e) {
//      Draw(e.Graphics);
//    }

//    private void Draw(Graphics e) {
//      Graphics graphics = e;
//      Bitmap bitmap = new Bitmap(this.ControlWidth, this.Height);
//      Graphics canvasDrawer = Graphics.FromImage(bitmap);
//      if (_locations.Count > 0 && _sizes.Count > 0) {
//        for (int i = 0; i < _tutorialFigures[_currentFigure].FormControlToFocus.Count; i++) {
//          canvasDrawer.DrawRectangle(new Pen(Brushes.Red, 5), new Rectangle(_locations[i], _sizes[i]));
//        }
//      }
//      graphics.DrawImage(bitmap, new ControlLocation(0, 0));
//    }

//    private void pauseTimer_Tick(object sender, EventArgs e) {
//      if (_currentFigure < _tutorialFigures.Count - 1) {
//        _currentFigure++;
//      } else {
//        this.Close();
//      }
//      pauseTimer.Stop();
//      animation.Start();
//    }

//    private void FigurePainter_Shown(object sender, EventArgs e) {
//      animation.Start();
//    }

//    private void launchpadToolStripMenuItem_Paint(object sender, PaintEventArgs e) {

//    }

//    private void descriptionLabel_Click(object sender, EventArgs e) {

//    }

//    private void FigurePainter_Load(object sender, EventArgs e) {

//    }
//  }
//}
