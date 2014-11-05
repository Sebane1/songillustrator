using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS_Console_Test.Classes.Other
{
	class MIDI
	{
		#region General MIDI Map
		// 
		// Credits:  people.virginia.edu/~pdr4h/gmPatch.html
		//           pjb.com.au/muscript/gm.html#cc
		//
		//   General MIDI Program Numbers 1 - 128
		//   all channels except 10
		//   
		// ----------------------------------------------------------------------------
		//   SOUND SET GROUPS
		// ----------------------------------------------------------------------------
		//   
		//    1 - 8  = PIANO                     65 - 72  = REED
		//    9 - 16 = CHROMATIC PERCUSSION      73 - 80  = PIPE
		//   17 - 24 = ORGAN                     81 - 88  = SYNTH LEAD
		//   25 - 32 = GUITAR                    89 - 96  = SYNTH PAD
		//   33 - 40 = BASS                      97 - 104 = SYNTH EFFECTS
		//   41 - 48 = STRINGS                  105 - 112 = ETHNIC
		//   49 - 56 = ENSEMBLE                 113 - 120 = PERCUSSIVE
		//   57 - 64 = BRASS                    121 - 128 = SOUND EFFECTS
		//   
		// ----------------------------------------------------------------------------
		//   PATCH NUMBER / NAME       PATCH NUMBER / NAME      PATCH NUMBER / NAME
		// ----------------------------------------------------------------------------
		//   
		//   1. Acoustic Grand Piano      44. Contrabass           87. Lead 7 (fifths)
		//   2. Bright Acoustic Piano     45. Tremolo Strings      88. Lead 8 (bass + lead
		//   3. Electric Grand Piano      46. Pizzicato Strings    89. Pad 1 (new age)
		//   4. Honky - tonk Piano        47. Orchestral Harp      90. Pad 2 (warm)
		//   5. Electric Piano 1          48. Timpani              91. Pad 3 (polysynth)
		//   6. Electric Piano 2          49. String Ensemble 1    92. Pad 4 (choir)
		//   7. Harpsichord               50. String Ensemble 2    93. Pad 5 (bowed)
		//   8. Clavinet                  51. SynthStrings 1       94. Pad 6 (metallic)
		//   9. Celesta                   52. SynthStrings 2       95. Pad 7 (halo)
		//   10. Glockenspiel             53. Choir Aahs           96. Pad 8 (sweep)
		//   11. Music Box                54. Voice Oohs           97. FX 1 (train)
		//   12. Vibraphone               55. Synth Voice          98. FX 2 (soundtrack)
		//   13. Marimba                  56. Orchestra Hit        99. FX 3 (crystal)
		//   14. Xylophone                57. Trumpet             100. FX 4 (atmosphere)
		//   15. Tubular Bells            58. Trombone            101. FX 5 (brightness)
		//   16. Dulcimer                 59. Tuba                102. FX 6 (goblins)
		//   17. Drawbar Organ            60. Muted Trumpet       103. FX 7 (echoes)
		//   18. Percussive Organ         61. French Horn         104. FX 8 (SciFi)
		//   19. Rock Organ               62. Brass Section       105. Sitar
		//   20. Church Organ             63. Synth Brass 1       106. Banjo
		//   21. Reed Organ               64. Synth Brass 2       107. Shamisen
		//   22. Accordion                65. Soprano Sax         108. Koto
		//   23. Harmonica                66. Alto Sax            109. Kalimba
		//   24. Tango Accordion          67. Tenor Sax           110. Bagpipe
		//   25. Acoustic Guitar(nylon)   68. Baritone Sax        111. Fiddle
		//   26. Acoustic Guitar(steel)   69. Oboe                112. Shanai
		//   27. Electric Guitar(jazz)    70. English Horn        113. Tinkle Bell
		//   28. Electric Guitar(clean)   71. Bassoon             114. Agogo
		//   29. Electric Guitar(muted)   72. Clarinet            115. Steel Drums
		//   30. Overdriven Guitar        73. Piccolo             116. Woodblock
		//   31. Distortion Guitar        74. Flute               117. Tailo Drum
		//   32. Guitar Harmonics         75. Recorder            118. Melodic Drum
		//   33. Acoustic Bass            76. Pan Flute           119. Synth Drum
		//   34. Electric Bass(finger)    77. Blown Bottle        120. Reverse Cymbal
		//   35. Electric Bass(pick)      78. Shakuhachi          121. Guitar Fret Noise
		//   36. Fretless Bass            79. Whistle             122. Breath Noise
		//   37. Slap Bass 1              80. Ocarina             123. Seashore
		//   38. Slap Bass 2              81. Lead 1 (square)     124. Bird Tweet
		//   39. Synth Bass 1             82. Lead 2 (sawtooth)   125. Telephone Ring
		//   40. Synth Bass 2             83. Lead 3 (calliope)   126. Helicopter
		//   41. Violin                   84. Lead 4 (chiff)      127. Applause
		//   42. Viola                    85. Lead 5 (charang)    128. Gunshot
		//   43. Cello                    86. Lead 6 (voice)
		//
		#endregion

		const int NoNote = -1; // Arbitrary value we use here to indicate "no note"

		internal enum NoteTable
		{
			C = 12,
			CSharp = 13,
			D = 14,
			DSharp = 15,
			E = 16,
			F = 17,
			FSharp = 18,
			G = 19,
			GSharp = 20,
			A = 21,
			ASharp = 22,
			B = 23,
			BSharp = 24
		};

		enum PatchType
		{
			None = 0,
			AcousticGrandPiano = 1,
			BrightAcousticPiano = 2,
			ElectricGrandPiano = 3,
			HonkyTonkPiano = 4,
			ElectricPiano1 = 5,
			ElectricPiano2 = 6,
			HarpsiChord = 7,
			Clavinet = 8,
			Celesta = 9,
			Glockenspiel = 10,
			MusicBox = 11,
			Vibraphone = 12,
			Marimba = 13,
			Xylophone = 14,
			TubularBells = 15,
			Dulcimer = 16,
			DrawbarOrgan = 17,
			PercussiveOrgan = 18,
			RockOrgan = 19,
			ChurchOrgan = 20,
			ReedOrgan = 21,
			Accordion = 22,
			Harmonica = 23,
			TangoAccordion = 24,
			AcousticGuitar1 = 25,
			AcousticGuitar2 = 26,
			ElectricGuitar3 = 27,
			ElectricGuitar4 = 28,
			ElectricGuitar5 = 29,
			OverdrivenGuitar = 30,
			DistortionGuitar = 31,
			GuitarHarmonics = 32,
			AcousticBass = 33,
			ElectricBass1 = 34,
			ElectricBass2 = 35,
			FretlessBass = 36,
			SlapBass1 = 37,
			SlapBass2 = 38,
			SynthBass1 = 39,
			SynthBass2 = 40,
			Violin = 41,
			Viola = 42,
			Cello = 43,
			Contrabass = 44,
			TremoloStrings = 45,
			PizzicatoStrings = 46,
			OrchestralHarp = 47,
			Timpani = 48,
			StringEnsemble1 = 49,
			StringEnsemble2 = 50,
			Synthstrings1 = 51,
			Synthstrings2 = 52,
			ChoirAahs = 53,
			VoiceOohs = 54,
			SynthVoice = 55,
			OrchestraHit = 56,
			TRUMPET = 57,
			Trombone = 58,
			Tuba = 59,
			MutedTRUMPET = 60,
			FrenchHorn = 61,
			BrassSection = 62,
			SynthBrass1 = 63,
			SynthBrass2 = 64,
			SopranoSax = 65,
			AltoSax = 66,
			TenorSax = 67,
			BaritoneSax = 68,
			Oboe = 69,
			EnglishHorn = 70,
			Bassoon = 71,
			Clarinet = 72,
			Piccolo = 73,
			Flute = 74,
			Recorder = 75,
			PanFlute = 76,
			BlownBottle = 77,
			Shakuhachi = 78,
			Whistle = 79,
			Ocarina = 80,
			Lead1 = 81,
			Lead2 = 82,
			Lead3 = 83,
			Lead4 = 84,
			Lead5 = 85,
			Lead6 = 86,
			Lead7 = 87,
			Lead8 = 88,
			Pad1 = 89,
			Pad2 = 90,
			Pad3 = 91,
			Pad4 = 92,
			Pad5 = 93,
			Pad6 = 94,
			Pad7 = 95,
			Pad8 = 96,
			Fx1 = 97,
			Fx2 = 98,
			Fx3 = 99,
			Fx4 = 100,
			Fx5 = 101,
			Fx6 = 102,
			Fx7 = 103,
			Fx8 = 104,
			Sitar = 105,
			Banjo = 106,
			Shamisen = 107,
			Koto = 108,
			Kalimba = 109,
			Bagpipe = 110,
			Fiddle = 111,
			Shanai = 112,
			TinkleBell = 113,
			Agogo = 114,
			SteelDrums = 115,
			Woodblock = 116,
			TailoDrum = 117,
			MelodicDrum = 118,
			SynthDrum = 119,
			ReverseCymbal = 120,
			GuitarFretNoise = 121,
			BreathNoise = 122,
			Seashore = 123,
			BirdTweet = 124,
			TelephoneRing = 125,
			Helicopter = 126,
			Applause = 127,
			Gunshot = 128
		};

		class MidiRaw : List<byte>
		{
			protected void WriteRaw(params byte[] rawBytes)
			{
				AddRange(rawBytes);
			}

			protected void WriteRaw(string s, params byte[] rawBytes)
			{
				AddRange(Encoding.ASCII.GetBytes(s));
				WriteRaw(rawBytes);
			}
		};

		// Encoding for events within a MIDI track
		class MidiTrack : MidiRaw
		{
			private uint delay;
			private uint runningStatus;

			public MidiTrack()
			{
				delay = 0;
				runningStatus = 0;
			}

			// Timing
			public void IncreaseDelay(uint amount) { delay += amount; }

			private void WriteVarLen(uint t)
			{
				if ((t >> 21) > 0) WriteRaw((byte)(0x80 | ((t >> 21) & 0x7F)));
				if ((t >> 14) > 0) WriteRaw((byte)(0x80 | ((t >> 14) & 0x7F)));
				if ((t >> 7) > 0) WriteRaw((byte)(0x80 | ((t >> 7) & 0x7F)));
				WriteRaw((byte)((t >> 0) & 0x7F));
			}

			private void Flush()
			{
				WriteVarLen(delay);
				delay = 0;
			}


			private void WriteEvent(byte data, params byte[] rawBytes)
			{
				Flush();
				if (data != runningStatus) WriteRaw((byte)(runningStatus = data));
				WriteRaw(rawBytes);
			}

			public void WriteMetaEvent(byte metatype, byte nbytes, params byte[] rawBytes)
			{
				Flush();
				WriteRaw(0xFF, metatype, nbytes);
				WriteRaw(rawBytes);
			}

			// Key-related params [channel #, note #, pressure]
			public void KeyOn(int ch, int n, int p) { if (n >= 0) WriteEvent((byte)(0x90 | ch), (byte)n, (byte)p); }
			public void KeyOff(int ch, int n, int p) { if (n >= 0) WriteEvent((byte)(0x80 | ch), (byte)n, (byte)p); }
			public void KeyTouch(int ch, int n, int p) { if (n >= 0) WriteEvent((byte)(0xA0 | ch), (byte)n, (byte)p); }

			// Events with other param types
			public void Control(int ch, int c, int v) { WriteEvent((byte)(0xB0 | ch), (byte)c, (byte)v); }
			public void Patch(int ch, PatchType patchnum) { WriteEvent((byte)(0xC0 | ch), (byte)(patchnum)); }
			public void Wheel(int ch, uint value) { WriteEvent((byte)(0xE0 | ch), (byte)(value & 0x7F), (byte)((value >> 7) & 0x7F)); }

			// Add metadata
			public void WriteText(int texttype, string text) { WriteMetaEvent((byte)texttype, (byte)text.Length, Encoding.ASCII.GetBytes(text)); }
		};

		// MIDI file wrapper
		class MidiFile : MidiRaw
		{
			private readonly List<MidiTrack> tracks = new List<MidiTrack>(16);
			private readonly uint deltaticks;
			private readonly uint tempo;

			public MidiFile()
			{
				deltaticks = 1000;
				tempo = 1000000;
			}

			public void WriteLoopStart() { this[0].WriteText(6, "loopStart"); }
			public void WriteLoopEnd() { this[0].WriteText(6, "loopEnd"); }

			public new MidiTrack this[int tracknum]
			{
				get
				{
					if (tracknum >= tracks.Count)
					{
						tracks.Capacity = 16;
						for (int i = 0; i < tracknum + 1; i++) tracks.Add(new MidiTrack());
					}
					MidiTrack result = tracks[tracknum];
					if (result.Count == 0)
					{
						/*
						** Meta 0x58 (misc settings):
						**    time signature: 4/2
						**    ticks/metro:    24
						**    32nd per 1/4:   8
						*/
						result.WriteMetaEvent(0x58, 4, 4, 2, 24, 8);
						// Meta 0x51 (tempo):
						result.WriteMetaEvent(0x51, 3, (byte)(tempo >> 16), (byte)(tempo >> 8), (byte)(tempo));
					}
					return result;
				}
			}

			public void Finish()
			{
				Clear();
				WriteRaw(
					// MIDI signature (MThd and number 6)
					"MThd", new byte[] { 0, 0, 0, 6,
					// Format number (1: multiple tracks, synchronous)
					0, 1,
					(byte)(tracks.Count >> 8), (byte)(tracks.Count),
					(byte)(deltaticks >> 8), (byte)deltaticks });

				foreach (MidiTrack t in tracks)
				{
					// Add meta 0x2F to the track, indicating the track end:
					t.WriteMetaEvent(0x2F, 0);
					// Add the track into the MIDI file:
					WriteRaw("MTrk",
						new[] { (byte)(t.Count >> 24),
							(byte)(t.Count >> 16),
							(byte)(t.Count >> 8),
							(byte)(t.Count >> 0) });
					AddRange(t);
				}
			}
		};

		public static int GetNote(NoteTable nt, int octave) { return (int)nt + (octave * 12); }

		public static int GetNote(NoteTable nt) { return GetNote(nt, 0); }

		public static void MIDIExample1()
		{
			// Chords
			int[][] chords =
			{
				new[] { GetNote(NoteTable.DSharp, 4), GetNote(NoteTable.GSharp, 4) },
				new[] { GetNote(NoteTable.DSharp, 4), GetNote(NoteTable.BSharp, 4) },
				new[] { GetNote(NoteTable.GSharp, 4), GetNote(NoteTable.DSharp, 5) },
				new[] { GetNote(NoteTable.GSharp, 4), GetNote(NoteTable.FSharp, 5) },
				new[] { GetNote(NoteTable.FSharp, 4), GetNote(NoteTable.ASharp, 5) },
				new[] { GetNote(NoteTable.GSharp, 4), GetNote(NoteTable.BSharp, 5) },
				new[] { GetNote(NoteTable.GSharp, 4), GetNote(NoteTable.BSharp, 5) }
			};

			int[] uNotes =
			{
				GetNote(NoteTable.DSharp, 3),
				GetNote(NoteTable.GSharp, 3),
				GetNote(NoteTable.DSharp, 4),
				GetNote(NoteTable.FSharp, 4),
				GetNote(NoteTable.ASharp, 5),
				GetNote(NoteTable.BSharp, 5)
			};

			const int x = NoNote; // Arbitrary value for no note played

			int[] chordline =
			{
				0, x, x, x, x, x, x, x,
				x, x, x, x, x, x, x, x,
				x, x, x, x, 1, x, x, x,
				x, x, x, x, 2, x, x, x,
				x, x, x, x, 3, x, x, x,
				x, x, x, x, 4, x, x, x,
				x, x, x, x, 4, x, x, x,
				5, x, x, x, 6, x, x, x
			};
			int[] bassline =
			{
				0, x, x, x, x, x, x, x,
				x, x, x, x, x, x, x, x,
				x, x, x, x, 2, x, x, x,
				x, x, x, x, x, x, x, x,
				x, x, x, x, x, x, x, x,
				x, x, x, x, 3, x, x, x,
				x, x, x, x, 0, x, x, x,
				2, x, x, x, 0, x, x, x
			};

			MidiFile file = new MidiFile();
			file.WriteLoopStart();

			// Choose Patches for each channel
			PatchType[] patches =
			{
				PatchType.None,          PatchType.None,          PatchType.None,          PatchType.Synthstrings2,
				PatchType.Synthstrings2, PatchType.Synthstrings2, PatchType.Timpani,       PatchType.Timpani,
				PatchType.Timpani,       PatchType.None,          PatchType.None,          PatchType.None,
				PatchType.None,          PatchType.None,          PatchType.ElectricBass1, PatchType.Flute
			};

			for (int c = 0; c < 16; ++c)
				if (c != 10) // Patch all channels except the percussion channel
					file[0].Patch(c, patches[c]);

			int[] keysOn = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
			for (uint loops = 0; loops < 2; ++loops)
			{
				for (uint row = 0; row < 128; ++row)
				{
					for (int c = 0; c < 16; ++c)
					{
						int note = x, vol = 127;
						if (c < 3)
						{
							int chord = chordline[row % 64];
							if (chord != x)
							{
								note = chords[chord][c % 2];
								vol = 0x4B;
							}
						}
						else if (c == 14)
						{
							int k = bassline[row % 64];
							note = k == x ? x : uNotes[k];
							vol = 0x6F;
						}
						if (note == x && (c < 15 || row % 31 > 0)) continue;
						file[0].KeyOff(c, keysOn[c], 0x20);
						keysOn[c] = -1;
						if (note == x) continue;
						file[0].KeyOn(c, keysOn[c] = note, vol);
					}
					file[0].IncreaseDelay(200);
				}
				if (loops == 0) file.WriteLoopEnd();
			}

			file.Finish();
			File.WriteAllBytes(@"ex1.mid", file.ToArray());
		}
	}
}