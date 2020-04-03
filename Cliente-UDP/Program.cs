using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(11000);
            try
            {
                udpClient.Connect("127.0.0.1", 11000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Hola...");
            udpClient.Send(sendBytes, sendBytes.Length);

            UdpClient udpClient1 = new UdpClient();
            udpClient1.Send(sendBytes, sendBytes.Length, "127.0.0.1", 11000);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            string returnData = Encoding.ASCII.GetString(receiveBytes);

            Console.WriteLine("Este es el mensaje que recibiste: " + returnData.ToString());
            Console.WriteLine("Este mensaje fue enviado desde: " + RemoteIpEndPoint.Address.ToString()
                + " en su número de puerto: " + RemoteIpEndPoint.Port.ToString());

            udpClient.Close();
            udpClient1.Close();
        }

    }
}
