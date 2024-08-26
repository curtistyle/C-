using System.Net;
using System.Net.Sockets;

TcpListener server = null;

try
{

	// Se define un servidor TCP usando 'TcpListener' que escucha
	// en la direccion `127.0.0.1` en el puerto 13000
	Int32 port = 13000;
	IPAddress localAddr = IPAddress.Parse("127.0.0.1");

	server = new TcpListener(localAddr, port);

	// server.Start() comienza a escuchas solicitudes de conexión
	server.Start();


	Byte[] bytes = new Byte[256];
	String data = null;


	// El bucle 'while(true)' asegura que el servidor esta siempre a la espera
	while (true)
	{
		Console.WriteLine("Esperando conexiones...");

		// 'AcceptTcpClient' es una llamada bloqueante que espera hasta que un
		// cliente intente conectarse. Cuando se conecta un cliente, se crea 
		// una instancia de 'TcpClient'
		using TcpClient client = server.AcceptTcpClient();
		
		Console.WriteLine("Conectado!");

		// # RECEPCIÓN Y PROCESAMIENTO DE DATOS

		data = null;

		// Se obtiene un flujo 'NetworkStream' para leer y escribir datos 
		// entre el servidor y el cliente
		NetworkStream stream = client.GetStream();

		int i;

		// En el buclue 'while', el servidor lee los datos enviados por el cliente con 
		// 'stream.Read(bytes, 0, bytes.Length)' y los convierte a una cadena de texto
		// usando la codificacion ASCII
		while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
		{
			data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
			Console.WriteLine("Recived: {0}", data);

			// El servidor convierte el mensaje recibido a mayusculas
			data = data.ToUpper();

			// El servidor le responde al cliente enviándole la cadena en mayusculas 
			// a través del mismo flujo usando 'stream.write()'
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

			stream.Write(msg, 0, msg.Length);
			Console.WriteLine("Sent: {0}", data);
		}
	}
}
catch (SocketException e)
{
	Console.WriteLine("SocketException: {0}", e);
}
finally
{
	server.Stop();
}

Console.WriteLine("\nHit enter to continue...");
Console.Read();
