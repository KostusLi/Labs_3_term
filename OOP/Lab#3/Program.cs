using System;
using System.Text.RegularExpressions;

namespace Work
{
    public class Matrix
    {
        public int M { get; private set; }
        public int N { get; private set; }
        private int[,] matrix;
        private string str;

        public Matrix(int m, int n, string str)
        {
            this.M = m;
            this.N = n;
            this.str = str;
            matrix = new int[m, n];
        }

        public int this[int i, int j]
        {
            get => matrix[i, j];
            set => matrix[i, j] = value;
        }

        public string Str
        {
            get => str;
            set => str = value;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.M != right.M || left.N != right.N)
            {
                throw new ArgumentException("Матрицы должны быть одинакового размера");
            }

            Matrix result = new Matrix(left.M, left.N, "");

            for (int i = 0; i < left.M; i++)
            {
                for (int j = 0; j < left.N; j++)
                {
                    result[i, j] = left[i, j] + right[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix matrix, int rowToRemove)
        {
            if (rowToRemove < 0 || rowToRemove >= matrix.M)
            {
                throw new ArgumentException("Неверный номер строки");
            }

            Matrix result = new Matrix(matrix.M - 1, matrix.N, matrix.Str);

            for (int i = 0, newRow = 0; i < matrix.M; i++)
            {
                if (i == rowToRemove) continue;

                for (int j = 0; j < matrix.N; j++)
                {
                    result[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
            return result;
        }

        public static bool operator >(Matrix left, Matrix right)
        {
            int sumLeft = 0, sumRight = 0;

            for (int i = 0; i < left.M; i++)
                for (int j = 0; j < left.N; j++)
                    sumLeft += Math.Abs(left[i, j]);

            for (int i = 0; i < right.M; i++)
                for (int j = 0; j < right.N; j++)
                    sumRight += Math.Abs(right[i, j]);

            return sumLeft > sumRight;
        }

        public static bool operator <(Matrix left, Matrix right)
        {
            int sumLeft = 0, sumRight = 0;

            for (int i = 0; i < left.M; i++)
                for (int j = 0; j < left.N; j++)
                    sumLeft += Math.Abs(left[i, j]);

            for (int i = 0; i < right.M; i++)
                for (int j = 0; j < right.N; j++)
                    sumRight += Math.Abs(right[i, j]);

            return sumLeft < sumRight;
        }

        public static Matrix operator ~(Matrix original)
        {
            Matrix copy = new Matrix(original.M, original.N, original.Str);

            for (int i = 0; i < original.M; i++)
                for (int j = 0; j < original.N; j++)
                    copy[i, j] = original[i, j];

            return copy;
        }

        public string DelStr(string substring)
        {
            if (this.str.Contains(substring))
            {
                this.str = this.str.Replace(substring, "");
                return this.str;
            }
            return this.str;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public override string ToString()
        {
            return $"Matrix {M}x{N}, String: {str}";
        }

        public class Production
        {
            public int Id { get; set; }
            public string OrganizationName{ get; set; }

            public Production(int id, string organizationName)
            {
                Id = id;
                OrganizationName = organizationName;
            }

            public override string ToString()
            {
                return $"Кампания: {OrganizationName}, ID: {Id}";
            }
        }

        public class Developer
        {
            public string FIO { get; set; }
            public int Id { get; set; }
            public string OrganizationName { get; set; }

            public Developer(string fIO, int id, string organizationName)
            {
                FIO = fIO;
                Id = id;
                OrganizationName = organizationName;
            }
        }

        
    }

    public static class StatisticOperation
    {
        public static int Sum(Matrix matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.M; i++)
                for (int j = 0; j < matrix.N; j++)
                    sum += matrix[i, j];
            return sum;
        }

        public static int DifferenceMaxMin(Matrix matrix)
        {
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < matrix.M; i++)
                for (int j = 0; j < matrix.N; j++)
                {
                    min = Math.Min(min, matrix[i, j]);
                    max = Math.Max(max, matrix[i, j]);
                }
            return max - min;
        }

        public static int CountElements(Matrix matrix)
        {
            return matrix.M * matrix.N;
        }

        public static int CountWords(this string str)
        {
            return str.Split(' ').Length;
        }

    }

    public static class MatrixExtensions
    {
        public static string FindCarNumber(this Matrix matrix)
        {
            var match = Regex.Match(matrix.Str, @"\d{4}\s[A-Z]{2}-\d");
            return match.Success ? match.Value : "Номер не найден";
        }

        public static int SumMainDiagonal(this Matrix matrix)
        {
            int sum = 0;
            for (int i = 0; i < Math.Min(matrix.M, matrix.N); i++)
                sum += matrix[i, i];
            return sum;
        }
    }

    class Program
    {
        static void Main()
        {
            Matrix m1 = new Matrix(3, 3, "Мой номер 1234 AB-1 и еще текст");
            Matrix m2 = new Matrix(3, 3, "Test matrix");

            Matrix.Production org1 = new Matrix.Production(1, "EPAM");
            Console.WriteLine(org1.ToString() + '\n');
            

            int counter = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m1[i, j] = counter++;
                    m2[i, j] = counter % 5;
                }
            }

            Console.WriteLine("Матрица 1:");
            m1.PrintMatrix();

            Console.WriteLine("Матрица 2:");
            m2.PrintMatrix();


            Console.WriteLine("Сложение матриц:");
            Matrix sum = m1 + m2;
            sum.PrintMatrix();

            Console.WriteLine("\nУдаление строки 1:");
            Matrix withoutRow = m1 - 1;
            withoutRow.PrintMatrix();

            Console.WriteLine("\nСравнение по модулю:");
            Console.WriteLine($"m1 > m2: {m1 > m2}");
            Console.WriteLine($"m1 < m2: {m1 < m2}");

            Console.WriteLine("\nКопирование матрицы:");
            Matrix copy = ~m1;
            copy.PrintMatrix();

            Console.WriteLine("\nПоиск номера машины в m1:");
            Console.WriteLine(m1.FindCarNumber());

            Console.WriteLine("\nСумма главной диагонали m1:");
            Console.WriteLine(m1.SumMainDiagonal());

            Console.WriteLine("\nStatisticOperation:");
            Console.WriteLine($"Сумма элементов m1: {StatisticOperation.Sum(m1)}");
            Console.WriteLine($"Разница max-min в m1: {StatisticOperation.DifferenceMaxMin(m1)}");
            Console.WriteLine($"Количество элементов m1: {StatisticOperation.CountElements(m1)}");

            Console.WriteLine("\nМетод расширения для string:");
            string text = "Это пример строки для подсчета слов";
            Console.WriteLine($"Количество слов: {text.CountWords()}");

        }
    }
}
