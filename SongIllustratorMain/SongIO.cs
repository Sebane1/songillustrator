using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SongIllustrator {
	public class SongIO {
		private static string _url;

		public static string Url {
			get {
				return SongIO._url;
			}
			set {
				SongIO._url = value;
			}
		}
		public static List<Launchpad> OpenFile(Stream openStream) {
			List<Launchpad> padData = new List<Launchpad>();
			using (BinaryReader reader = new BinaryReader(openStream)) {
				string version = reader.ReadString();
				if (version.Contains("v")) {
					int padCount = 1;
					if (version.Contains("v3")) {
						padCount = reader.ReadInt32();
					}
					for (int i = 0; i < padCount; i++) {
						padData.Add(LoadFrames(reader, version));
					}
					_url = reader.ReadString();
				}
			}
			return padData;
		}

		private static Launchpad LoadFrames(BinaryReader reader, string version) {
			Launchpad padData = new Launchpad();
			List<FrameData> frameData = new List<FrameData>();
			padData.Density = reader.ReadInt32();
			//GeneratePixels(display.Pixels = pixelBar.Value = display.Pixels = reader.ReadInt32());
			int frameCount = reader.ReadInt32();
			for (int i = 0; i < frameCount; i++) {
				FrameData frame = new FrameData();
				if (version.Contains("v1")) {
					frame.TimeStamp = reader.ReadInt32();
				} else {
					if (version.Contains("v2") || version.Contains("v3")) {
						frame.TimeStamp = reader.ReadDecimal();
					}
				}
				int colourCount = reader.ReadInt32();
				for (int colorNumber = 0; colorNumber < colourCount; colorNumber++) {
					try {
						frame.Colours.Add(Color.FromArgb(reader.ReadInt32()));
					} catch {
						object test;
					}
				}
				frame.Index = i;
				frameData.Add(frame);
			}
			padData.FrameData = frameData;
			return padData;
		}

		internal static void SaveFile(string filePath, List<Launchpad> padData, string songURL) {
			using (FileStream saveStream = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
				using (BinaryWriter writer = new BinaryWriter(saveStream)) {
					writer.Write("v3");
					writer.Write(padData.Count);
					foreach (Launchpad pad in padData) {
						writer.Write(pad.Density);
						writer.Write(pad.FrameData.Count);
						foreach (FrameData data in pad.FrameData) {
							writer.Write(data.TimeStamp);
							writer.Write(data.Colours.Count);
							foreach (Color color in data.Colours) {
								writer.Write(color.ToArgb());
							}
						}
					}
					writer.Write(songURL);
				}
			}
		}
	}
}
