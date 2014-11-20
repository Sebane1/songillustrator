//using System;
//using System.Collections.Generic;
//;
//using System.Text;
//using System.IO;
//using System.Drawing;

//namespace SongIllustrator {
//  public class MidiIO {
//    private static bool CheckEqualColor(Color a, Color b) {
//      return (a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B);
//    }
//    public MidiIO() {

//    }
//    // reverse byte order (16-bit)
//    public static UInt16 ReverseBytes(UInt16 value) {
//      return (UInt16) ((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
//    }

//    // reverse byte order (32-bit)
//    public static UInt32 ReverseBytes(UInt32 value) {
//      return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
//             (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
//    }

//    // reverse byte order (64-bit)
//    public static UInt64 ReverseBytes(UInt64 value) {
//      return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
//             (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
//             (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
//             (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
//    }
//    public static void CopyStream(Stream input, Stream output) {
//      byte[] buffer = new byte[8 * 1024];
//      int len;
//      while ((len = input.Read(buffer, 0, buffer.Length)) > 0) {
//        output.Write(buffer, 0, len);
//      }
//    }
//    /// <summary>
//    /// Outputs an MIDI file based on frames for the Novation Launchpad.
//    /// </summary>
//    /// <param name="filename"></param>
//    /// <param name="frameData"></param>
//    /// <param name="bpm"></param>
//    /// <param name="ppq"></param>
//    public static void WriteMidi(string filename, List<FrameData> frameData, decimal bpm, decimal ppq) {
//      using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
//        //Get our midi data sorted so we can know its byte length.
//        MemoryStream midiStream = MidiData(frameData, bpm, ppq);
//        // Output midi file header
//        stream.WriteByte(77);
//        stream.WriteByte(84);
//        stream.WriteByte(104);
//        stream.WriteByte(100);
//        for (int i = 0; i < 3; i++) {
//          stream.WriteByte(0);
//        }
//        stream.WriteByte(6);

//        // Set the track mode
//        byte[] trackMode = BitConverter.GetBytes(ReverseBytes(Convert.ToUInt16(0)));
//        stream.Write(trackMode, 0, trackMode.Length);

//        // Set the track amount
//        byte[] trackAmount = BitConverter.GetBytes(ReverseBytes(Convert.ToUInt16(1)));
//        stream.Write(trackAmount, 0, trackAmount.Length);

//        // Set the ppq
//        byte[] ppqByteArray = BitConverter.GetBytes(ReverseBytes(Convert.ToUInt16(ppq)));
//        stream.Write(ppqByteArray, 0, ppqByteArray.Length);

