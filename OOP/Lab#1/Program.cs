using System;
using System.Numerics;
using System.Text;

namespace firstStep
{
    class Program
    {
        static void Main()
        {
            //111111111111

            //
            //bool check = Convert.ToBoolean(int.Parse((Console.ReadLine())));
            //byte a = Convert.ToByte(Console.ReadLine());
            //char c = Convert.ToChar(Console.ReadLine());
            //double e = Convert.ToDouble(Console.ReadLine());
            //float f = float.Parse(Console.ReadLine());
            //int g = int.Parse(Console.ReadLine());
            //long k = long.Parse(Console.ReadLine());
            //short m = short.Parse(Console.ReadLine());  
            //sbyte n = sbyte.Parse(Console.ReadLine());
            //ushort o = ushort.Parse(Console.ReadLine());
            //uint p = uint.Parse(Console.ReadLine());
            //ulong q = ulong.Parse(Console.ReadLine());
            //decimal d = decimal.Parse(Console.ReadLine());
            //string b = Console.ReadLine();
            //object r = Console.ReadLine();
            //nint s1 = nint.Parse(Console.ReadLine());
            //nuint t1 = nuint.Parse(Console.ReadLine());

            //Console.WriteLine(check.ToString() + " " + a + " " + c + " " + e + " " + f + " " + g + " " + k + " " + m + " " + n + " " + o + " " + p + " " + q + " " + d + " " + b + " " + r + " " + t1 + " " + s1);


            Console.WriteLine("===============================================================");

            //
            int a1 = 4;
            long a2 = a1;

            uint b1 = 6;
            long b2 = b1;

            long c1 = 6L;
            decimal c2 = c1;

            float d1 = 4;
            double d2 = d1;

            long g1 = 6L;
            float g2 = g1;



            //

            a1 = (int)d1;

            short k1 = 4;
            byte m1 = (byte)k1;

            d1 = (long)m1;

            a1 = Convert.ToInt32(d2);

            decimal с2 = (decimal)Convert.ChangeType(b2, typeof(decimal));

            Console.WriteLine(c2 + " " + d1);



            int x = 5;
            Object y = x;
            short x1 = (short)(int)y;

            Console.WriteLine(x1);




            //
            var s = 5;
            Console.WriteLine(s.GetType());


            Console.WriteLine("===============================================================");

            //
            Nullable<int> t = 5;
            Console.WriteLine(t.HasValue);
            Console.WriteLine(t.GetValueOrDefault());
            Console.WriteLine(t.Value);
            t = null;
            Console.WriteLine(t.GetValueOrDefault(0));


            //
            var u = 6;
            /*u = "Привет";*/ //тип должен быть введен только 1 раз при выполнении


            Console.WriteLine("===============================================================");


            //2222222222222

            //
            string v = new string("Hello, brothers!");
            string v1 = "Hello,brothers!";
            string v2 = "bdihbg";

            Console.WriteLine(string.Equals(v, v1));
            Console.WriteLine(Convert.ToBoolean(string.Compare(v1, v)));

            String result = v + v2;
            Console.WriteLine(result);
            Console.WriteLine(string.Concat(v, " ", v2));

            Console.WriteLine(v.Substring(0, 5));
            string[] words = v.Split('e');
            Console.WriteLine(string.Join("    |||     ", words));


            Console.WriteLine(v2.Insert(3, " + " + v + " + "));

            Console.WriteLine(v1.Remove(5, 5));

            String interpolation = $"Значение переменной v - {v}, а переменной v2 - {v2}.";
            Console.WriteLine(interpolation);
            String interpolation2 = string.Format("Значение переменной v - {0}, а переменной v2 - {1}.", v, v2);
            Console.WriteLine(interpolation2);

            Console.WriteLine("===============================================================");

            //
            string v3 = "";
            string v4 = null;

            Console.WriteLine(string.IsNullOrEmpty(v3));
            Console.WriteLine(string.IsNullOrEmpty(v4));
            Console.WriteLine(v3 + "kjlfsnsv");
            Console.WriteLine(v4 + "dgfv");
            Console.WriteLine(v3.Length);
            v3 += "  ";
            Console.WriteLine(string.IsNullOrWhiteSpace(v3));

            Console.WriteLine("===============================================================");


            //
            StringBuilder v5 = new StringBuilder("don't forget about");
            Console.WriteLine(v5);
            v5.Append(" me");
            v5.Insert(0, "Please, don't");
            v5.Remove(8, 5);
            Console.WriteLine(v5.ToString());


            Console.WriteLine("===============================================================");

            //333333333333333333

            //

            int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };

            int rows = arr.GetLength(1);
            Console.WriteLine(rows);
            int cols = arr.Length / rows;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("===============================================================");


            //
            int[] arr2 = new int[] { 3, 12, 45, 67 };
            Console.WriteLine(arr2.Length);
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();

            arr2[2] = 100;
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("===============================================================");


            //
            int[][] arr3 = {
                new int [2],
                new int [3],
                new int [4]
            };

            //for(int i=0; i<arr3.Length; i++)
            //{
            //    for(int j=0; j<arr3[i].Length; j++)
            //    {
            //        arr3[i][j] = int.Parse(Console.ReadLine());
            //    }
            //}

            for (int i = 0; i < arr3.Length; i++)
            {
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    Console.Write(arr3[i][j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("===============================================================");


            //
            var arr4 = new int[] { 1, 2, 3, 4, 5, 6 };
            var str = "don't forget";


            //44444444444444444444

            //
            (int, string, char, string, ulong) turple = (3, "hell", 'a', "heaven", 5);
            Console.WriteLine(turple);
            Console.WriteLine(turple.Item1 + " + " + turple.Item3 + " + " + turple.Item5);

            int per1 = turple.Item1;
            String per2 = turple.Item2 + turple.Item4;

            int per3;
            string per4;
            char per5;
            string per6;
            ulong per7;
            (per3, per4, per5, per6, per7) = turple;

            var (per8, _, per9, _, per10) = turple;
            Console.WriteLine($"{per8}, {per9}, {per10}");

            (int, string, char, string, ulong) turple1 = (3, "hell", 'a', "heaven", 5);
            Console.WriteLine($"turple==turple1: {turple==turple1}");


            //555555555555555555555

            //
            (int, int, int, char) minMax(string str, int[] a)
            {
                int min = 1000;
                int max = 0;
                int sum = 0;

                foreach(int i in a) {
                    if(i<min)
                    {
                        min = i;
                    }
                    if (i > max)
                    {
                        max = i;
                    }
                    sum += i;
                }

                char ch = str[0];
                (int, int, int, char) res = (max, min, sum, ch);
                return res;
                
            }

            Console.WriteLine($"{minMax(per4, arr4)}");


            //
            void fChecked()
            {
                try
                {
                    checked
                    {
                        int a = int.MaxValue;
                        a += 2;
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void fUnchecked()
            {
                unchecked
                {
                    int a = int.MaxValue;
                    a+= 2;
                    Console.WriteLine(a);
                }
            }

            fChecked();
            fUnchecked();

        }
    }
}