using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MulticastServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread Sender = new Thread(new ThreadStart(Server.MulticastSend));
            Sender.Start();
            Console.ReadLine();
        }
    }
}
