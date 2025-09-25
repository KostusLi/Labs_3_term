using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Candy : Confectionery, IEdible
{
    public virtual void recipe() {
        Console.WriteLine("Рецепт какой-то конфеты");
    }

    public Candy(string name, int percent, int weight) : base(name, percent, weight){ }

    void IEdible.eat()
    {
        Console.WriteLine("Конфету съели(((");
    }


    public override void buyProduct()
    {
        Console.WriteLine("Купили конфету");
    }

}
