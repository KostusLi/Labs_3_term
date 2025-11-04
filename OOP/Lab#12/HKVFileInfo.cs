using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class HKVFileInfo
{
    FileInfo file;

    public HKVFileInfo(FileInfo file)
    {
        this.file = file;
    }

    public void FullPath()
    {
        HKVLog.WriteInFile(DateTime.Now, $"Вызвана функция FullPath() для вывода полного пути к файлу", typeof(HKVFileInfo));
        Console.WriteLine(this.file.DirectoryName);
    }

    public void SomeInfo()
    {
        HKVLog.WriteInFile(DateTime.Now, $"Вызвана функция SomeInfo() для вывода имени, расширение и размера файла", typeof(HKVFileInfo));
        Console.WriteLine($"{this.file.Name}: размер - {this.file.Length}, расширение - {this.file.Extension}");
    }

    public void DateOfFile()
    {
        HKVLog.WriteInFile(DateTime.Now, $"Вызвана функция DateOfFile(string path) для вывода даты создания и изменения файла", typeof(HKVFileInfo));
        Console.WriteLine($"Дата создание файла - {this.file.CreationTime}, дата изменения файла - {this.file.LastWriteTime}");
    }
}

