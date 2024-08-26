namespace WinFormServer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			groupBoxServerOptions = new GroupBox();
			textBoxIP = new TextBox();
			label2 = new Label();
			textBoxPort = new TextBox();
			label1 = new Label();
			groupBox1 = new GroupBox();
			listViewConsole = new ListView();
			textBoxInput = new TextBox();
			label3 = new Label();
			buttonConnect = new Button();
			buttonSend = new Button();
			groupBoxServerOptions.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBoxServerOptions
			// 
			groupBoxServerOptions.Controls.Add(textBoxIP);
			groupBoxServerOptions.Controls.Add(label2);
			groupBoxServerOptions.Controls.Add(textBoxPort);
			groupBoxServerOptions.Controls.Add(label1);
			groupBoxServerOptions.Location = new Point(12, 12);
			groupBoxServerOptions.Name = "groupBoxServerOptions";
			groupBoxServerOptions.Size = new Size(477, 77);
			groupBoxServerOptions.TabIndex = 0;
			groupBoxServerOptions.TabStop = false;
			groupBoxServerOptions.Text = "Server Options";
			// 
			// textBoxIP
			// 
			textBoxIP.Location = new Point(232, 34);
			textBoxIP.Name = "textBoxIP";
			textBoxIP.Size = new Size(215, 23);
			textBoxIP.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(203, 37);
			label2.Name = "label2";
			label2.Size = new Size(23, 15);
			label2.TabIndex = 2;
			label2.Text = "IP: ";
			// 
			// textBoxPort
			// 
			textBoxPort.Location = new Point(58, 34);
			textBoxPort.Name = "textBoxPort";
			textBoxPort.Size = new Size(73, 23);
			textBoxPort.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(20, 37);
			label1.Name = "label1";
			label1.Size = new Size(32, 15);
			label1.TabIndex = 0;
			label1.Text = "Port:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(listViewConsole);
			groupBox1.Location = new Point(12, 95);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(477, 156);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Console";
			// 
			// listViewConsole
			// 
			listViewConsole.GridLines = true;
			listViewConsole.Location = new Point(6, 22);
			listViewConsole.Name = "listViewConsole";
			listViewConsole.Size = new Size(464, 128);
			listViewConsole.TabIndex = 0;
			listViewConsole.UseCompatibleStateImageBehavior = false;
			listViewConsole.View = View.List;
			// 
			// textBoxInput
			// 
			textBoxInput.Location = new Point(62, 265);
			textBoxInput.Name = "textBoxInput";
			textBoxInput.Size = new Size(258, 23);
			textBoxInput.TabIndex = 2;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(18, 269);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 3;
			label3.Text = "Input:";
			// 
			// buttonConnect
			// 
			buttonConnect.Location = new Point(407, 265);
			buttonConnect.Name = "buttonConnect";
			buttonConnect.Size = new Size(75, 23);
			buttonConnect.TabIndex = 4;
			buttonConnect.Text = "Connect";
			buttonConnect.UseVisualStyleBackColor = true;
			buttonConnect.Click += buttonConnect_Click;
			// 
			// buttonSend
			// 
			buttonSend.Location = new Point(326, 265);
			buttonSend.Name = "buttonSend";
			buttonSend.Size = new Size(75, 23);
			buttonSend.TabIndex = 5;
			buttonSend.Text = "Send";
			buttonSend.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(494, 301);
			Controls.Add(buttonSend);
			Controls.Add(buttonConnect);
			Controls.Add(label3);
			Controls.Add(textBoxInput);
			Controls.Add(groupBox1);
			Controls.Add(groupBoxServerOptions);
			Name = "Form1";
			Text = "Server";
			groupBoxServerOptions.ResumeLayout(false);
			groupBoxServerOptions.PerformLayout();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBoxServerOptions;
		private Label label1;
		private TextBox textBoxPort;
		private TextBox textBoxIP;
		private Label label2;
		private GroupBox groupBox1;
		private ListView listViewConsole;
		private TextBox textBoxInput;
		private Label label3;
		private Button buttonConnect;
		private Button buttonSend;
	}
}
