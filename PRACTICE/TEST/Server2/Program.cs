using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
	internal class Program
	{

		static async Task Main(string[] args)
		{
			Server srv = new Server();
			try
			{
				srv.Start();
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
			finally
			{
				srv.Stop();
			}
		}
	}

	internal class Server
	{
		Int32 port = 13000;
		IPAddress localAddr = IPAddress.Parse("127.0.0.1");
		TcpListener server = null;

		public Server()
        {
			server = new TcpListener(localAddr, port);
			server.Start();
		}

		public void Start()
		{
			while (true)
			{
				Byte[] bytes = new Byte[256];
				String data = null;

				Console.WriteLine("Esperando conexiones...");
				TcpClient client = server.AcceptTcpClient();

				Console.WriteLine("Conectado!");

				data = null;

				NetworkStream stream = client.GetStream();

				int i;

				while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
				{
					data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
					Console.WriteLine("Recived: {0}", data);

					data = data.ToUpper();


					byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

					stream.Write(msg, 0, msg.Length);
					Console.WriteLine("Sent: {0}", data);
				}
			}
		}

		public void Stop()
		{
			server.Stop();
		}
	}
}
