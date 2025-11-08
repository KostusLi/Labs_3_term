using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class CustomSerializer : Serializer
{
    public static void BinarySerializer(Candy candy) {
        try
        {
            using (var file = File.Create("Candy.bin"))
            {
                ProtoBuf.Serializer.Serialize(file, candy);
            }
            Console.WriteLine("Сериализация в бинарный формат выполена успешно!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static Candy BinaryDeserializer() {
        try
        {
            using (var read = File.OpenRead(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#13\bin\Debug\net8.0\Candy.bin"))
            {
                Candy res = ProtoBuf.Serializer.Deserialize<Candy>(read);
                return res;
            }
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static void SOAPSerializer(Candy candy) {
        try
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Candy));
            using (FileStream file = new FileStream("Candy.xml", FileMode.Create))
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(file))
                {
                    serializer.WriteObject(writer, candy);
                }
            }
            Console.WriteLine("Сериализация в SOAP выполена успешно!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static Candy SOAPDeserializer() {
        try
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Candy));
            using (FileStream file = new FileStream("Candy.xml", FileMode.Open))
            {
                using(XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(file, new XmlDictionaryReaderQuotas()))
                {
                    Candy res = (Candy)serializer.ReadObject(reader);
                    return res;
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static void JSONSerializer(Candy candy) {
        try
        {
            using(FileStream file = new FileStream("Candy.json", FileMode.Create))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                JsonSerializer.Serialize(file, candy, options);
            }
            Console.WriteLine("Сериализация в JSON выполена успешно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static Candy JSONDeserializer() {
        try
        {
            using(FileStream file = new FileStream("Candy.json", FileMode.Open))
            {
                Candy res = JsonSerializer.Deserialize<Candy>(file);
                return res;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static void XMLSerializer(Candy candy) {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Candy));
            using(FileStream file = new FileStream("Candy1.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(file, candy);
            }
            Console.WriteLine("Сериализация в XML выполена успешно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static Candy XMLDeserializer() {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Candy));
            using (FileStream file = new FileStream("Candy1.xml", FileMode.Open))
            {
                return (Candy)xmlSerializer.Deserialize(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }
}
