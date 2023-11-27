using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MulticastClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread Listener = new Thread(new ThreadStart(Client.Listen));
            Listener.Start();
            Console.ReadLine();
        }
    }
}
