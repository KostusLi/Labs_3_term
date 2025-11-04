using System;

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(Candy);

        Type candyType = typeof(Candy);
        Console.WriteLine("=== Класс Candy ===");
        Console.WriteLine("Сборка: " + Reflector.getAssembly(candyType));
        Console.WriteLine("Есть ли публичные конструкторы: " + Reflector.getConstructors(candyType));

        Console.WriteLine("Методы:");
        foreach (var m in Reflector.getMethods(candyType))
            Console.WriteLine("  " + m);

        Console.WriteLine("Поля и свойства:");
        foreach (var p in Reflector.getPropertiesFields(candyType))
            Console.WriteLine("  " + p);

        Console.WriteLine("Интерфейсы:");
        foreach (var i in Reflector.getInterfaces(candyType))
            Console.WriteLine("  " + i);

        Console.WriteLine("\nМетоды, принимающие параметр типа string:");
        foreach (var m in Reflector.getParamFromType(candyType, typeof(string)))
            Console.WriteLine("  " + m);

        var candyObj = Reflector.Create<Candy>();
        Console.WriteLine("\nСоздан объект Candy: " + candyObj);

        Type chocolateType = typeof(ChocolateCandy);
        Console.WriteLine("\n=== Класс ChocolateCandy ===");
        Console.WriteLine("Сборка: " + Reflector.getAssembly(chocolateType));
        Console.WriteLine("Методы:");
        foreach (var m in Reflector.getMethods(chocolateType))
            Console.WriteLine("  " + m);

        var chocoObj = Reflector.Create<ChocolateCandy>();
        Console.WriteLine("Создан объект ChocolateCandy: " + chocoObj);

        Type stringType = typeof(string);
        Console.WriteLine("\n=== Стандартный класс String ===");
        Console.WriteLine("Сборка: " + Reflector.getAssembly(stringType));
        Console.WriteLine("Количество конструкторов: " + stringType.GetConstructors().Length);

        Type listType = typeof(List<int>);
        Console.WriteLine("\n=== Стандартный класс List<int> ===");
        Console.WriteLine("Сборка: " + Reflector.getAssembly(listType));
        Console.WriteLine("Методы:");
        foreach (var m in Reflector.getMethods(listType))
            Console.WriteLine("  " + m);
    }
}
