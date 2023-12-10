using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Modul16.Home
{
    public class FileManager
    {
        public static void ListDirectoryContents(string path)
        {
            if (Directory.Exists(path))
            {
                string[] entries = Directory.GetFileSystemEntries(path);
                foreach (string entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("Директория не найдена.");
            }
        }
        public static void CreateFileOrDirectory(string path)
        {
            if (File.Exists(path) || Directory.Exists(path))
            {
                Console.WriteLine("Файл или директория уже существует.");
                return;
            }

            if (path.EndsWith("/"))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Директория создана.");
            }
            else
            {
                File.Create(path).Close();
                Console.WriteLine("Файл создан.");
            }
        }
        public static void DeleteFileOrDirectory(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("Файл удалён.");
            }
            else if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Console.WriteLine("Директория удалена.");
            }
            else
            {
                Console.WriteLine("Файл или директория не найдены.");
            }
        }
        public static void MoveFileOrDirectory(string source, string destination)
        {
            if (File.Exists(source))
            {
                File.Move(source, destination);
                Console.WriteLine("Файл перемещён.");
            }
            else if (Directory.Exists(source))
            {
                Directory.Move(source, destination);
                Console.WriteLine("Директория перемещена.");
            }
            else
            {
                Console.WriteLine("Файл или директория не найдены.");
            }
        }
        public static void CopyFileOrDirectory(string source, string destination)
        {
            if (File.Exists(source))
            {
                File.Copy(source, destination);
                Console.WriteLine("Файл скопирован.");
            }
            else if (Directory.Exists(source))
            {
                CopyDirectory(source, destination);
                Console.WriteLine("Директория скопирована.");
            }
            else
            {
                Console.WriteLine("Файл или директория не найдены.");
            }
        }
        public static void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string dest = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, dest);
            }
            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string dest = Path.Combine(destDir, Path.GetFileName(directory));
                CopyDirectory(directory, dest);
            }
        }
        public static void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
        public static void WriteToFile(string path)
        {
            Console.WriteLine("Введите текст для записи:");
            string content = Console.ReadLine();

            File.WriteAllText(path, content);
            Console.WriteLine("Текст записан в файл.");
        }
    }
}
