using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MulticastClient
{
    internal class Client
    {
        static void OnMsgReceive(string msg)
        {
            Console.WriteLine($"> Received message: {msg}");
        }
        public static void Listen()
        {
            while (true)
            {
                // сокет клиента
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);
                // эндпоинт клиента
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 4567);

                client.Bind(ipep);
                IPAddress ip = IPAddress.Parse("224.5.5.5");
               
                client.SetSocketOption(SocketOptionLevel.IP,
                    SocketOptionName.AddMembership,
                    new MulticastOption(ip, IPAddress.Any));
                
                // чтенние сообщения
                byte[] buff = new byte[1024];
                client.Receive(buff);
                OnMsgReceive(Encoding.Default.GetString(buff));
                client.Close();
            }
        }
    }
}
