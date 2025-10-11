using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Candy<T> where T : class
{
    public T name;

    public Candy(T name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"Имя конфеты: {this.name}";
    }
}

