using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinFormServer.Config
{
	public class Server
	{
		private Int32 _port { get; set; }
		private IPAddress? _address { get; set; }
		
		private TcpListener _tcpListener;

		public Server(int port, string ip)
		{
			Port = port;
			IpAddress = ip;

			_tcpListener = new TcpListener(_address, _port);
		}

		public Int32 Port
		{
			set
			{
				if (value == 0)
				{
					throw new ArgumentException("El puerto no puede ser 0");
				}
				_port = value;
			}
		}

		public string IpAddress
		{
			set
			{
				if (value == null)
				{
					throw new ArgumentException("La ip no puede ser null");
				}
				else if (value == "")
				{
					_address = IPAddress.Parse("127.0.0.1");
				}
				else
				{
					_address = IPAddress.Parse(value);
				}
			}
		}

		public void Start()
		{
			_tcpListener.Start();

		}

		public Task<Action> Speack()
		{
			Byte[] bytes = new Byte[256];
			String data = null;


		}
	}
}
