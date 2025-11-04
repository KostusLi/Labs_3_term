using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

internal class HKVDiskInfo
{
    DriveInfo[] drives;

    public HKVDiskInfo(DriveInfo[] drives)
    {
        this.drives = drives;
    }

    public string FreeSpace(string name)
    {
        try
        {
            HKVLog.WriteInFile(DateTime.Now, $"Вызвана функция FreeSpace(string name) для поиска свободного места на диске {name}", typeof(HKVDiskInfo));
            foreach (DriveInfo drive in this.drives)
            {
                if (drive.Name.Contains(name))
                {
                    return drive.Name + ": " + drive.TotalFreeSpace + " байт осталось свободного места";
                }
            }
            throw new Exception("Нет такого диска!");
        }
        catch (Exception ex) { 
            return ex.Message;
        }
       
    }

    public void GetInfoAboutFileSystem()
    {
        try
        {
            HKVLog.WriteInFile(DateTime.Now, $"Вызвана функция GetInfoAboutFileSystem() для вывода информации о файловой системе", typeof(HKVDiskInfo));
            foreach (DriveInfo drive in this.drives)
            {
                Console.WriteLine(drive.Name + ": " + drive.DriveFormat);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка в функции GetInfoAboutFileSystem: {ex.Message}");
        }
    }

    public void GetInfoAboutDisk()
    {
        try
        {
            HKVLog.WriteInFile(DateTime.Now, $"Вызвана функция GetInfoAboutDisk() для вывода информации о всех дисках", typeof(HKVDiskInfo));
            foreach (DriveInfo drive in this.drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка в функции GetInfoAboutDisk: {ex.Message}");
        }
    }

}
