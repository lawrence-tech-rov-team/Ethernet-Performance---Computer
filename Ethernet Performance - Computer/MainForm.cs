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

		private const int DEST_PORT = 6001;
		private const int RECV_PORT = 6002;
		private const string IP = "169.254.240.157"; //"255.255.255.255";

		private UdpClient client;

		public MainForm() {
			InitializeComponent();
		}

		private void ConnectBtn_Click(object sender, EventArgs e) {
			DisconnectBtn.Enabled = SendBtn.Enabled = true;
			ConnectBtn.Enabled = false;

			client = new UdpClient();
			client.Client.Bind(new IPEndPoint(IPAddress.Any, RECV_PORT));

			try {
				client.BeginReceive(new AsyncCallback(OnDataReceived), null);
			}catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			//client.Client.Bind(new IPEndPoint(IPAddress.Any, DEST_PORT));
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
				client.Send(data, data.Length, IP, DEST_PORT);
			}
		}


		private void OnDataReceived(IAsyncResult res) {
			IPEndPoint ip = new IPEndPoint(IPAddress.Any, RECV_PORT);
			byte[] data = client.EndReceive(res, ref ip);

			Console.WriteLine(Encoding.UTF8.GetString(data));
			client.BeginReceive(new AsyncCallback(OnDataReceived), null);
		}
	}
}
