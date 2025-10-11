using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface MyInterface<T>
{
    void add(T obj) { }
    void remove(T obj) { }
    void print(T obj) { }
}
