using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDCEchoClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            string message = Console.ReadLine();

            //Initializes a Socket we can use to send packets
            UdpClient socket = new UdpClient();

            //converts the message using the UTF8 encoding to a byte array
            //It's important to use the same enconding on both server and client
            byte[] data = Encoding.UTF8.GetBytes(message);
            //Sends the converted message to the specified address
            socket.Send(data, data.Length, "10.200.177.108", 65000);

            //This is used to store the endpoint that replies to our packet
            IPEndPoint from = null;
            //receives data from the client, waits here until the client replies
            byte[] received = socket.Receive(ref from);
            //converts the reply back into a string using the same encoding
            string receivedString = Encoding.UTF8.GetString(received);
            Console.WriteLine(receivedString + " - " + from.Address);
        }
    }
}
