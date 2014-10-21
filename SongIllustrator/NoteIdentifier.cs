using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongIllustrator {
	public class NoteIdentifier {
		public static string GetNoteFromInt(int note) {
			int octave = 0;
			while (note - 12 >= 0) {
				note -= 12;
				octave++;
			}
			switch (note) {
				case 0:
					return "C" + octave;
				case 1:
					return "C#" + octave;
				case 2:
					return "D" + octave;
				case 3:
					return "D#" + octave;
				case 4:
					return "E" + octave;
				case 5:
					return "F" + octave;
				case 6:
					return "F#" + octave;
				case 7:
					return "G" + octave;
				case 8:
					return "G#" + octave;
				case 9:
					return "A" + octave;
				case 10:
					return "A#" + octave;
				case 11:
					return "B" + octave;
			}
			return null;
		}
		public static int GetIntFromNote(string note) {
			switch ((note ?? "").Length) {
				case 2:
					string noteValue1 = note[0] + "";
					int octave1 = int.Parse(note[1] + "");
					return GetIntFromNoteAndOctave(noteValue1, octave1);
				case 3:
					string noteValue2 = note[1] == '#' ? (note[0] + "" + note[1]) : note[0]+"";
					int octave2 = int.Parse(note[1] == '-' ? note[1] + "" + note[2]: note[2] + "");
					return GetIntFromNoteAndOctave(noteValue2, octave2);
				case 4:
					string noteValue3 = note[0] + "" + note[1];
					int octave3 = int.Parse(note[2] + "" + note[3]);
					return GetIntFromNoteAndOctave(noteValue3, octave3);
			}
			return -1;
		}
		private static int GetIntFromNoteAndOctave(string note, int octave) {
			if (octave < 0) {
				octave = 0;
			}
			switch (note) {
				case "C":
					return 0 + (12 * octave);
				case "C#":
					return 1 + (12 * octave);
				case "D":
					return 2 + (12 * octave);
				case "D#":
					return 3 + (12 * octave);
				case "E":
					return 4 + (12 * octave);
				case "F":
					return 5 + (12 * octave);
				case "F#":
					return 6 + (12 * octave);
				case "G":
					return 7 + (12 * octave);
				case "G#":
					return 8 + (12 * octave);
				case "A":
					return 9 + (12 * octave);
				case "A#":
					return 10 + (12 * octave);
				case "B":
					return 11 + (12 * octave);
			}
			return -1;
		}
		public static int GetNotePosition(string note) {
			switch (note) {
				case "C0":
					return 0;
				case "C#0":
					return 1;
				case "D0":
					return 2;
				case "D#0":
					return 3;
				case "E0":
					return 4;
				case "F0":
					return 5;
				case "F#0":
					return 6;
				case "G0":
					return 7;
				case "E1":
					return 8;
				case "F1":
					return 9;
				case "F#1":
					return 10;
				case "G1":
					return 11;
				case "G#1":
					return 12;
				case "A1":
					return 13;
				case "A#1":
					return 14;
				case "B1":
					return 15;
				case "G#2":
					return 16;
				case "A2":
					return 17;
				case "A#2":
					return 18;
				case "B2":
					return 19;
				case "C3":
					return 20;
				case "C#3":
					return 21;
				case "D3":
					return 22;
				case "D#3":
					return 23;
				case "C4":
					return 24;
				case "C#4":
					return 25;
				case "D4":
					return 26;
				case "D#4":
					return 27;
				case "E4":
					return 28;
				case "F4":
					return 29;
				case "F#4":
					return 30;
				case "G4":
					return 31;
				case "E5":
					return 32;
				case "F5":
					return 33;
				case "F#5":
					return 34;
				case "G5":
					return 35;
				case "G#5":
					return 36;
				case "A5":
					return 37;
				case "A#5":
					return 38;
				case "B5":
					return 39;
				case "G#6":
					return 40;
				case "A6":
					return 41;
				case "A#6":
					return 42;
				case "B6":
					return 43;
				case "C7":
					return 44;
				case "C#7":
					return 45;
				case "D7":
					return 46;
				case "D#7":
					return 47;
				case "C8":
					return 48;
				case "C#8":
					return 49;
				case "D8":
					return 50;
				case "D#8":
					return 51;
				case "E8":
					return 52;
				case "F8":
					return 53;
				case "F#8":
					return 54;
				case "G8":
					return 55;
				case "E9":
					return 56;
				case "F9":
					return 57;
				case "F#9":
					return 58;
				case "G9":
					return 59;
				case "G#9":
					return 60;
				case "A9":
					return 61;
				case "A#9":
					return 62;
				case "B9":
					return 63;
			}
			return -1;
		}
		public static string GetNoteFromPosition(int index) {
			switch (index) {
				case 0:
					return "C0";
				case 1:
					return "C#0";
				case 2:
					return "D0";
				case 3:
					return "D#0";
				case 4:
					return "E0";
				case 5:
					return "F0";
				case 6:
					return "F#0";
				case 7:
					return "G0";
				case 8:
					return "E1";
				case 9:
					return "F1";
				case 10:
					return "F#1";
				case 11:
					return "G1";
				case 12:
					return "G#1";
				case 13:
					return "A1";
				case 14:
					return "A#1";
				case 15:
					return "B1";
				case 16:
					return "G#2";
				case 17:
					return "A2";
				case 18:
					return "A#2";
				case 19:
					return "B2";
				case 20:
					return "C3";
				case 21:
					return "C#3";
				case 22:
					return "D3";
				case 23:
					return "D#3";
				case 24:
					return "C4";
				case 25:
					return "C#4";
				case 26:
					return "D4";
				case 27:
					return "D#4";
				case 28:
					return "E4";
				case 29:
					return "F4";
				case 30:
					return "F#4";
				case 31:
					return "G4";
				case 32:
					return "E5";
				case 33:
					return "F5";
				case 34:
					return "F#5";
				case 35:
					return "G5";
				case 36:
					return "G#5";
				case 37:
					return "A5";
				case 38:
					return "A#5";
				case 39:
					return "B5";
				case 40:
					return "G#6";
				case 41:
					return "A6";
				case 42:
					return "A#6";
				case 43:
					return "B6";
				case 44:
					return "C7";
				case 45:
					return "C#7";
				case 46:
					return "D7";
				case 47:
					return "D#7";
				case 48:
					return "C8";
				case 49:
					return "C#8";
				case 50:
					return "D8";
				case 51:
					return "D#8";
				case 52:
					return "E8";
				case 53:
					return "F8";
				case 54:
					return "F#8";
				case 55:
					return "G8";
				case 56:
					return "E9";
				case 57:
					return "F9";
				case 58:
					return "F#9";
				case 59:
					return "G9";
				case 60:
					return "G#9";
				case 61:
					return "A9";
				case 62:
					return "A#9";
				case 63:
					return "B9";
			}
			return null;
		}
	}
}
