using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {
        Candy sweet1 = new Candy("bimbom", 23, 45);
        ChocolateCandy sweet2 = new ChocolateCandy("air", 43, 12);
        Caramel sweet3 = new Caramel("maria", 12, 23);
        Candy sweet4 = new Candy("farsyrtgdfcsfd", 34, 15);

        List<Candy> list= new List<Candy>() { sweet1, sweet2, sweet3};

        BoxOfCandy<Candy> box = new BoxOfCandy<Candy>();
        box.add(sweet1);
        box.add(sweet2);
        box.add(sweet3);
        Controller contr = new Controller(box);
        Cookies cook = new Cookies("gracio", 5, 34);


        try
        {
            int g = 0;
            int te = 4 / g;
            Console.WriteLine(te);
        }
        catch(Exception ex) when (ex.Message!=null)
        {
            FileLogger.logMessageFile(ex.Message + '/' + ex.StackTrace);
            ConsoleLogger.logMessageConsole(ex.Message + '/' + ex.StackTrace);
            try
            {
                throw new DivideByZeroException("\n\n------Hello??------\n\n", ex);
            }
            catch (DivideByZeroException ex1)
            {
                FileLogger.logMessageFile(ex1.Message + '/' + ex1.StackTrace);
                ConsoleLogger.logMessageConsole(ex1.Message + '/' + ex1.StackTrace);
            }
        }
        finally
        {
            Console.WriteLine("Делить на 0 нельзя");
        }

        Console.WriteLine("=================================");

        try
        {
            Console.WriteLine(list[1000]);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            FileLogger.logMessageFile(ex.Message + '/' + ex.StackTrace);
            ConsoleLogger.logMessageConsole(ex.Message + '/' + ex.StackTrace);
        }
        finally
        {
            Console.WriteLine("Обращение к элементу массива за пределами размера нельзя");
        }

        Console.WriteLine("=================================");

        try
        {
            if (sweet4.Name.Length > 10)
            {
                throw new BoxOfCandyException("Название не должно быть больше 10 символов");
            }
            else
            {
                box.add(sweet4);
            }
        }
        catch (BoxOfCandyException ex) 
        {
            FileLogger.logMessageFile(ex.Message+'/'+ex.StackTrace);
            ConsoleLogger.logMessageConsole(ex.Message + '/' + ex.StackTrace);
        }
        finally
        {
            Console.WriteLine("Поаккуратней с названиями!");
        }

        contr.searchCandy(-4, 5);

        Console.WriteLine("=================================");

        
        contr.getList().printList();
        Console.WriteLine("=================================");
        contr.readFromFile(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#4\file.txt");
        contr.getList().printList();

        Console.WriteLine("=================================");
        contr.sortCandy();
        contr.getList().printList();

        Console.WriteLine("=================================");
        contr.searchCandy(10, 20);

        Console.WriteLine("=================================");
        contr.InitWithJson(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#4\file1.json");
        contr.getList().printList();

        box.AppDomainSetup(100, sweet2);
    }
}