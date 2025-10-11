using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        CollectionType<Matrix> matrices = new CollectionType<Matrix>();

        Matrix A = new Matrix(2, 2, "A");
        A[0, 0] = 1; A[0, 1] = 2;
        A[1, 0] = 3; A[1, 1] = 4;

        Matrix B = new Matrix(3, 3, "B");

        matrices.Add(A);
        matrices.Add(B);

        matrices.Print();

        //matrices.Remove(A);
        matrices.Print();

        Matrix found = matrices.Find(m => m.M == 3);
        Console.WriteLine($"Найдена матрица: {found}");

        Candy<string> choc = new Candy<string>("chokolapka");
        Console.WriteLine(choc.ToString());

        string path = @"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#7\file.json";

        matrices.writeToJson(path);
        matrices.readFromJson(path);
        matrices.Print();
    }
}