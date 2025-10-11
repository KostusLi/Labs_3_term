using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

internal class Programm
{
    static void Main(string[] args)
    {
        StringWorking text = new StringWorking("        djbndo, dvfkdf;vndfvdifv:::!!jf         ");
        text.DeletePoints(text.Operation1, text.Operation2);

        text.DeleteWhiteSpaces();
        Console.WriteLine(text.stroke);

        text.AddText("Crossing the Rubicon", text.Operation3);
        Console.WriteLine(text.stroke);

        Console.WriteLine(text.ReplacingInString("WWcallingWW", "g", text.Operation4));


        User u1 = new User(10, 20);
        User u2 = new User(5, 5);
        User u3 = new User(100, 50);

        u1.Notify1 += (msg) => Console.WriteLine("U1: " + msg);

        u2.Notify1 += (msg) => Console.WriteLine("U2: " + msg);
        u2.Notify2 += (msg) => Console.WriteLine("U2: " + msg);

        Console.WriteLine("\n=== События ===");
        u1.Moving(3, 2);
        u2.Moving(-1, 5);
        u2.Pressing(2.0);
        u3.Pressing(2.0);

        Console.WriteLine("\n=== Состояния объектов ===");
        u1.PrintState();
        u2.PrintState();
        u3.PrintState();
    }

}