using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal class ObservableCollection<T> where T : class
    {
        delegate void CollectionChange(string message);
        event CollectionChange CheckElem;
        event CollectionChange CheckElem2;

        Queue<T> queue;

        public ObservableCollection()
        {
            CheckElem += DefaultEventHandler;
            CheckElem2 += DefaultEventHandler;
            CheckElem2?.Invoke("Вызван конструктор класса ObservableCollection");
            this.queue = new Queue<T>();
        }

        public void Add(T item) 
        {
            this.CheckElem.Invoke("Вызван метод Add по добавлению элементов в очередь");

            this.queue.Enqueue(item);
        }

        public void Remove()
        {
            this.CheckElem2.Invoke("Вызван метод Remove для удаления элемента");
            this.queue.Dequeue();
        }

        public T retFirstElem()
        {
            this.CheckElem2.Invoke("Вызван метод retFirstElem для получения первого элемента");
            return this.queue.Peek();
        }

        private void DefaultEventHandler(string messsage)
        {
            Console.WriteLine(messsage);
        }

    }
}
