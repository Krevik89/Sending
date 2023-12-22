using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSending;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client(4567);
            Client client2 = new Client(4568);
            Client client3 = new Client(4569);
            
            while (true)
            {
                Console.WriteLine(client1.AcceptAsync() + ": Клиент 1");
                Console.WriteLine(client2.AcceptAsync() + ": Клиент 2");
                Console.WriteLine(client3.AcceptAsync() + ": Клиент 3");

            }
           
        }
    }
}
