using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;

namespace ServerSending
{
    public class Server
    {     
        private int port;
        private const string ipAddress = "224.5.5.5";
        private Socket socket;

        public Server(int port)
        {
            this.port = port;
        }
        
        public void Send(string Message)
        {
            while (true)
            {
                IPAddress addres = IPAddress.Parse(ipAddress);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 1);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(addres));

                socket.Connect(new IPEndPoint(addres,port));
                socket.Send(Encoding.Unicode.GetBytes(Message));
            }
        }
        
    }
}
