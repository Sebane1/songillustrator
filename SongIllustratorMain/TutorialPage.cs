using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mime;
using System.IO;

namespace SongIllustrator {
	public class TutorialPage {

		public TutorialPage(string description, Stream image) {
			_description = description;
			_image = image;
		}
		private string _description;
		private Stream _image;

		public string Description {
			get {
				return _description;
			}
			set {
				_description = value;
			}
		}
		public Stream Image {
			get {
				return _image;
			}
			set {
				_image = value;
			}
		}
		public static List<TutorialPage> FLPages() {
			List<TutorialPage> pages = new List<TutorialPage>();
			//pages.Add(new TutorialPage(@"Click the options tab...", Properties.Resources.SIFLT1));
			//pages.Add(new TutorialPage(@"Click ""MIDI Settings"".", Properties.Resources.SIFLT2));
			//pages.Add(new TutorialPage(@"Click ""Rescan Devices"".", Properties.Resources.SIFLT3));
			//pages.Add(new TutorialPage(@"Click ""Virtual Launchpad"".", Properties.Resources.SIFLT4));
			//pages.Add(new TutorialPage(@"Click enable, and set the port to match that of the Launchpad.", Properties.Resources.SIFLT5));
			//pages.Add(new TutorialPage(@"Close the window.", Properties.Resources.SIFLT6));
			//pages.Add(new TutorialPage(@"Right click one of the items in the step sequencer.", Properties.Resources.SIFLT7));
			//pages.Add(new TutorialPage(@"Go under the ""Insert"" menu.", Properties.Resources.SIFLT8));
			//pages.Add(new TutorialPage(@"Click ""MIDI Out""", Properties.Resources.SIFLT9));
			//pages.Add(new TutorialPage(@"Set the port to match that of the Launchpad.", Properties.Resources.SIFLT10));
			//pages.Add(new TutorialPage(@"Close the ""MIDI Out"" window. You should be all set!", Properties.Resources.SIFLT11));
			return pages;
		}
		public static List<TutorialPage> AbletonPages() {
			List<TutorialPage> pages = new List<TutorialPage>();
			//pages.Add(new TutorialPage(@"Click ""Options"".", Properties.Resources.AL1));
			//pages.Add(new TutorialPage(@"Click ""Preferences"".", Properties.Resources.AL2));
			//pages.Add(new TutorialPage(@"Turn on tracks for both the ""Launchpad"" and ""Virtual Launchpad"".", Properties.Resources.AL3));
			//pages.Add(new TutorialPage(@"Close the window.", Properties.Resources.AL4));
			//pages.Add(new TutorialPage(@"Click ""View"".", Properties.Resources.AL5));
			//pages.Add(new TutorialPage(@"Click ""In/Out"".", Properties.Resources.AL6));
			//pages.Add(new TutorialPage(@"Click under MIDI From.", Properties.Resources.AL7));
			//pages.Add(new TutorialPage(@"Click ""Virtual Launchpad""", Properties.Resources.AL8));
			//pages.Add(new TutorialPage(@"Click under ""MIDI To"".", Properties.Resources.AL9));
			//pages.Add(new TutorialPage(@"Click ""Launchpad"".", Properties.Resources.AL10));
			//pages.Add(new TutorialPage(@"Click ""In"" under monitor.", Properties.Resources.AL11));
			//pages.Add(new TutorialPage(@"You should be all set!.", Properties.Resources.AL12));
			return pages;
		}
	}
}
