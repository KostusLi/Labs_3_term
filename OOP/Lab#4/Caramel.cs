using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Caramel : Candy
{

    public Caramel(string name, int percent, int weight) : base(name, percent, weight) { }

    public override void recipe()
    {
        Console.WriteLine("А тут рецепт карамельной конфеты");
    }

}
