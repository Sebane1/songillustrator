using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongIllustrator {
	public class VLQ {
		public static class VarLenQuantity {
			public static ulong ToVlq(ulong integer) {
				var array = new byte[8];
				var buffer = ToVlqCollection(integer)
					.SkipWhile(b => b == 0)
					.Reverse()
					.ToArray();
				Array.Copy(buffer, array, buffer.Length);
				return BitConverter.ToUInt64(array, 0);
			}

			public static ulong FromVlq(ulong integer) {
				var collection = BitConverter.GetBytes(integer).Reverse();
				return FromVlqCollection(collection);
			}

			public static IEnumerable<byte> ToVlqCollection(ulong integer) {
				if (integer > Math.Pow(2, 56))
					throw new OverflowException("Integer exceeds max value.");

				var index = 7;
				var significantBitReached = false;
				var mask = 0x7fUL << (index * 7);
				while (index >= 0) {
					var buffer = (mask & integer);
					if (buffer > 0 || significantBitReached) {
						significantBitReached = true;
						buffer >>= index * 7;
						if (index > 0)
							buffer |= 0x80;
						yield return (byte) buffer;
					}
					mask >>= 7;
					index--;
				}
			}


			public static ulong FromVlqCollection(IEnumerable<byte> vlq) {
				ulong integer = 0;
				var significantBitReached = false;

				using (var enumerator = vlq.GetEnumerator()) {
					int index = 0;
					while (enumerator.MoveNext()) {
						var buffer = enumerator.Current;
						if (buffer > 0 || significantBitReached) {
							significantBitReached = true;
							integer <<= 7;
							integer |= (buffer & 0x7fUL);
						}

						if (++index == 8 || (significantBitReached && (buffer & 0x80) != 0x80))
							break;
					}
				}
				return integer;
			}

		}
	}
}