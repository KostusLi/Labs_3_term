using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface Serializer
{
    public static void BinarySerializer(Candy candy) { }
    public static Candy BinaryDeserializer() { return null; }
    public static void SOAPSerializer(Candy candy) { }
    public static Candy SOAPDeserializer() { return null; }
    public static void JSONSerializer(Candy candy) { }
    public static Candy JSONDeserializer() { return null; }
    public static void XMLSerializer(Candy candy) { }
    public static Candy XMLDeserializer() { return null; }
}