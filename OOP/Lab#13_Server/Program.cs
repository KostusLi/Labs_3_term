using System;
using System.Runtime.Serialization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Loopback, 8080);
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        listener.Bind(ipPoint);
        listener.Listen(1);
        Console.WriteLine("Серве запущен. Ожидание подключения...");

        Socket handler = listener.Accept();
        Console.WriteLine("Клиент подключен!");

        Candy candy = new Candy("Snickers", 12, 55);
        Candy candy1 = new Candy("BIMBOM", 13, 24);
        Candy candy2 = new Candy("Henri", 45, 31);
        Candy[] arr = { candy, candy1, candy2 };
        string json = JsonSerializer.Serialize(arr);
        byte[] data = Encoding.UTF8.GetBytes(json);

        handler.Send(data);
        Console.WriteLine("Объект отправлен клиенту!");

        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
        listener.Close();
    }
}