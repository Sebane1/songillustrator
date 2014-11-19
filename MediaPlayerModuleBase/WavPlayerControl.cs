using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using System.IO;

namespace MediaPlayerModuleBase {
	public partial class WavPlayerControl : UserControl, MediaPlayer {
		public WavPlayerControl() {
			InitializeComponent();
		}
		SoundPlayer _player = new SoundPlayer();
		Stopwatch stopwatch = new Stopwatch();
		public event EventHandler Playing;
		public event EventHandler Paused;
		public event EventHandler Stopped;
		public event EventHandler Ready;
		public event EventHandler DonePlaying;
		public double CurrentPosition {
			get {
				return (double)stopwatch.ElapsedMilliseconds / (double)1000;
			}
			set {

			}
		}
		public SoundPlayer Player {
			get {
				return _player;
			}
			set {
				_player = value;
			}
		}
		public string MediaPath {
			get {
				return _player.SoundLocation;
			}
			set {
				_player.Stream =  new FileStream(value, FileMode.Open,FileAccess.Read);
				Play();
			}
		}
		private bool playing = false;
		private void playButton_Click(object sender, EventArgs e) {
			if (playing) {
				Play();
				//mediaPosition.Value = 0;
			} else {
				Stop();
			}
			playing = !playing;
		}

		private void mediaPositioner_Tick(object sender, EventArgs e) {
			//if (mediaPosition != null) {
			//  if (_player != null) {
			//    try {
			//      if (mediaPosition.Maximum < _player.Stream.Length) {
			//        mediaPosition.Maximum = (int) _player.Stream.Length;
			//      }
			//      mediaPosition.Value = (int) _player.Stream.Position;
			//    } catch {
			//    }
			//  }
			//}
		}
		public void Play() {
			try {
				_player.Play();
			} catch {
			}
			stopwatch.Start();
			Playing(this, EventArgs.Empty);
		}
		public void Stop() {
			_player.Stop();
			stopwatch.Stop();
			Stopped(this, EventArgs.Empty);
		}
		public void Pause() {
			_player.Stop();
			stopwatch.Stop();
		}

		#region MediaPlayer Members
		OperatingSystem MediaPlayer.SupportedOS {
			get {
				return OperatingSystem.None;
			}
		}

		#endregion
	}
}
