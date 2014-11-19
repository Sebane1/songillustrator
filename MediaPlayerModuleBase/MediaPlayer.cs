using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MediaPlayerModuleBase {
	public interface MediaPlayer{
		event EventHandler Stopped;
		event EventHandler Paused;
		event EventHandler Playing;
		event EventHandler DonePlaying;
		event EventHandler Ready;
		OperatingSystem SupportedOS {
			get;
		}

		/// <summary>
		/// This property stub is used for the media path. It can be overidden. 
		/// </summary>
		string MediaPath {
			get;
			set;
		}
		double CurrentPosition {
			get;
			set;
		}
		/// <summary>
		/// This method stub is used to play the current media. It can be overidden.
		/// </summary>
		void Play();
		/// <summary>
		/// This method stub is used to pause the current media. It can be overidden.
		/// </summary>
		void Pause();
		/// <summary>
		/// This method stub is used to stop the current media. It can be overidden.
		/// </summary>
		void Stop();
		/// <summary>
		/// Initiates the media player object with its associated operating system.
		/// </summary>
		/// <param name="supportedOS"></param>
		//public MediaPlayer(Control mediaPlayer, OperatingSystem supportedOS) {
		//  _mediaPlayerControl = mediaPlayer;
		//  _supportedOS = supportedOS;
		//}
	}
}
