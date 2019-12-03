using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethernet_Performance___Computer {
	public class EthernetInterface {

		public int DestinationPort { get; } = 6001;
		public int ReceivePort { get; } = 6002;
		public string TargetIp { get; set; } = "169.254.240.157"; //255.255.255.255
		public bool Connected { get; private set; } = false;

		private UdpClient client;
		private Random random = new Random();

		public delegate void NewPacketHandler(UdpPacket packet);
		public event NewPacketHandler OnPacketReceived;
		//TODO send/receive timeouts
		public EthernetInterface() {

		}

		public bool TryConnect() {
			/*try {
				if(client != null) client.Close();
			} catch (SocketException) {
			}*/

			try {
				client = new UdpClient();
				client.Client.Bind(new IPEndPoint(IPAddress.Any, ReceivePort));
				//client.Connect(new IPEndPoint(IPAddress.Any, ReceivePort));
				/*int origSend = client.Client.SendTimeout;
				int origRecv = client.Client.ReceiveTimeout;
				client.Client.SendTimeout = client.Client.ReceiveTimeout = 1000;
				bool success = false;
				try {
					IPEndPoint ip = new IPEndPoint(IPAddress.Any, ReceivePort);
					byte[] pings = new byte[10];
					random.NextBytes(pings);
					int counts = 0;
					for (int i = 0; i < 10; i++) {
						Console.Out.WriteLine("Attempt #{0}...", i);
						UdpPacket packet = new UdpPacket(Command.Ping, pings[i]);
						byte[] data = packet.AllBytes;
						client.Send(data, data.Length, TargetIp, DestinationPort);
						try {
							data = client.Receive(ref ip);
						} catch (SocketException) { }
						packet = UdpPacket.ParseData(data);
						if((packet != null) && (packet.Command == Command.Ping) && (packet.Data != null) && (packet.Data.Length >= 1) && (packet.Data[0] == pings[0])) {
							counts++;
							if (counts >= 3) break;
						}
					}
					if (counts >= 3) success = true;
				} catch (Exception ex2) {
					Console.Error.WriteLine("Error trying to connect: {0}", ex2.Message);
					Console.Error.WriteLine(ex2.StackTrace);
					success = false;
				}

				client.Client.SendTimeout = origSend;
				client.Client.ReceiveTimeout = origRecv;*/
				bool success = true;
				if(success) client.BeginReceive(new AsyncCallback(OnDataReceived), null);
				return success;
				return true;
			} catch(Exception ex) {
				try {
					client.Close();
				} catch (SocketException) {
				}

				Console.Error.WriteLine("Could not connect to IP: {0}", ex.Message);
				Console.Error.WriteLine(ex.StackTrace);
				return false;
			}
		}

		public void Disconnect() {
			client.Close();
		}

		public bool Send(UdpPacket packet) {
			try {
				byte[] data = packet.AllBytes;
				client.Send(data, data.Length, TargetIp, DestinationPort);
				return true;
			}catch(Exception ex) {
				Console.Error.WriteLine("Error sending packet: {0}", ex.Message);
				Console.Error.WriteLine(ex.StackTrace);
				return false;
			}
		}

		public bool Send(Command command, params byte[] data) {
			return Send(new UdpPacket(command, data));
		}

		public bool Send(Command command, string message, bool clip = true) {
			if (clip || (message.Length <= UdpPacket.MAX_LENGTH))
				return Send(new UdpPacket(command, Encoding.UTF8.GetBytes(message)));
			else {
				bool result = Send(new UdpPacket(command, Encoding.UTF8.GetBytes(message.Substring(0, UdpPacket.MAX_LENGTH))));
				if (!result) return false;
				return Send(command, message.Substring(UdpPacket.MAX_LENGTH), clip);
			}
		}

		private void OnDataReceived(IAsyncResult res) {
			IPEndPoint ip = new IPEndPoint(IPAddress.Any, ReceivePort);
			byte[] data = client.EndReceive(res, ref ip);
			UdpPacket packet = UdpPacket.ParseData(data);
			if (packet != null) OnPacketReceived?.Invoke(packet);
			else Console.Out.WriteLine("Bad packet received.");
			client.BeginReceive(new AsyncCallback(OnDataReceived), null);
		}
	}
}
