using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ServerSending;

namespace WindowServer
{
    internal class Subs
    {
        const int Size = 3;
        private int[] ports = new int[] { 4567, 4568, 4569 };
        private Server[] servers = new Server[Size];
        public void StartSub()
        {
            servers = new Server[Size] {
                new Server(ports[0]),
                new Server(ports[1]),
                new Server(ports[2])
            };
            while (true) {
                Thread.Sleep(3000);
                foreach (var item in servers)
                {
                    item.Send("message");
                }
            }
            
        }  
           
    }
}
