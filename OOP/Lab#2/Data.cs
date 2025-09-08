using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Data
{
    private int day { get; set; }
    private int month { get; set; }
    private int year { get; }
    public int number = 0;
    private readonly Guid ID;
    static private string[] arrOfStr;
    const int pref = 0;

    private static int count = 0;

    private Boolean validateDay(int month)
    {
        int[] arrMonth = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        int low = 0, middle;
        int high = arrMonth.Length-1;
        while (low <= high)
        {
            middle = (low + high) / 2;
            if (month < arrMonth[middle])
                high = middle - 1;
            else if(month > arrMonth[middle]) 
                low = middle+1;
            else
            {
                if ((middle < 7 && middle%2==0) || (middle>=7 && middle%2!=0))
                {
                    return true;
                }
                break;
            }
        }
        return false;

    }
    

    public Data(int day, int month, int year)
    {
        if(month<=12 && month>=1)
        {
            this.month = month;
        }
        else
        {
            this.month = month%12;
        }
            this.year = year;
        if(validateDay(month))
        {
            if(day>=1 && day<=31)
            {
                this.day = day;
            }
            else this.day = day%31;
        }
        else if(month==2)
        {
            if(year%4==0)
            {
                if(day>=1 && day<=29)
                {
                    this.day=day;
                }
                else this.day = day%29;
            }
            else
            {
                if(day>=1 && day<=28)
                {
                    this.day=day;
                }
                else this.day=day%28;
            }
        }
        else
        {
            if(day>=1 && day<=30)
            {
                this.day=day;
            }else this.day = day%30;
        }
            ID = calculateHash();
        count++;
    }


    public Data()
    {
        this.day = 0;
        this.month = 0;
        this.year = 0;
        ID = calculateHash();
        count++;
    }

    public Data(int day = 3, int month = 5)
    {
        this.day = day;
        this.month = month;
        this.year = 0;
        ID = calculateHash();
        count++;
    }

    static Data()
    {
        arrOfStr = new string[] { "05/01/2007", "12/11/2023", "23/04/2007" };
    }

    private Data(int day)
    {
        this.day = day;
        ID = calculateHash();
        count++;
    }

    public Guid calculateHash()
    {
        string key = $"{day}{month}{year}";
        var md5 = System.Security.Cryptography.MD5.Create();
        var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
        return new Guid(hash);
    }

    public static void printInfo()
    {
        Console.WriteLine(count);
        foreach (string i in arrOfStr)
        {
            Console.WriteLine(i);
        }
    }

    private string longPrint(out string result,ref int number)
    {
        string[] listMonth = { "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" };
        result = $"{day} {listMonth[month - 1]} {year} года";
        number++;
        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Data other = (Data)obj;

        return day == other.day &&
            month == other.month &&
            year == other.year;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + day.GetHashCode();
            hash = hash * 23 + month.GetHashCode();
            hash = hash * 23 + year.GetHashCode();
            return hash;
        }
    }


    public override string ToString()
    {
        string daystr = (day > 10 ? day.ToString() : "0" + day);
        string monthstr = (month > 10 ? month.ToString() : "0" + month);
        return $"{daystr}/{monthstr}/{year}";
    }

    public partial class Person
    {
        public void Move() => Console.WriteLine("Человек идёт");

    }

    public partial class Person
    {
        public void Eat() => Console.WriteLine("Человек ест");
    }


    static void Main(String[] args)
    {
        Data c = new Data(50, 4, 3055);
        Console.WriteLine(c.number);
        Console.WriteLine(c);
        Console.WriteLine(c.longPrint(out string result,ref c.number));
        Console.WriteLine(c.number);

        Console.WriteLine("==============================================");

        Data d = new Data();
        Console.WriteLine(d);

        Console.WriteLine("==============================================");

        Data e = new Data(6);
        Console.WriteLine(e);

        Console.WriteLine("==============================================");

        Data.printInfo();

        Console.WriteLine("==============================================");

        Person p = new Person();
        p.Move(); 
        p.Eat();

        Console.WriteLine("==============================================");

        Console.WriteLine(c.Equals(d));

        Console.WriteLine("==============================================");

        Console.WriteLine(c.GetHashCode());

        Console.WriteLine("==============================================");

        Console.WriteLine(typeof (Data));

        Console.WriteLine("==============================================");

        var temp = new
        {
            day = 2,
            month = 5,
            year = 2022
        };

        Console.WriteLine(temp);


    }
}
