using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ethernet_Performance___Computer {
	public partial class MainForm : Form {

		private const int PORT = 6003;
		private const string IP = "169.254.240.157"; //"255.255.255.255";

		private UdpClient client;

		public MainForm() {
			InitializeComponent();
		}

		private void ConnectBtn_Click(object sender, EventArgs e) {
			DisconnectBtn.Enabled = SendBtn.Enabled = true;
			ConnectBtn.Enabled = false;

			client = new UdpClient();
			client.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
		}

		private void DisconnectBtn_Click(object sender, EventArgs e) {
			ConnectBtn.Enabled = true;
			DisconnectBtn.Enabled = SendBtn.Enabled = false;

			client.Close();
			client = null;
		}

		private void SendBtn_Click(object sender, EventArgs e) {
			if(client != null) {
				byte[] data = Encoding.UTF8.GetBytes(MsgTextBox.Text);
				client.Send(data, data.Length, IP, PORT);
			}
		}
	}
}
