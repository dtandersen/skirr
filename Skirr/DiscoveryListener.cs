
using System.Net;
using System.Net.Sockets;
using System.Text;

/// <summary>
/// This is a simple UDP listener that listens for broadcasts on port 32227.
/// https://github.com/DanielVanNoord/AlpacaDiscoveryTests
/// </summary>
public class DiscoveryListener
{
    private const int listenPort = 32227;
    private const int alpacaPort = 5001;

    public static void StartListener()
    {
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

        try
        {
            while (true)
            {
                Console.WriteLine($"Listening for UDP discovery broadcast on port {listenPort}...");
                byte[] bytes = listener.Receive(ref groupEP);
                var message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine($"Received broadcast from {groupEP} :");
                Console.WriteLine($"{message}");
                // Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                if (message == "alpacadiscovery1")
                {
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                    IPAddress broadcast = IPAddress.Parse("192.168.1.255");
                    var result = $$"""
                        {
                            "AlpacaPort": {{alpacaPort}}
                        }
                        """;
                    byte[] sendbuf = Encoding.ASCII.GetBytes(result);
                    Console.WriteLine($"Sending response: {result}");
                    IPEndPoint ep = new IPEndPoint(broadcast, 32227);

                    s.SendTo(sendbuf, ep);

                    // Console.WriteLine("Message sent to the broadcast address");
                }
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }
}
