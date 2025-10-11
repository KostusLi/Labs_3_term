using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.IO;

internal class CollectionType<T> : IMyInterface<T> where T : Matrix
{
    private List<T> list;

    public CollectionType()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        try
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Нельзя добавить null в коллекцию!");
            list.Add(item);
            Console.WriteLine($"Элемент {item} добавлен.");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Вызван метод Add (finally).");
        }
    }

    public void Remove(T item)
    {
        try
        {
            if (!list.Remove(item))
                throw new KeyNotFoundException("Элемент не найден для удаления!");
            Console.WriteLine($"Элемент {item} удалён.");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Ошибка при удалении: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Вызван метод Remove (finally).");
        }
    }

    public void Print()
    {
        try
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Коллекция пуста!");

            Console.WriteLine("Элементы коллекции:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка при выводе: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Вызван метод Print (finally).");
        }
    }

    public T Find(Predicate<T> match)
    {
        try
        {
            T result = list.Find(match);
            if (result == null)
                throw new KeyNotFoundException("Элемент, удовлетворяющий условию, не найден!");
            return result;
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Ошибка при поиске: {ex.Message}");
            return null;
        }
        finally
        {
            Debug.WriteLine("Вызван метод Find (finally).");
        }
    }

    //public override string ToString()
    //{
    //    string str = "";
    //    for(int i=0; i<this.list.Count; i++)
    //    {
    //        str += this.list[i];
    //        str += '\n';
    //    }

    //    return str;
    //}

    public void writeToJson(string path)
    {
        string json = JsonSerializer.Serialize(this.list, new JsonSerializerOptions { WriteIndented = true});
        File.WriteAllText(path, json);
    }

    public List<T> readFromJson(string path)
    {
        try
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден!", path);

            string temp = File.ReadAllText(path);

            var deserialized = JsonSerializer.Deserialize<List<T>>(temp);

            if (deserialized == null)
                throw new InvalidOperationException("Не удалось десериализовать JSON.");

            this.list = deserialized;
            return this.list;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении JSON: {ex.Message}");
            return new List<T>();
        }
        finally
        {
            Debug.WriteLine("Вызван метод readFromJson (finally).");
        }
    }


}