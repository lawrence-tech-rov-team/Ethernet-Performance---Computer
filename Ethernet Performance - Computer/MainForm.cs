using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ethernet_Performance___Computer {
	public partial class MainForm : Form {

		private const int DEST_PORT = 6001;
		private const int RECV_PORT = 6002;
		private const string IP = "169.254.240.157"; //"255.255.255.255";

		private Stopwatch pingTimer = new Stopwatch();
		private Random rnd = new Random();

		private UdpClient client;
		private ConcurrentQueue<byte> recvData = new ConcurrentQueue<byte>();

		public MainForm() {
			InitializeComponent();
		}

		private void EnableStates(bool connected) {
			DisconnectBtn.Enabled = connected;
			SendBtn.Enabled = connected;
			ConnectBtn.Enabled = !connected;
			PingTestBtn.Enabled = connected;
			LargePacketBtn.Enabled = connected;
			TestBtn.Enabled = connected;
		}

		private void ConnectBtn_Click(object sender, EventArgs e) {
			EnableStates(true);

			client = new UdpClient();
			client.Client.Bind(new IPEndPoint(IPAddress.Any, RECV_PORT));
			//Console.WriteLine(client.Client.ReceiveBufferSize);

			try {
				client.BeginReceive(new AsyncCallback(OnDataReceived), null);
			}catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			//client.Client.Bind(new IPEndPoint(IPAddress.Any, DEST_PORT));
		}

		private void DisconnectBtn_Click(object sender, EventArgs e) {
			EnableStates(false);
			pingTimer.Stop();

			client.Close();
			client = null;
		}

		private void SendBtn_Click(object sender, EventArgs e) {
			if(client != null) {
				byte[] data = Encoding.UTF8.GetBytes(MsgTextBox.Text);
				client.Send(data, data.Length, IP, DEST_PORT);
			}
		}

		private void printPingResults() {
			AvgPingLabel.Text = "Ping time: " + pingTimer.Elapsed.TotalMilliseconds + " ms";
		}

		private void OnDataReceived(IAsyncResult res) {
			IPEndPoint ip = new IPEndPoint(IPAddress.Any, RECV_PORT);
			byte[] data = client.EndReceive(res, ref ip);

			foreach (byte b in data) recvData.Enqueue(b);
			//recvData.Enqueue(Encoding.UTF8.GetString(data));

			client.BeginReceive(new AsyncCallback(OnDataReceived), null);
		}

		private void PingTestBtn_Click(object sender, EventArgs e) {
			if (client != null) {
				byte[] data = Encoding.UTF8.GetBytes("Ping!");
				pingTimer.Restart();
				client.Send(data, data.Length, IP, DEST_PORT);
			}
		}

		private void LargePacketBtn_Click(object sender, EventArgs e) {
			if (client != null) {
				timer1.Stop();
				{
					readBuffer();

					byte[] data = new byte[400];
					for (int i = 0; i < 400; i++) {
						data[i] = (byte)('0' + (i % 10));
					}
					pingTimer.Restart();
					client.Send(data, data.Length, IP, DEST_PORT);
					while (recvData.IsEmpty) { }
					pingTimer.Stop();
					printPingResults();
					readBuffer();
				}
				timer1.Start();
			}
		}

		private bool foundStart = false;

		private void readBuffer() {
			/*while (!recvData.IsEmpty) {
				string data;
				if (recvData.TryDequeue(out data)) {
					if (data.Length > 20) {
						Console.Write(data.Substring(0, 20));
						Console.Write("...");
						Console.Write(data.Substring(Math.Max(20, data.Length - 5), Math.Max(0, Math.Min(5, data.Length - 20))));
						Console.Write("  Size = ");
						Console.WriteLine(data.Length);
					} else {
						Console.WriteLine(data);
					}
				}
			}*/
			while (!recvData.IsEmpty) {
				if (!foundStart) {
					byte data;
					while (!recvData.IsEmpty) {
						if (recvData.TryDequeue(out data)) {
							if (data == 0xFF) {
								foundStart = true;
								break;
							}
						}
					}
				}

				if (!recvData.IsEmpty) {
					byte cmd;
					while (!recvData.TryPeek(out cmd)) { }

					switch (cmd) {
						case 0x00:
							CmdPing();
							break;
						default:
							foundStart = false;
							break;
					}
				}
			}
		}

		private void CmdPing() {
			if(recvData.Count >= 3) {
				byte[] buffer = fillFromBuffer(3);
				if ((buffer == null) || (buffer.Length != 3)) return;
				if (buffer[0] != 0x00) return;
				else foundStart = false;
				byte checksum = (byte)((0xFF + buffer[0] + buffer[1]) & 0x7F);
				if(checksum == buffer[2]) {
					Console.WriteLine("Ping! {0}", buffer[1]);
				}
			}
		}

		private byte[] fillFromBuffer(int count) {
			byte[] buffer = new byte[count];
			for(int i = 0; i < count; i++) {
				byte data;
				if (recvData.TryDequeue(out data)) {
					buffer[i] = data;
				} else return null;
			}
			return buffer;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			readBuffer();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			timer1.Start();
		}

		private void TestBtn_Click(object sender, EventArgs e) {
			try {
				if (client != null) {
					byte num = (byte)(rnd.Next(0, 254) & 0xFF);
					byte checksum = (byte)((0xFF + num) & 0x7F);
					byte[] data = new byte[] { 0xFF, 0x00, num, checksum };//Encoding.UTF8.GetBytes("Ping!");
					Console.WriteLine("Send Ping: {0}", num);
					client.Send(data, data.Length, IP, DEST_PORT);
				}
			} catch(Exception ex) {
				Console.WriteLine("Failed send: " + ex.Message);
			}
		}
	}
}
