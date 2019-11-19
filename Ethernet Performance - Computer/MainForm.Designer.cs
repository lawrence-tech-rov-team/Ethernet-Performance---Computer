namespace Ethernet_Performance___Computer {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.DisconnectBtn = new System.Windows.Forms.Button();
			this.MsgTextBox = new System.Windows.Forms.TextBox();
			this.SendBtn = new System.Windows.Forms.Button();
			this.PingTestBtn = new System.Windows.Forms.Button();
			this.AvgPingLabel = new System.Windows.Forms.Label();
			this.LargePacketBtn = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// ConnectBtn
			// 
			this.ConnectBtn.Location = new System.Drawing.Point(56, 316);
			this.ConnectBtn.Name = "ConnectBtn";
			this.ConnectBtn.Size = new System.Drawing.Size(95, 30);
			this.ConnectBtn.TabIndex = 0;
			this.ConnectBtn.Text = "Connect";
			this.ConnectBtn.UseVisualStyleBackColor = true;
			this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
			// 
			// DisconnectBtn
			// 
			this.DisconnectBtn.Enabled = false;
			this.DisconnectBtn.Location = new System.Drawing.Point(157, 316);
			this.DisconnectBtn.Name = "DisconnectBtn";
			this.DisconnectBtn.Size = new System.Drawing.Size(92, 30);
			this.DisconnectBtn.TabIndex = 1;
			this.DisconnectBtn.Text = "Disconnect";
			this.DisconnectBtn.UseVisualStyleBackColor = true;
			this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
			// 
			// MsgTextBox
			// 
			this.MsgTextBox.Location = new System.Drawing.Point(56, 146);
			this.MsgTextBox.Name = "MsgTextBox";
			this.MsgTextBox.Size = new System.Drawing.Size(271, 22);
			this.MsgTextBox.TabIndex = 2;
			this.MsgTextBox.Text = "Hello, world!";
			// 
			// SendBtn
			// 
			this.SendBtn.Enabled = false;
			this.SendBtn.Location = new System.Drawing.Point(56, 183);
			this.SendBtn.Name = "SendBtn";
			this.SendBtn.Size = new System.Drawing.Size(92, 30);
			this.SendBtn.TabIndex = 3;
			this.SendBtn.Text = "Send";
			this.SendBtn.UseVisualStyleBackColor = true;
			this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
			// 
			// PingTestBtn
			// 
			this.PingTestBtn.Enabled = false;
			this.PingTestBtn.Location = new System.Drawing.Point(404, 12);
			this.PingTestBtn.Name = "PingTestBtn";
			this.PingTestBtn.Size = new System.Drawing.Size(92, 30);
			this.PingTestBtn.TabIndex = 4;
			this.PingTestBtn.Text = "Ping Test";
			this.PingTestBtn.UseVisualStyleBackColor = true;
			this.PingTestBtn.Click += new System.EventHandler(this.PingTestBtn_Click);
			// 
			// AvgPingLabel
			// 
			this.AvgPingLabel.AutoSize = true;
			this.AvgPingLabel.Location = new System.Drawing.Point(401, 45);
			this.AvgPingLabel.Name = "AvgPingLabel";
			this.AvgPingLabel.Size = new System.Drawing.Size(46, 17);
			this.AvgPingLabel.TabIndex = 5;
			this.AvgPingLabel.Text = "label1";
			// 
			// LargePacketBtn
			// 
			this.LargePacketBtn.Enabled = false;
			this.LargePacketBtn.Location = new System.Drawing.Point(502, 12);
			this.LargePacketBtn.Name = "LargePacketBtn";
			this.LargePacketBtn.Size = new System.Drawing.Size(105, 30);
			this.LargePacketBtn.TabIndex = 6;
			this.LargePacketBtn.Text = "Large Packet";
			this.LargePacketBtn.UseVisualStyleBackColor = true;
			this.LargePacketBtn.Click += new System.EventHandler(this.LargePacketBtn_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.LargePacketBtn);
			this.Controls.Add(this.AvgPingLabel);
			this.Controls.Add(this.PingTestBtn);
			this.Controls.Add(this.SendBtn);
			this.Controls.Add(this.MsgTextBox);
			this.Controls.Add(this.DisconnectBtn);
			this.Controls.Add(this.ConnectBtn);
			this.Name = "MainForm";
			this.Text = "Ethernet Performance";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ConnectBtn;
		private System.Windows.Forms.Button DisconnectBtn;
		private System.Windows.Forms.TextBox MsgTextBox;
		private System.Windows.Forms.Button SendBtn;
		private System.Windows.Forms.Button PingTestBtn;
		private System.Windows.Forms.Label AvgPingLabel;
		private System.Windows.Forms.Button LargePacketBtn;
		private System.Windows.Forms.Timer timer1;
	}
}

