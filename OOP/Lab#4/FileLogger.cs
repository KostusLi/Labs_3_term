using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

static public class FileLogger
{
    static public void logMessageFile(string message)
    {
        File.AppendAllText(@"C:\\Из рабочего стола\\Labs 3 sem\\OOP\\Lab#4\\logger.txt", $"{DateTime.Now}, INFO: {message}.\n");
    }
}

static public class ConsoleLogger
{
    static public void  logMessageConsole(string message)
    {
        Console.WriteLine($"{DateTime.Now}, INFO: {message}.");
    }
}
