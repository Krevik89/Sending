using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientSending
{
    public class Client
    {   
        private int port;
        private const string ipAddress = "224.5.5.5";
        private Socket socket;

        public Client(int port)
        {
            this.port = port;
        }

        public Task<string> AcceptAsync()
        {
            return Task<string>.Run(() =>
            {
                IPAddress ad = IPAddress.Parse(ipAddress);
                
                IPEndPoint iPEnd = new IPEndPoint(IPAddress.Any, port);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Bind(iPEnd);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ad, IPAddress.Any));

                byte[] bytes = new byte[256];
                socket.Receive(bytes);
                socket.Close();
                return Encoding.Unicode.GetString(bytes);
            });

        }     
    }
}
