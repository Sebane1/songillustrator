/* teVirtualMIDI C# interface
 *
 * Copyright 2009-2012, Tobias Erichsen
 * All rights reserved, unauthorized usage & distribution is prohibited.
 *
 *
 * File: TeVirtualMIDITest.cs
 *
 * This file contains a sample using the TeVirtualMIDI-class, which
 * implements a simple loopback-MIDI-_port.
 */

using System;
using System.Threading;


namespace TobiasErichsen.teVirtualMIDI.test {

	public class Program {

		public static TeVirtualMIDI port;

		public static void WorkThreadFunction() {

			byte[] command;
			while (true) {
				try {
					while (true) {

						command = port.getCommand();

						port.sendCommand(command);

						Console.WriteLine("command: " + byteArrayToString(command));

					}
				} catch (Exception ex) {

					Console.WriteLine("thread aborting: " + ex.Message);

				}
			}

		}

		public static string byteArrayToString(byte[] ba) {

			string hex = BitConverter.ToString(ba);
			return hex;

		}

		public static void Temp() {

			Console.WriteLine("teVirtualMIDI C# loopback sample");
			//Console.WriteLine("using driver-version: " + TeVirtualMIDI.versionString);

			TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);

			port = new TeVirtualMIDI("Song Illustrator");

			Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
			thread.Start();

		/*	Console.WriteLine("Virtual _port created - press enter to close _port again");
			Console.ReadKey();
			_port.shutdown();
			Console.WriteLine("Virtual _port closed - press enter to terminate application");
			Console.ReadKey();*/

		}

	}

}
