using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Printer
{
    public virtual void IAmPrinting(Confectionery obj) {
        Console.WriteLine($"--------------------------------\nType of user object: {obj.GetType()}");
        Console.WriteLine($"Name of user object: {obj.ToString()}\n--------------------------------");
    }
}