//        // Output track header
//        stream.WriteByte(77);
//        stream.WriteByte(84);
//        stream.WriteByte(114);
//        stream.WriteByte(107);
//        for (int i = 0; i < 3; i++) {
//          stream.WriteByte(0);
//        }
//        // Write the tracks byte length
//        byte[] bytes = BitConverter.GetBytes(ReverseBytes((UInt16) (midiStream.Length)));
//        // Write our byte length to the midi file.
//        stream.Write(bytes, 0, bytes.Length);
//        // Set the tempo
//        byte[] tempo = BitConverter.GetBytes(ReverseBytes((UInt16) ((int)bpm * 60000)));
//        stream.WriteByte(255);
//        stream.WriteByte(81);
//        stream.WriteByte(3);
//        stream.Write(tempo, 0, tempo.Length);
//        // Write the MIDI data.
//        midiStream.WriteTo(stream);
//        // End the MIDI file.
//        stream.WriteByte(255);
//        stream.WriteByte(47);
//        stream.WriteByte(0);
//      }
//    }
//    //public static void WriteMidi(string filename, List<FrameData> frameData, int bpm, int ppq) {
//    //  using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
//    //    using (MidiFileStreamWriter midiStreamWriter = new MidiFileStreamWriter(stream)) {
//    //      decimal lastInterval = 0;
//    //      midiStreamWriter.WriteMetaEvent(0, CannedBytes.Midi.Message.MidiMetaType.Tempo, BitConverter.GetBytes((bpm * 60000000)));
//    //      foreach (FrameData frame in frameData) {
//    //        // Calculate our relative delta for this frame. Frames are originally stored in milliseconds.
//    //        for (int i = 0; i < frame.Colours.Count; i++) {
//    //          // Get the respective MIDI note based on the colours array index.
//    //          byte note = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(i));
//    //          byte[] noteMessage = new byte[3];
//    //          // Check if the current color signals a MIDI off event.
//    //          if (!CheckEqualColor(frame.Colours[i], Color.Black) && !CheckEqualColor(frame.Colours[i], Color.Gray) && !CheckEqualColor(frame.Colours[i], Color.Purple)) {
//    //            // Signal a MIDI on event.
//    //            noteMessage[0] = (144);
//    //            // Write the current note.
//    //            noteMessage[1] = (note);
//    //            // Check colour and write the respective velocity.
//    //            if (CheckEqualColor(frame.Colours[i], Color.Red)) {
//    //              noteMessage[2] = (7);
//    //            } else if (CheckEqualColor(frame.Colours[i], Color.Orange)) {
//    //              noteMessage[2] = (83);
//    //            } else if (CheckEqualColor(frame.Colours[i], Color.Green) || CheckEqualColor(frame.Colours[i], Color.Aqua) || CheckEqualColor(frame.Colours[i], Color.Blue)) {
//    //              noteMessage[2] = (124);
//    //            } else if (CheckEqualColor(frame.Colours[i], Color.Yellow)) {
//    //              noteMessage[2] = (127);
//    //            }
//    //          } else {
//    //            // Signal a MIDI off event.
//    //            noteMessage[0] = (128);
//    //            // Write the current note.
//    //            noteMessage[1] = (note);
//    //            //
//    //            noteMessage[2] = (0);
//    //          }
//    //          if (i < 1) {
//    //            midiStreamWriter.WriteMidiEvent((long)(frame.TimeStamp - lastInterval) * 60 * bpm * ppq, (int)noteMessage[1]);
//    //          } else {
//    //            midiStreamWriter.WriteMidiEvent((long) (0), (int) noteMessage[1]);
//    //          }
//    //        }
//    //      }
//    //    }
//    //  }
//    //}
//    private static MemoryStream MidiData(List<FrameData> frameData, decimal bpm, decimal ppq) {
//      MemoryStream stream = new MemoryStream();
//      decimal currentCount = 0;
//      // Cycle through frames and output the necessary MIDI.
//      Dictionary<int, bool> noteTracker = new Dictionary<int, bool>();
//      foreach (FrameData frame in frameData) {
//        // Calculate our relative delta for this frame. Frames are originally stored in milliseconds.
//        decimal difference = (frame.TimeStamp - (currentCount));
//        decimal interval = difference * bpm * ppq / 60000;
//        currentCount += difference;
//        byte[] delta = BitConverter.GetBytes(VLQ.VarLenQuantity.ToVlq((ulong) (Math.Round(interval))));
//        for (int i = 0; i < frame.Colours.Count; i++) {
//          // Output the delta length to MIDI file.
//          stream.Write(delta, 0, delta.Length);
//          // Get the respective MIDI note based on the colours array index.
//          byte note = (byte) NoteIdentifier.GetIntFromNote(NoteIdentifier.GetNoteFromPosition(i));
//          // Check if the current color signals a MIDI off event.
//          if (!CheckEqualColor(frame.Colours[i], Color.Black) && !CheckEqualColor(frame.Colours[i], Color.Gray) && !CheckEqualColor(frame.Colours[i], Color.Purple)) {
//            if (!noteTracker.ContainsKey(note)) {
//              noteTracker.Add(note, true);
//            } else {
//              noteTracker[note] = true;
//            }
//            // Signal a MIDI on event.
//            stream.WriteByte(144);
//            // Write the current note.
//            stream.WriteByte(note);
//            // Check colour and write the respective velocity.
//            if (CheckEqualColor(frame.Colours[i], Color.Red)) {
//              stream.WriteByte(7);
//            } else if (CheckEqualColor(frame.Colours[i], Color.Orange)) {
//              stream.WriteByte(83);
//            } else if (CheckEqualColor(frame.Colours[i], Color.Green) || CheckEqualColor(frame.Colours[i], Color.Aqua) || CheckEqualColor(frame.Colours[i], Color.Blue)) {
//              stream.WriteByte(124);
//            } else if (CheckEqualColor(frame.Colours[i], Color.Yellow)) {
//              stream.WriteByte(127);
//            }
//          } else {
//            if (!noteTracker.ContainsKey(note)) {
//              noteTracker.Add(note, false);
//            }
//            if (noteTracker[note]) {
//              noteTracker[note] = false;
//              // Signal a MIDI off event.
//              stream.WriteByte(128);
//              // Write the current note.
//              stream.WriteByte(note);
//              // No need to set our velocity to anything.
//              stream.WriteByte(64);
//            }
//          }
//        }
//      }
//      return stream;
//    }
//    public static void OpenMidi(string filename) {
//      using (FileStream openStream = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
//        if (openStream.ReadByte() == 77) {
//          if (openStream.ReadByte() == 84) {
//            if (openStream.ReadByte() == 104) {
//              if (openStream.ReadByte() == 100) {

//              }
//            }
//          }
//        }
//      }
//    }
//  }
//}
