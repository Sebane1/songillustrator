using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace SongIllustrator {
	public class MidiIO {
		private static bool CheckEqualColor(Color a, Color b) {
			return (a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B);
		}
		public MidiIO() {

		}

		public static void WriteMidi(string filename, List<FrameData> frameData, int bpm, int ppq) {
			using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
				// Output midi file header
				stream.WriteByte(77);
				stream.WriteByte(84);
				stream.WriteByte(104);
				stream.WriteByte(100);
				for (int i = 0; i < 3; i++) {
					stream.WriteByte(0);
				}
				stream.WriteByte(6);

				// Set the track mode
				byte[] trackMode = BitConverter.GetBytes(Convert.ToInt16(1));
				stream.Write(trackMode, 0, trackMode.Length);

				// Set the track amount
				byte[] trackAmount = BitConverter.GetBytes(Convert.ToInt16(1));
				stream.Write(trackAmount, 0, trackAmount.Length);

				// Set the delta time
				byte[] deltaTime = BitConverter.GetBytes(Convert.ToInt16(60000 / (bpm * ppq)));
				stream.Write(deltaTime, 0, deltaTime.Length);

				// Output track header
				stream.WriteByte(77);
				stream.WriteByte(84);
				stream.WriteByte(114);
				stream.WriteByte(107);
				byte[] bytes = BitConverter.GetBytes(100);
				stream.Write(bytes, 0, bytes.Length);
				foreach (FrameData frame in frameData) {
					byte[] delta = BitConverter.GetBytes((double) frame.TimeStamp);
					for (int i = 0; i < frame.Colours.Count; i++) {
						stream.Write(delta, 0, delta.Length);
						byte note = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(i));
						if (!CheckEqualColor(frame.Colours[i], Color.Black) && !CheckEqualColor(frame.Colours[i], Color.Gray) && !CheckEqualColor(frame.Colours[i], Color.Purple)) {
							/*if (i > 0) {
								stream.WriteByte(128);
								stream.WriteByte((byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(i -1)));
								if (CheckEqualColor(frame.Colours[i], Color.Red)) {
									stream.WriteByte(7);
								} else if (CheckEqualColor(frame.Colours[i], Color.Orange)) {
									stream.WriteByte(83);
								} else if (CheckEqualColor(frame.Colours[i], Color.Green) || CheckEqualColor(frame.Colours[i], Color.Aqua) || CheckEqualColor(frame.Colours[i], Color.Blue)) {
									stream.WriteByte(124);
								} else if (CheckEqualColor(frame.Colours[i], Color.Yellow)) {
									stream.WriteByte(127);
								}
							}*/
							stream.WriteByte(144);
							stream.WriteByte(note);
							if (CheckEqualColor(frame.Colours[i], Color.Red)) {
								stream.WriteByte(7);
							} else if (CheckEqualColor(frame.Colours[i], Color.Orange)) {
								stream.WriteByte(83);
							} else if (CheckEqualColor(frame.Colours[i], Color.Green) || CheckEqualColor(frame.Colours[i], Color.Aqua) || CheckEqualColor(frame.Colours[i], Color.Blue)) {
								stream.WriteByte(124);
							} else if (CheckEqualColor(frame.Colours[i], Color.Yellow)) {
								stream.WriteByte(127);
							}
						} else {
							stream.WriteByte(128);
							stream.WriteByte(note);
							stream.WriteByte(0);
						}
					}
				}
			}
		}
	}
}
