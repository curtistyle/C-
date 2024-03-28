using System.Net.Sockets;
using System.Net;


await RunServerAsync();

async Task RunServerAsync()
{
    Console.WriteLine(IPAddress.Loopback.ToString());
    var listener = new TcpListener(IPAddress.Loopback, 51111);
    listener.Start();
    try
    {
        while (true)
            Accept(await listener.AcceptTcpClientAsync());
    }
    finally { listener.Stop(); }
}

async Task Accept(TcpClient client)
{
    await Task.Yield();
    try
    {
        using (client)
        using (NetworkStream n = client.GetStream())
        {
            byte[] data = new byte[5000];

            int bytesRead = 0; int chunkSize = 1;
            while (bytesRead < data.Length && chunkSize > 0)
                bytesRead += chunkSize =
                  await n.ReadAsync(data, bytesRead, data.Length - bytesRead);

            Array.Reverse(data);   // Reverse the byte sequence
            await n.WriteAsync(data, 0, data.Length);
        }
    }
    catch (Exception ex) { Console.WriteLine(ex.Message); }
}