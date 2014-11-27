using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Media;
using System.Diagnostics;
using System.IO;
using ControlFactory;
using SongIllustrator;

namespace MediaPlayerModuleBase {
	public partial class WavPlayerControl : IMediaPlayer {
		public WavPlayerControl(IFactory factory, IFormView formView) {
			_factory = factory;
			_formView = formView;
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
				return (double) stopwatch.ElapsedMilliseconds / (double) 1000;
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
				if (!string.IsNullOrEmpty(value)) {
					_player.Stream = new FileStream(value, FileMode.Open, FileAccess.Read);
					Play();
				}
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

		#region IMediaPlayer Members
		OperatingSystem IMediaPlayer.SupportedOS {
			get {
				return OperatingSystem.None;
			}
		}

		#endregion

		#region IMediaPlayer Members


		MediaPlayerModuleBase.OperatingSystem SupportedOS {
			get {
				return OperatingSystem.None;
			}
		}

		#endregion

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

		public SongIllustrator.IView ParentControl {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		public SongIllustrator.ControlSize ControlSize {
			get {
				return _controlSize;
			}
			set {
				_controlSize = value;
			}
		}

		public SongIllustrator.ControlLocation ControlLocation {
			get {
				return _controlLocation;
			}
			set {
				_controlLocation = value;
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

		public void AddControl(SongIllustrator.IView control) {
			throw new NotImplementedException();
		}

		public void RemoveControl(SongIllustrator.IView control) {
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

		void SongIllustrator.IView.Dispose(bool dispose) {
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
		private IFactory _factory;
		private IFormView _formView;
		private ControlSize _controlSize;
		private ControlLocation _controlLocation;
		private string _name;

		public string Text {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public SongIllustrator.Color ControlBackColor {
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
