using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal class Control<T> : IList<T>
    {
        public List<T> values {get;set;}

        public Control() {
            this.values = new List<T>();
        }

        public void add(T item) 
        { 
            this.values.Add(item);
        }

        public bool Contains(T item) {
            return this.values.Contains(item);
        }

        public void clear()
        {
            this.values.Clear();
        }

        public void remove(T item) {
            if (this.values.Contains(item)) { 
                this.values.Remove(item);
            }
        }

        public int Count()
        {
            return this.values.Count;
        }



    }
}
