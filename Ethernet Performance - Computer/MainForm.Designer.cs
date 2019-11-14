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
			this.ConnectBtn = new System.Windows.Forms.Button();
			this.DisconnectBtn = new System.Windows.Forms.Button();
			this.MsgTextBox = new System.Windows.Forms.TextBox();
			this.SendBtn = new System.Windows.Forms.Button();
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
			this.MsgTextBox.Size = new System.Drawing.Size(398, 22);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.SendBtn);
			this.Controls.Add(this.MsgTextBox);
			this.Controls.Add(this.DisconnectBtn);
			this.Controls.Add(this.ConnectBtn);
			this.Name = "MainForm";
			this.Text = "Ethernet Performance";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ConnectBtn;
		private System.Windows.Forms.Button DisconnectBtn;
		private System.Windows.Forms.TextBox MsgTextBox;
		private System.Windows.Forms.Button SendBtn;
	}
}

