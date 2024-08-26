using System.Net.Sockets;
using WinFormServer.Config;
namespace WinFormServer
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();


		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			// obtengo el puerto y la ip de los textBox
			//serverConfig.setPort(textBoxPort.Text);
			//serverConfig.setIp(textBoxIP.Text);

			// cambio el texto del boton conectar
			buttonConnect.Text = "Disconect";
			
			// deshabilito los inputs text
			textBoxPort.Enabled = false;
			textBoxIP.Enabled = false;

			// servidor
			listViewConsole
				.Items
				.Add($"Defining Server... ");



		}
	}
}
