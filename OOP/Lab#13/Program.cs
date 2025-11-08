using System;
using System.Runtime.Serialization;
using System.IO;
using ProtoBuf;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        Candy bo = new Candy("bim", 12, 34);
        CustomSerializer.BinarySerializer(bo);
        Console.WriteLine(CustomSerializer.BinaryDeserializer());
        CustomSerializer.SOAPSerializer(bo);
        Console.WriteLine(CustomSerializer.SOAPDeserializer());
        CustomSerializer.JSONSerializer(bo);
        Console.WriteLine(CustomSerializer.JSONDeserializer());
        CustomSerializer.XMLSerializer(bo);
        Console.WriteLine(CustomSerializer.XMLDeserializer());
        Console.WriteLine("===================================");
        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Loopback, 8080);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);

            byte[] buffer = new byte[1024];
            int bytes = socket.Receive(buffer);

            string json1 = Encoding.UTF8.GetString(buffer, 0, bytes);
            Candy[] candy = JsonSerializer.Deserialize<Candy[]>(json1);

            Console.WriteLine("Получен объект от сервера: ");
            foreach (Candy cand in candy)
            {
                Console.WriteLine(cand);
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("===================================");

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load("Candy1.xml");
        XmlElement? xRoot = xmlDocument.DocumentElement;
        XmlNodeList? nodes = xRoot.SelectNodes("*");
        if (nodes != null)
        {
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node.OuterXml);
            }
        }

        Console.WriteLine("===================================");
        
        XmlNodeList? nodes2 = xRoot.SelectNodes("weight");
        if(nodes2!=null)
        {
            foreach(XmlNode node in nodes2)
            {
                Console.WriteLine(node.OuterXml);
            }
        }

        Console.WriteLine("===================================");
        string json = File.ReadAllText("File.json");
        JObject data = JObject.Parse(json);
        JArray books = (JArray)data["books"];

        var res1 = from p in books where (string)p["id"] == "b3" || (string)p["id"]=="b1" select p;
        foreach(var a in res1)
        {
            Console.WriteLine(a);
        }

        Console.WriteLine("===================================");

        var res2 = from p in books orderby (string)p["id"] descending select p;
        foreach( var a in res2)
        {
            Console.WriteLine(a);
        }
    }
}   