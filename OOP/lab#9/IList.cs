using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal interface IList<T>
    {
        void add(T item);

        void clear();

        bool Contains(T item);

        void remove(T item);
        int Count();
    }
}
