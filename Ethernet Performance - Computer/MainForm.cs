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

		private Random rnd = new Random();

		private EthernetInterface ethernet = new EthernetInterface();

		public MainForm() {
			InitializeComponent();
			ethernet.OnPacketReceived += RunCommand;
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
			if (ethernet.TryConnect()) {
				EnableStates(true);
			} else {
				EnableStates(false);
				MessageBox.Show("Could not connect to device.", "Error Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DisconnectBtn_Click(object sender, EventArgs e) {
			EnableStates(false);
			ethernet.Disconnect();
		}

		private void SendBtn_Click(object sender, EventArgs e) {
			if(!ethernet.Send(Command.Echo, MsgTextBox.Text, false)) {
				MessageBox.Show("Error sending echo.", "Error Sending", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void printPingResults() {
		//	AvgPingLabel.Text = "Ping time: " + pingTimer.Elapsed.TotalMilliseconds + " ms";
		}


		private void PingTestBtn_Click(object sender, EventArgs e) {
			/*if (client != null) {
				byte[] data = Encoding.UTF8.GetBytes("Ping!");
				pingTimer.Restart();
				client.Send(data, data.Length, IP, DEST_PORT);
			}*/
			//TODO
		}

		private void LargePacketBtn_Click(object sender, EventArgs e) {
			/*if (client != null) {
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
			}*/
			//TODO
		}

		private void MainForm_Load(object sender, EventArgs e) {
			
		}

		private void TestBtn_Click(object sender, EventArgs e) {
			byte num = (byte)(rnd.Next(0, 255) & 0xFF);
			if(!ethernet.Send(Command.Ping, num)) {
				MessageBox.Show("Error sending ping.", "Error Sending", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void RunCommand(UdpPacket packet) {
			switch (packet.Command) {
				case Command.Ping:
					CmdPing(packet);
					return;
				case Command.Echo:
					CmdEcho(packet);
					return;
				default: return;
			}
		}

		private void CmdPing(UdpPacket packet) {
			/*
			if(recvData.Count >= 3) {
				byte[] buffer = fillFromBuffer(3);
				if ((buffer == null) || (buffer.Length != 3)) return;
				if (buffer[0] != 0x00) return;
				else foundStart = false;
				byte checksum = (byte)((0xFF + buffer[0] + buffer[1]) & 0x7F);
				if(checksum == buffer[2]) {
					Console.WriteLine("Ping! {0}", buffer[1]);
				}
			}*/
			if (packet.Data.Length == 1) {
				Console.WriteLine("Ping! {0}", packet.Data[0]);
			}
		}

		private void CmdEcho(UdpPacket packet) {
			Console.WriteLine("Ehco! {0}", Encoding.UTF8.GetString(packet.Data));
		}

	}
}
