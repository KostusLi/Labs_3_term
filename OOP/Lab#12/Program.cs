using System;
using System.IO;

internal class Program
{
    static void Main()
    {

        string basePath = @"C:\Из рабочего стола\Labs 3 sem\OOP\Lab#12";
        Directory.SetCurrentDirectory(basePath);
        Console.WriteLine("Рабочая директория установлена: " + Directory.GetCurrentDirectory());
        Console.WriteLine();

        HKVDiskInfo diskInfo = new HKVDiskInfo(DriveInfo.GetDrives());
        Console.WriteLine("=== Информация о дисках ===");
        diskInfo.GetInfoAboutDisk();
        Console.WriteLine(diskInfo.FreeSpace("C"));
        diskInfo.GetInfoAboutFileSystem();
        Console.WriteLine();

        Console.WriteLine("=== Работа с каталогами ===");
        HKVFileManager.CreateDir("HKVFiles");
        HKVFileManager.CreateDir("Extracted");

        DirectoryInfo dir = new DirectoryInfo(Path.Combine(basePath, "HKVFiles"));
        HKVDirInfo dirInfo = new HKVDirInfo(dir);

        dirInfo.CountOfFile();
        dirInfo.CountOfPreDirectory();
        dirInfo.TimeOfCreation();
        dirInfo.ParentDirectory();
        Console.WriteLine();

        Console.WriteLine("=== Работа с файлами ===");

        string file1 = "test1.txt";
        string file2 = "test2.txt";
        HKVFileManager.CreateTextFile(file1);
        HKVFileManager.CreateTextFile(file2);

        HKVFileManager.AddInfoToFile(file1, "Это тестовая строка для test1.txt\n");
        HKVFileManager.AddInfoToFile(file2, "Это тестовая строка для test2.txt\n");

        FileInfo file = new FileInfo(Path.Combine(basePath, file1));
        HKVFileInfo fileInfo = new HKVFileInfo(file);
        fileInfo.FullPath();
        fileInfo.SomeInfo();
        fileInfo.DateOfFile();
        Console.WriteLine();

        HKVFileManager.RenameFile(file1, "renamed_test1.txt");
        Console.WriteLine("Файл успешно переименован!");
        Console.WriteLine();

        Console.WriteLine("=== Архивация и разархивация ===");

        string sourceFolder = Path.Combine(basePath, "HKVFiles");
        string zipPath = Path.Combine(basePath, "HKVArchive.zip");
        string extractFolder = Path.Combine(basePath, "Extracted");

        HKVFileManager.Archivation(sourceFolder, zipPath);

        HKVFileManager.DeArchive(zipPath, extractFolder);
        Console.WriteLine();

        Console.WriteLine("=== Работа с логом ===");

        Console.WriteLine("\n--- Полное содержимое лога ---");
        Console.WriteLine(HKVLog.ReadInformation());

        Console.WriteLine("\n--- Поиск информации по ключевому слову 'HKVFileInfo' ---");
        Console.WriteLine(HKVLog.FindInformation("HKVFileInfo"));

        Console.WriteLine("\nРабота программы завершена!");
    }
}
