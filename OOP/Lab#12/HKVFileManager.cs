using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

static internal class HKVFileManager
{

    public static void AllElemInDisk(string disk)
    {
        try
        {
            if (!Regex.IsMatch(disk, @"^[A-Z]{1}:\\")) throw new Exception("В функцию передан не диск!");
            Console.WriteLine($"Файлы и папки в диске {disk}");
            foreach (string dir in Directory.GetFileSystemEntries(disk))
            {
                Console.WriteLine(dir);
            }
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"Ошибка в функции AllElemInDisk(string path): {ex.Message}");
        }
    }

    public static void CreateDir(string name)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        Directory.CreateDirectory(path);
    }

    public static void CreateTextFile(string name)
    { 
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        using (File.Create(path)) { }
    }

    public static void AddInfoToFile(string name, string text)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        File.AppendAllText(path, text);
    }

    public static void CopyFile(string name)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        File.Copy(Directory.GetCurrentDirectory(), File.ReadAllText(path));
    }

    public static void DeleteFile(string name) {
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        File.Delete(path);
    }

    public static void RenameFile(string name, string newName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        string newPath = Path.Combine(Directory.GetCurrentDirectory(), newName);
        try
        {
            File.Move(path, newPath);
        }
        catch (Exception ex) { 
            Console.WriteLine("Ошибка в функции RenameFile(string name, string newName): " + ex.Message);
        }
    }

    public static void ReplaceDir(string dirName, string newDir) {
        string path = Path.Combine(Directory.GetCurrentDirectory(), dirName);
        string newPath = Path.Combine(Directory.GetCurrentDirectory(), newDir);
        Directory.Move(path, newPath);
    }

    public static void CopyFileWithExist(string path, string exist, string newPath)
    {
        string[] dir = Directory.GetFiles(path);
        foreach (string dirName in dir) {
            if (dirName.EndsWith(exist)) {
                string temp = Path.Combine(path, dirName);
                File.Move(temp, newPath);
            }
        }
    }


    public static void Archivation(string sourceFolder, string zipPath)
    {
        try
        {
            ZipFile.CreateFromDirectory(sourceFolder, zipPath);
            Console.WriteLine("Архив успешно создан: " + zipPath);
        }
        catch(Exception ex) { 
            Console.WriteLine("Ошибка в функции Archivation(string sourceFolder, string zipPath): " + ex.Message);
        }
    }

    public static void DeArchive(string zipPath, string extractFolder)
    {
        ZipFile.ExtractToDirectory(zipPath, extractFolder);
        Console.WriteLine("Архив успешно разархивирован в: " + extractFolder);
    }

}
