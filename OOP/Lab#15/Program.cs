using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static async Task Main()
    {
        Stopwatch sw = new Stopwatch();
        Task task = new Task(() => {
            sw.Start();
            Mandelbrot(120, 60);
            sw.Stop();
        });
        Console.WriteLine($"ID задачи: {task.Id}");
        Console.WriteLine($"Статус перед запуском: {task.Status}");
        task.Start();
        if (!task.IsCompleted) {
            Console.WriteLine($"Статус задачи: {task.Status}");
        }
        task.Wait();
        if (task.IsCompleted)
        {
            Console.WriteLine("Поток звершен");
        }
        Console.WriteLine($"Время выполнения: {sw.ElapsedMilliseconds}");

        void Mandelbrot(int x, int y)
        {
            int maxIter = 100;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    double real = (j - x / 2.0) * 4.0 / x;
                    double imag = (i - y / 2.0) * 4.0 / y;
                    Complex c = new Complex(real, imag);
                    Complex z = 0;
                    int iter = 0;
                    while (iter < maxIter && z.Magnitude <= 2.0) {
                        z = z * z + c;
                        iter++;
                    }

                    Console.Write(iter == maxIter ? "#" : " ");
                    //Thread.Sleep(0);
                }
                Console.WriteLine();
            }
        }

        int n = 0;
        Task<int> task1 = new Task<int>(() => { return n + 1; });
        Task<int> task2 = new Task<int>(() => { return n + 3; });
        Task<string> task3 = new Task<string>(() => { return "Сумма чисел: "; });

        Task task4 = task3.ContinueWith(task => { Console.WriteLine($"{task.Result}{task1.Result + task2.Result}"); });
        task1.Start();
        task1.Wait();
        task2.Start();
        task2.Wait();
        task3.Start();
        task3.Wait();

        var task5 = Task.Run(() => 52);
        Console.WriteLine(task5.GetType());
        var awaiter = task5.GetAwaiter();

        awaiter.OnCompleted(() =>
        {
            int result = awaiter.GetResult();
            Console.WriteLine($"Результат: {result}");
        });

        sw = Stopwatch.StartNew();
        Parallel.For(0, 5, GenerateArray);
        sw.Stop();
        Console.WriteLine($"Время выполнения итераций параллельно: {sw.ElapsedMilliseconds}");

        Console.WriteLine("===============================");

        sw = Stopwatch.StartNew();
        for (int i = 0; i < 5; i++)
        {
            GenerateArray(i);
        }
        sw.Stop();
        Console.WriteLine($"Время выполнения итераций обычно: {sw.ElapsedMilliseconds}");

        Console.WriteLine("===============================");

        void GenerateArray(int n) {
            Console.WriteLine($"Сейчас выполняется: {Task.CurrentId}");
            Console.WriteLine($"Итерация {n}");
            int[] arr = new int[1000000];
        }

        List<int> temp = new List<int>() { 1, 3, 5, 8 };

        sw = Stopwatch.StartNew();
        ParallelLoopResult result = Parallel.ForEach<int>(
            temp,
            GenerateArray
        );
        sw.Stop();

        Console.WriteLine($"Время выполнения итераций параллельно: {sw.ElapsedMilliseconds}");
        Console.WriteLine("===============================");

        sw = Stopwatch.StartNew();
        foreach (var g in temp)
        {
            GenerateArray(g);
        }
        sw.Stop();

        Console.WriteLine($"Время выполнения итераций обычно: {sw.ElapsedMilliseconds}");
        Console.WriteLine("===============================");


        Parallel.Invoke(
            () => { Console.WriteLine("1-й делегат"); },
            () => { Console.WriteLine("2-й делегат"); },
            () => { Console.WriteLine("3-й делегат"); },
            () => { Console.WriteLine("4-й делегат"); }
        );

        Console.WriteLine("===============================");

        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        CancellationToken token = cancellationToken.Token;

        Task task6 = new Task(() => {
            int x = 60;
            int y = -40;
            int maxIter = 100;

            if(x<0 || y<0)
            {
                return;
            }

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    double real = (j - x / 2.0) * 4.0 / x;
                    double imag = (i - y / 2.0) * 4.0 / y;
                    Complex c = new Complex(real, imag);
                    Complex z = 0;
                    int iter = 0;
                    while (iter < maxIter && z.Magnitude <= 2.0)
                    {
                        z = z * z + c;
                        iter++;
                    }

                    Console.Write(iter == maxIter ? "#" : " ");
                }
                Console.WriteLine();
            }
        }, token);

        task6.Start();
        cancellationToken.Cancel();
        Console.WriteLine($"Status task6: {task6.Status}");
        cancellationToken.Dispose();

        Console.WriteLine("===============================");


        BlockingCollection<string> sklad = new BlockingCollection<string>();

        Random random = new Random();

        for (int i = 1; i <= 5; i++)
        {
            int supplierId = i;
            Task.Run(() => SupplierWork(supplierId, sklad, random));
        }

        for (int i = 1; i <= 10; i++)
        {
            int customerId = i;
            Task.Run(() => CustomerWork(customerId, sklad));
        }

        Console.ReadLine();

        Console.WriteLine("===============================");

        Console.WriteLine("Начало выполнение асинхронного метода...");
        await IteratorAsync(6);
        Console.WriteLine("Асинхронный метод закончил своё выполнение!\n\nЛабка сделана, ураааа!!!");
    }

    async static Task IteratorAsync(int n)
    {
        for (int i = 0; i < n; i++) {
            await Task.Run(()=>Print(i));
        }
    }

    static void Print(int n)
    {
        Console.WriteLine(n);
    }

    static void SupplierWork(int id, BlockingCollection<string> sklad, Random random)
    {
        for (int i = 1; i <= 5; i++)
        {
            Thread.Sleep(random.Next(500, 2000));

            string product = $"Товар_{id}_{i}";

            sklad.Add(product);

            lock (Console.Out)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Поставщик {id} завёз: {product}");
                Console.ResetColor();

                Console.WriteLine("Состояние склада: " + string.Join(", ", sklad));
                Console.WriteLine(new string('-', 60));
            }
        }

        lock (Console.Out)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Поставщик {id} завершил работу.");
            Console.ResetColor();
        }
    }

    static void CustomerWork(int id, BlockingCollection<string> sklad)
    {
        while (true)
        {
            string item;

            if (sklad.TryTake(out item, TimeSpan.FromMilliseconds(500)))
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Покупатель {id} купил: {item}");
                    Console.ResetColor();
                    Console.WriteLine("Состояние склада: " + string.Join(", ", sklad));
                    Console.WriteLine(new string('-', 60));
                }

                Thread.Sleep(300);
            }
            else
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Покупатель {id} не нашёл товар и ушёл.");
                    Console.ResetColor();
                }

                break;
            }
        }
    }
}