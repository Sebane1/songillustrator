using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayerModuleBase;
using ControlFactory;
using SongIllustrator;
using MonoMac.AppKit;

namespace OSXFactory.Wrappers {
	public class MediaPlayerWrapper : ControlWrapper, IMediaPlayer {
		public MediaPlayerWrapper(IFactory factory, IFormView formView) {
			_player = MediaPlayerLoader.LoadMediaPlayer(factory, formView);
			this.Control = _player as NSControl;
			_player.Stopped += delegate {
				if (Stopped != null) {
					Stopped(this, EventArgs.Empty);
				}
			};
			_player.Paused += delegate {
				if (Paused != null) {
					Paused(this, EventArgs.Empty);
				}
			};
			_player.Playing += delegate {
				if (Playing != null) {
					Playing(this, EventArgs.Empty);
				}
			};
			_player.DonePlaying += delegate {
				if (DonePlaying != null) {
					DonePlaying(this, EventArgs.Empty);
				}
			};
			_player.Ready += delegate {
				if (Ready != null) {
					Ready(this, EventArgs.Empty);
				}
			};
		}
		#region IMediaPlayer Members

		public event EventHandler Stopped;

		public event EventHandler Paused;

		public event EventHandler Playing;

		public event EventHandler DonePlaying;

		public event EventHandler Ready;
		private IMediaPlayer _player;

		public MediaPlayerModuleBase.OperatingSystem SupportedOS {
			get {
				return _player.SupportedOS;
			}
		}

		public string MediaPath {
			get {
				return _player.MediaPath;
			}
			set {
				_player.MediaPath = value;
			}
		}

		public double CurrentPosition {
			get {
				return _player.CurrentPosition;
			}
			set {
				_player.CurrentPosition = value;
			}
		}

		public void Play() {
			_player.Play();
		}

		public void Pause() {
			_player.Pause();
		}

		public void Stop() {
			_player.Stop();
		}

		#endregion
	}
}
