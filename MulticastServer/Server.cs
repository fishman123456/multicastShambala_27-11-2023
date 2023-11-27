using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MulticastServer
{
    internal class Server
    {
        // отправляемое сообщение
        static string message = "Hello network!!!";
        // интервал обновления данных
        static int Interval = 1000;
        public static void MulticastSend()
        {
            while (true)
            {
                // выдерживаем интервал
                Thread.Sleep(Interval);

                // сокет сервера
                Socket server = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram,
                    ProtocolType.Udp);

                // ставим опции мультикастинга
                server.SetSocketOption(SocketOptionLevel.IP,SocketOptionName.MulticastTimeToLive,2);

                // мультикаст адрес назначения
                IPAddress dest = IPAddress.Parse("224.5.5.5");
                server.SetSocketOption(SocketOptionLevel.IP, 
                    SocketOptionName.AddMembership,
                    new MulticastOption(dest));

                // сокет отправки
                IPEndPoint ipep = new IPEndPoint(dest, 4567);
                
                // подключаемся -> отправляем -> закрываем
                server.Connect(ipep);
                server.Send(Encoding.Default.GetBytes(message));
                Console.WriteLine($"Messages {message} send");
                server.Close();

                message = DateTime.Now.ToString();
            }
        }
    }
}
