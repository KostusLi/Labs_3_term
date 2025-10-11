using lab_9;
using System;
using System.Security.Cryptography;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> setik = new HashSet<int>() { 1, 2, 5, 12, 67, 18 };
            foreach (var i in setik) {
                Console.WriteLine(i);
            }

            int n = 2;
            foreach (var i in setik) { 
                if(n>0)
                {
                    setik.Remove(i);
                }
                n--;
            }

            Console.WriteLine("===================================");


            foreach (var i in setik)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("===================================");

            setik.Add(342);
            setik.Add(423);

            Dictionary<int, string> dict = new Dictionary<int, string>();

            foreach (var i in setik) {
                dict.Add(i, $"Cost {i}");
            }

            foreach (var i in dict) { 
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("===================================");

            Console.WriteLine(dict.ContainsKey(342));

            Console.WriteLine("===================================");

            ObservableCollection<Plant> queue = new ObservableCollection<Plant>();
            Plant fl1 = new Plant("везде", "одуванчик", 20);
            Plant fl2 = new Plant("везде", "яблоня", 200);
            Plant fl3 = new Plant("везде", "груша", 200);
            queue.Add(fl1);
            queue.Add(fl2);
            queue.Add(fl3);
            queue.Remove();
            Console.WriteLine(queue.retFirstElem());
        }
    }
}