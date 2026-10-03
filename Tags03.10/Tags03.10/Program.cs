using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tags03._10
{
    internal class Program
    {
        static Dictionary<string, int> players = new Dictionary<string, int>();
        static Dictionary<int, string> positions = new Dictionary<int, string>();

        static int playerId = 0;

        static async Task Main()
        {
            using UdpClient server = new UdpClient(5555);

            Console.WriteLine("Tags server started.");

            while (true)
            {
                UdpReceiveResult result = await server.ReceiveAsync();

                string client = result.RemoteEndPoint.ToString();
                string message = Encoding.UTF8.GetString(result.Buffer);

                if (!players.ContainsKey(client))
                {
                    playerId++;
                    players[client] = playerId;
                }

                int id = players[client];

                positions[id] = message;

                Console.WriteLine($"Player {id}: {message}");

                foreach (var player in players)
                {
                    if (player.Key == client)
                        continue;

                    string data = id + "|" + message;

                    byte[] bytes = Encoding.UTF8.GetBytes(data);

                    IPEndPoint endPoint = IPEndPoint.Parse(player.Key);

                    await server.SendAsync(bytes, bytes.Length, endPoint);
                }
            }
        }
    }
}