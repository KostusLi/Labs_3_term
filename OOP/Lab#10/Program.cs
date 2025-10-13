using System;
using System.Security.Cryptography.X509Certificates;

class Programm
{
    static void Main(string[] args)
    {

        bool summerOrWinter(string p)
        {
            string[] months = { "June", "July", "August", "December", "January", "February" };
            foreach (string e in months)
            {
                if (e == p)
                {
                    return true;
                }
            }
            return false;
        }

        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        //1
        int len = 4;
        var ex10 = from p in months where p.Length == len select p;

        foreach (string e in ex10)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("==================================");

        var ex11 = from p in months where summerOrWinter(p) select p; 
        
        foreach (string e in ex11)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("==================================");


    }
}