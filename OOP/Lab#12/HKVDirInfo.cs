using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class HKVDirInfo
{
    DirectoryInfo directory;

    public HKVDirInfo(DirectoryInfo directory)
    {
        this.directory = directory;
    }

    public void CountOfFile()
    {
        Console.WriteLine($"Кол-во файлов в каталоге: {this.directory.GetFiles().Count()}");
    }

    public void TimeOfCreation()
    {
        Console.WriteLine($"Время создания каталога: {this.directory.CreationTime}");
    }

    public void CountOfPreDirectory()
    {
        Console.WriteLine($"Кол-во поддиректориев: {this.directory.GetDirectories().Count()}");
    }

    public void ParentDirectory()
    {
        Console.WriteLine($"Родительный каталог директория {directory.Name}: {directory.Parent}");
    }
}

