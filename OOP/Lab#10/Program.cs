using System;
using System.Security.Cryptography.X509Certificates;

class Programm
{

    static void Main(string[] args)
    {

        bool checkDate(string left, string right, Data p)
        {
            int day1 = Convert.ToInt32(left.Substring(0, 2));
            int month1 = Convert.ToInt32(left.Substring(3, 2));
            int year1 = Convert.ToInt32(left.Substring(6));

            int day2 = Convert.ToInt32(right.Substring(0, 2));
            int month2 = Convert.ToInt32(right.Substring(3, 2));
            int year2 = Convert.ToInt32(right.Substring(6));

            if (p.year == year1 || p.year == year2)
            {
                if (p.month == month1 || p.month == month2)
                {
                    if (p.day >= day1 || p.day <= day2)
                    {
                        return true;
                    }
                }
                else if (p.month > month1 && p.month < month2)
                {
                    return true;
                }
            }
            else if (p.year > year1 && p.year < year2)
            {
                return true;
            }

            return false;
        }


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

        List<Data> listik = new List<Data>() { new Data(12, 34, 2015), 
            new Data(14, 12, 2034), 
            new Data(5, 2, 2012), 
            new Data(15, 7, 1343), 
            new Data(7, 1, 2034), 
            new Data(12, 2, 2004), 
            new Data(6, 4, 2012), 
            new Data(10, 6, 2007), 
            new Data(23, 7, 2006), 
            new Data(17, 10, 2016), 
        };

        foreach (Data data in listik) { 
            Console.WriteLine(data);
        }

        Console.WriteLine("==================================");


        int year = 2034;

        var dates = from p in listik where p.year == year select p;

        Console.WriteLine($"Даты с годом {year}:");
        foreach (Data data in dates) {
            Console.WriteLine(data);
        }

        Console.WriteLine("==================================");

        int month = 2;

        var date_m = listik.Where(m=> m.month == month);
        Console.WriteLine($"Даты с месяцом {month}:");
        foreach (Data data in date_m) {
            Console.WriteLine(data);
        }

        Console.WriteLine("==================================");

        string left = "01/03/2012";
        string right = "03/04/2034";

        int date_count = (from p in listik where checkDate(left, right, p) select p).Count();

        Console.WriteLine($"Кол-во дат, которые входят в диапазон от {left} до {right}");
        Console.WriteLine(date_count);

        Console.WriteLine("==================================");

        var maxDate = listik.Select(p => p.ToDateTime()).Max();
        Console.WriteLine(maxDate);

        Console.WriteLine("==================================");

        int day = 15;
        var firstDate = listik.FirstOrDefault(p=>p.day == day);
        Console.WriteLine(firstDate);

        Console.WriteLine("==================================");

        var ordered = listik.OrderBy(p => p.year).ThenBy(p => p.month).ThenBy(p => p.day);

        Console.WriteLine("День: \tМесяц: \tГод: ");
        foreach (Data data in ordered) {
            Console.WriteLine($" {data.day} \t {data.month}\t{data.year}");
        }

        Console.WriteLine("==================================");

        var query =
        from d in listik
        where d.year > 2010            
        group d by d.year into g        
        orderby g.Key                      
        select new                          
        {
            Year = g.Key,
            Count = g.Count(), 
            AvgMonth = g.Average(x => x.month),
            HasSummer = g.Any(x => x.month >= 6 && x.month <= 8),
            FirstTwo = g.OrderBy(x => x.month).Take(2).ToList()
        };

        foreach (var item in query)
        {
            Console.WriteLine($"Год: {item.Year}");
            Console.WriteLine($"  Кол-во дат: {item.Count}");
            Console.WriteLine($"  Средний месяц: {item.AvgMonth:F1}");
            Console.WriteLine($"  Есть летние даты: {(item.HasSummer ? "Да" : "Нет")}");
            Console.WriteLine("  Первые две даты в году:");
            foreach (var d in item.FirstTwo)
                Console.WriteLine($"    {d}");
            Console.WriteLine();
        }

        List<int> days = new List<int>() {2, 3, 4, 1, 5, 7, 2};

        var joinCollection = listik.Join(days, p => p.day, c => c, (p, c) => new { ID = c, DateString = p.ToDateTime() });

        foreach (var item in joinCollection) {
            Console.WriteLine($"{item.ID}: {item.DateString}");
        }

    }
}