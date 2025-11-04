using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class HKVLog
{
    public static void WriteInFile(DateTime date, string text, Type type)
    {
        string result = date.ToString() + '[' +type.Name.ToString() + ']' + ':' + text + '\n';
        File.AppendAllText(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#12\HKVlogfile.txt", result);
    }

    public static string FindInformation(string text)
    {
        foreach (string line in File.ReadLines(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#12\HKVlogfile.txt"))
        {
            if(line.Contains(text)) return line;
        }
        return "Информация не найдена";
    }

    public static string ReadInformation()
    {
        return File.ReadAllText(@"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#12\HKVlogfile.txt");
    }

}
