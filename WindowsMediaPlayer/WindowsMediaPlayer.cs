using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayerModuleBase;
using AxWMPLib;

namespace WindowsMediaPlayer {
	public class WindowsMediaPlayer : AxWindowsMediaPlayer, MediaPlayer {
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

		#region MediaPlayer Members

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

		public double CurrentPosition {
			get {
				return Ctlcontrols.currentPosition;
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

		#region MediaPlayer Members
		#endregion
	}
}
