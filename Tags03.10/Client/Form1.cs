using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        int speed = 10;

        UdpClient udpClient = new UdpClient();

        IPEndPoint server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            udpClient.Connect(server);

            _ = ReceiveData();
        }

        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && player.Top > 0)
            {
                player.Top -= speed;
            }

            if (e.KeyCode == Keys.S && player.Bottom < ClientSize.Height)
            {
                player.Top += speed;
            }

            if (e.KeyCode == Keys.A && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (e.KeyCode == Keys.D && player.Right < ClientSize.Width)
            {
                player.Left += speed;
            }

            await SendPosition();
            CheckWinner();
        }

        private async Task SendPosition()
        {
            string message = $"{player.Left};{player.Top}";

            byte[] data = Encoding.UTF8.GetBytes(message);

            await udpClient.SendAsync(data, data.Length);
        }

        private async Task ReceiveData()
        {
            while (true)
            {
                UdpReceiveResult result = await udpClient.ReceiveAsync();

                string message = Encoding.UTF8.GetString(result.Buffer);

                string[] parts = message.Split('|');

                if (parts.Length != 2) continue;

                string[] position = parts[1].Split(';');

                int x = Convert.ToInt32(position[0]);

                int y = Convert.ToInt32(position[1]);

                Invoke(() =>
                {
                    player2.Left = x;
                    player2.Top = y;
                    player2.BringToFront();
                });
            }
        }
        private void CheckWinner()
        {
            if (player.Bounds.IntersectsWith(player2.Bounds))
            {
                MessageBox.Show("You won!");
            }
        }
    }
}