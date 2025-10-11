using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal interface IMyInterface<T>
{
    void Add(T item);
    void Remove(T item);
    void Print();
}