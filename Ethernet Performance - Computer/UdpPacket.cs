using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethernet_Performance___Computer {
	public class UdpPacket {
		public static readonly byte START_BYTE = 0xFF;
		public static readonly byte CHECKSUM_MASK = 0xFF;
		public static readonly int MAX_LENGTH = 255;

		//public byte StartByte;
		public Command Command;
		//public byte Length;
		public byte[] Data;
		public byte Checksum;

		public byte[] AllBytes {
			get {
				byte[] bytes = new byte[Data.Length + 3];
				bytes[0] = START_BYTE;
				bytes[1] = (byte)Command;
				Array.Copy(Data, 0, bytes, 2, Data.Length);
				bytes[bytes.Length - 1] = Checksum;
				return bytes;
			}
		}

		private UdpPacket() {
		}

		public UdpPacket(Command command, params byte[] data) {
			this.Command = command;
			if (data == null) this.Data = new byte[0];
			else if (data.Length <= MAX_LENGTH) this.Data = data;
			else {
				this.Data = new byte[MAX_LENGTH];
				Array.Copy(data, this.Data, MAX_LENGTH);
			}
			Checksum = (byte)command;
			foreach (byte b in Data) Checksum += b;
			Checksum &= CHECKSUM_MASK;
		}

		public static UdpPacket ParseData(byte[] data) {
			if (data.Length < 3) return null;

			UdpPacket packet = new UdpPacket();
			//packet.StartByte = data[0];
			packet.Command = (Command)data[1];
			//packet.Length = data[2];
			packet.Checksum = data[data.Length - 1];

			if ((data[0] != START_BYTE)
				//|| (packet.Command == START_BYTE)
				//|| (packet.Length == START_BYTE)
				/*|| (packet.Checksum == START_BYTE)*/) return null;

			//Check both for invalid bytes and the checksum.
			byte checksum = 0;
			for(int i = 1; i < (data.Length - 1); i++) {
//				if (data[i] == START_BYTE) return null;
				checksum += data[i];
			}

			if ((checksum & CHECKSUM_MASK) != data[data.Length - 1]) return null;

			packet.Data = new byte[data.Length - 3];
			Array.Copy(data, 2, packet.Data, 0, data.Length - 3);

			return packet;
		}

	}
}
