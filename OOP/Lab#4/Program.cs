using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        Candy sweet1 = new Candy("bimbom", 23, 45);
        ChocolateCandy sweet2 = new ChocolateCandy("air", 43, 12);
        Caramel sweet3 = new Caramel("maria", 12, 23);

        List<Candy> list= new List<Candy>() { sweet1, sweet2, sweet3};

        BoxOfCandy<Candy> box = new BoxOfCandy<Candy>();
        box.add(sweet1);
        box.add(sweet2);
        box.add(sweet3);

        Controller contr = new Controller(box);
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

    }
}