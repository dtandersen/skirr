
using System.Net;
using System.Net.Sockets;
using System.Text;

/// <summary>
/// This is a simple UDP listener that listens for broadcasts on port 32227.
/// https://github.com/DanielVanNoord/AlpacaDiscoveryTests
/// </summary>
public class DiscoveryListener2 : IScopedProcessingService
{
    private const int listenPort = 32227;
    private const int alpacaPort = 5000;
    private UdpClient client;
    private IPEndPoint groupEP;

    public bool Started { get; private set; }

    public void Start()
    {
        client = new UdpClient(listenPort);
        client.EnableBroadcast = true;
        groupEP = new IPEndPoint(IPAddress.Any, listenPort);
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        // try
        // {
        if (!Started)
        {
            Start();
            Started = true;
        }
        Console.WriteLine($"Listening for UDP discovery broadcast on port {listenPort}...");
        while (!stoppingToken.IsCancellationRequested)
        {
            var receivedResult = await client.ReceiveAsync(stoppingToken);
            // byte[] bytes = listener.Receive(ref groupEP);
            // receivedResult.
            var message = Encoding.ASCII.GetString(receivedResult.Buffer, 0, receivedResult.Buffer.Length);
            // Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
            if (message == "alpacadiscovery1")
            {
                Console.WriteLine($"Received broadcast from {receivedResult.RemoteEndPoint.Address.ToString()} :");
                Console.WriteLine($"{message}");
                // Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // IPAddress endpoint = IPAddress.Parse(receivedResult.RemoteEndPoint.Address.ToString());
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, listenPort);
                // IPAddress broadcast = IPAddress.Parse ("192.168.1.255");

                var result = $$"""
                        {
                            "AlpacaPort": {{alpacaPort}}
                        }
                        """;
                byte[] sendbuf = Encoding.ASCII.GetBytes(result);
                Console.WriteLine($"Sending response to {IPAddress.Parse(receivedResult.RemoteEndPoint.Address.ToString())}: {result}");
                // IPEndPoint ep = new IPEndPoint(endpoint, 32227);

                // s.SendTo(sendbuf, endpoint);
                client.Send(sendbuf, sendbuf.Length, receivedResult.RemoteEndPoint);

                // Console.WriteLine("Message sent to the broadcast address");
            }
            await Task.Delay(10);
        }

        // }
        // catch (SocketException e)
        // {
        //     Console.WriteLine(e);
        // }
    }
    public void Stop()
    {
        client.Close();
    }
}

