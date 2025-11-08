using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        foreach(Process p in Process.GetProcesses())
        {
            try
            {
                Console.WriteLine($"ID: {p.Id}");
                Console.WriteLine($"Name: {p.ProcessName}");
                Console.WriteLine($"Priority: {p.BasePriority}");
                Console.WriteLine($"Time of launch: {p.StartTime}");
                Console.WriteLine($"Using CPU: {p.TotalProcessorTime}");
                Console.WriteLine($"Response or not: {p.Responding}");
                Console.WriteLine("====================================");
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
                Console.WriteLine("====================================");
            }
        }

        AppDomain domain = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {domain.FriendlyName}");
        Console.WriteLine($"Details of configuration: {domain.SetupInformation}");
        Console.WriteLine($"Assemblies: ");
        foreach (Assembly p in domain.GetAssemblies()) {
            Console.WriteLine(p);
        }

        Console.WriteLine("====================================");

        NewDomain();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        foreach (Assembly p in AppDomain.CurrentDomain.GetAssemblies())
        {
            Console.WriteLine(p.GetName().Name);
        }

        void NewDomain()
        {
            AssemblyLoadContext newDom = new AssemblyLoadContext(name: "Dom", isCollectible: true);
            newDom.Unloading += Context_Unloading;
            Assembly assem = newDom.LoadFromAssemblyPath(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#13\bin\Debug\net8.0\Lab#4.dll");

            foreach (Assembly p in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(p.GetName().Name);
            }

            Console.WriteLine("====================================");
            newDom.Unload();
        }

        void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("Библиотека Lab#4 выгружена");
        }


        Console.WriteLine("Введите чило n: ");
        int n;
        n = int.Parse(Console.ReadLine());
        Thread prime = new Thread(() => PrimeNumber(n))
        {
            Name = "Prime",
            Priority = ThreadPriority.Normal
        };

        prime.Start();

        while (prime.IsAlive) {
            Console.WriteLine($"ID: {prime.ManagedThreadId}");
            Console.WriteLine($"Статус: {prime.ThreadState}");
            Console.WriteLine($"Приоритет: {prime.Priority}");
            Thread.Sleep(500);
        }

        Console.WriteLine("Поток prime завершен");

        void PrimeNumber(int n)
        {
            using StreamWriter sw = new StreamWriter("primes.txt");
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    sw.WriteLine(i);
                    Thread.Sleep(100);
                }
            }
        }

        bool IsPrime(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }

        Console.WriteLine("====================================");

        Console.WriteLine("Введите число n: ");
        n = int.Parse(Console.ReadLine());

        AutoResetEvent eventEven = new AutoResetEvent(true);
        AutoResetEvent eventOdd = new AutoResetEvent(false);
        object locker = new();

        using (StreamWriter sf = new StreamWriter("potok#4.txt", append: true))
        {
            Thread even = new Thread(() => PrintEven(n, sf)) { Name = "even", Priority = ThreadPriority.Highest };
            Thread odd = new Thread(() => PrintOdd(n, sf)) { Name = "odd" };

            Console.WriteLine("1 - выводятся сначала четные, 2 - поочередно четное/нечетное: ");
            int k = 0;
            while (k != 1 && k != 2)
            {
                k = int.Parse(Console.ReadLine());
            }

            switch (k)
            {
                case 1:
                    Thread evenOnly = new Thread(() =>
                    {
                        lock (locker)
                        {
                            for (int i = 0; i <= n; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    Console.WriteLine($"Even: {i}");
                                    sf.WriteLine($"Even thread(case 1): {i}");
                                    sf.Flush();
                                    Thread.Sleep(100);
                                }
                            }
                        }
                    });

                    Thread oddOnly = new Thread(() =>
                    {
                        lock (locker)
                        {
                            for (int i = 0; i <= n; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    Console.WriteLine($"Odd: {i}");
                                    sf.WriteLine($"Odd thread(case 1): {i}");
                                    sf.Flush();
                                    Thread.Sleep(100);
                                }
                            }
                        }
                    });

                    evenOnly.Start();
                    evenOnly.Join();
                    oddOnly.Start();
                    oddOnly.Join();
                    Console.WriteLine("Потоки oddOnly и evenOnly завершены");
                    break;

                case 2:
                    even.Start();
                    odd.Start();
                    even.Join();
                    odd.Join();
                    Console.WriteLine("Потоки odd и even завершены");
                    break;
            }

            void PrintEven(int num, StreamWriter writer)
            {
                for (int i = 0; i <= num; i++)
                {
                    if (i % 2 == 0)
                    {
                        eventEven.WaitOne();
                        lock (locker)
                        {
                            Console.WriteLine($"Even: {i}");
                            writer.WriteLine($"Even thread: {i}");
                            writer.Flush();
                        }
                        Thread.Sleep(100);
                        eventOdd.Set();
                    }
                }
            }

            void PrintOdd(int num, StreamWriter writer)
            {
                for (int i = 0; i <= num; i++)
                {
                    if (i % 2 != 0)
                    {
                        eventOdd.WaitOne();
                        lock (locker)
                        {
                            Console.WriteLine($"Odd: {i}");
                            writer.WriteLine($"Odd thread: {i}");
                            writer.Flush();
                        }
                        Thread.Sleep(250);
                        eventEven.Set();
                    }
                }
            }
        }

        Timer timer = new Timer(PrintG, null, 0, 2000);
        Console.ReadLine();
    }

    static int g = 0;

    static void PrintG(object obj)
    {
        Console.WriteLine($"Вывод через 2 секунды: {g++}");
    }
}