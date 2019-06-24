using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NpHw_2
{
    class Program
    {
        static int port = 12345;
        static void Main(string[] args)
        {
            using (var context = new StreetContext())
            {
                var dfg = context.Streets.Where(c => c.PostIndex == "1").FirstOrDefault();
            }

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                Socket handler = listenSocket.Accept();
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    string posrIndex = builder.ToString();

                    using (var context = new StreetContext())
                    {
                        if (context.Streets.Where(c => c.PostIndex == posrIndex).FirstOrDefault() == null)
                        {
                            handler.Send(Encoding.Unicode.GetBytes("Улицы не найдены"));
                        }
                        else
                        {
                            string message = "";

                            foreach (var street in context.Streets.Where(c => c.PostIndex ==posrIndex).ToList())
                            {
                                message += street.Name + "\n";
                            }
                            handler.Send(Encoding.Unicode.GetBytes(message));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
