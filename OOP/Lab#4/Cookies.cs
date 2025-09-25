using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cookies : Confectionery
{

    public Cookies(string name, int percent, int weight) : base(name, percent, weight) { }

    public override void buyProduct()
    {
        Console.WriteLine($"Купили печенье {Name}");
    }
}