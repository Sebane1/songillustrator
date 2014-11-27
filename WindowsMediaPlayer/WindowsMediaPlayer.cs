using System;
using System.Collections.Generic;
using System.Text;
using AxWMPLib;
using MediaPlayerModuleBase;
using System.Diagnostics;
using SongIllustrator;
using System.Drawing;

namespace WindowsMediaPlayer {
	public class WindowsMediaPlayer : AxWindowsMediaPlayer, IMediaPlayer {
		public WindowsMediaPlayer(){
			PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(_player_PlayStateChange);
		}
		void _player_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e) {
			if (e.newState == 3) {
				Playing(this, EventArgs.Empty);
			}
			if (e.newState == 2) {
				Paused(this, EventArgs.Empty);
			}
			if (e.newState == 1) {
				Stopped(this, EventArgs.Empty);
			}
			if (e.newState == 8) {
				DonePlaying(this, EventArgs.Empty);
			}
			if (e.newState == 10) {
				Ready(this, EventArgs.Empty);
			}
		}
		public string MediaPath {
			get {
				return URL;
			}
			set {
				URL = value;
			}
		}

		#region IMediaPlayer Members

		public event EventHandler Stopped;

		public event EventHandler Paused;

		public event EventHandler Playing;

		public event EventHandler DonePlaying;

		public event EventHandler Ready;
		public MediaPlayerModuleBase.OperatingSystem SupportedOS {
			get {
				return MediaPlayerModuleBase.OperatingSystem.Windows;
			}
		}
		int failCount = 0;
		public double CurrentPosition {
			get {
				try {
					return Ctlcontrols.currentPosition;
				} catch {
					failCount++;
					return 0;
				}
			}
			set {
				Ctlcontrols.currentPosition = value;
			}
		}

		public void Play() {
			Ctlcontrols.play();
		}

		public void Pause() {
			Ctlcontrols.pause();
		}

		public void Stop() {
			Ctlcontrols.stop();
		}

		#endregion

		#region IMediaPlayer Members
		#endregion

		#region IView Members


		public event EventHandler RightClicked;

		public new event EventHandler KeyDown;

		public new event EventHandler KeyUp;

		public event EventHandler Resized;

		public void Initialize() {
			throw new NotImplementedException();
		}

		public SongIllustrator.IView ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public SongIllustrator.ControlSize ControlSize {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public SongIllustrator.ControlLocation ControlLocation {
			get {
				return new ControlLocation(Location.X, Location.Y);
			}
			set {
				Location = new Point(value.X, value.Y);
			}
		}

		public int ControlWidth {
			get {
				return Width;
			}
			set {
				Width = value;
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

		public void AddControl(SongIllustrator.IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(SongIllustrator.IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(int index) {
			throw new NotImplementedException();
		}

		public new void Dispose(bool dispose) {
			throw new NotImplementedException();
		}

		public event EventHandler Load;

		public event EventHandler Shown;

		public SongIllustrator.Color ControlBackColor {
			get {
				return SongIllustrator.Color.Chartreuse;
			}
			set {
				object p = value;
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
