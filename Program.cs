using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WindowsSer
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[1000];
            byte[] msg = Encoding.ASCII.GetBytes("From server\n");
            string data = null;

            string ipAddress = "13.78.103.86";
            IPAddress address = IPAddress.Parse(ipAddress);
            Byte[] bytes = address.GetAddressBytes();

            IPAddress ipAddressR = new IPAddress(bytes);

            IPEndPoint localEndpoint = new IPEndPoint(ipAddressR, 8080);

            ConsoleKeyInfo key;
            int count = 0;

            Socket sock = new Socket(ipAddressR.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sock.Bind(localEndpoint);
            sock.Listen(5);

            while (true)
            {
                Console.WriteLine("\nWaiting for clients..{0}", count);
                Socket confd = sock.Accept();

                Console.WriteLine("Comming in 1");

/*                int b = confd.Receive(buffer);
                data += Encoding.ASCII.GetString(buffer, 0, b);

                Console.WriteLine("" + data);
                data = null;

                confd.Send(msg);

                Console.WriteLine("\n<< Continue 'y' , Exit 'e'>>");
                key = Console.ReadKey();
                if (key.KeyChar == 'e')
                {
                    Console.WriteLine("\nExiting..Handled {0} clients", count);
                    confd.Close();
                    System.Threading.Thread.Sleep(5000);
                    break;
                }*/
                confd.Close();
                count++;
            }



        }
    }
}
