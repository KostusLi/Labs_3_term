using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class BoxOfCandy<T>
{
    public List<T> list = new List<T>();



    public void add(T item)
    {
        list.Add(item);
    }

    public void remove(T item)
    {
        list.Remove(item);
    }

    public T get(int index)
    {
        return list[index];
    }

    public void AppDomainSetup(int index, T value)
    {
        list[index] = value;
    }

    public void printList()
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

}
