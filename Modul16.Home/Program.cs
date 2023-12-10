using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul16.Home
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Команды:list create delete move copy read write exit");
                Console.WriteLine("Введите команду: ");
                string command = Console.ReadLine();
                string path, destination;

                switch (command.ToLower())
                {
                    case "list":
                        Console.WriteLine("Введите путь к директории:");
                        path = Console.ReadLine();
                        FileManager.ListDirectoryContents(path);
                        break;

                    case "create":
                        Console.WriteLine("Введите путь для создания файла или директории:");
                        path = Console.ReadLine();
                        FileManager.CreateFileOrDirectory(path);
                        break;

                    case "delete":
                        Console.WriteLine("Введите путь к файлу или директории для удаления:");
                        path = Console.ReadLine();
                        FileManager.DeleteFileOrDirectory(path);
                        break;

                    case "move":
                        Console.WriteLine("Введите путь к файлу/директории для перемещения:");
                        path = Console.ReadLine();
                        Console.WriteLine("Введите назначение:");
                        destination = Console.ReadLine();
                        FileManager.MoveFileOrDirectory(path, destination);
                        break;

                    case "copy":
                        Console.WriteLine("Введите путь к файлу/директории для копирования:");
                        path = Console.ReadLine();
                        Console.WriteLine("Введите назначение:");
                        destination = Console.ReadLine();
                        FileManager.CopyFileOrDirectory(path, destination);
                        break;

                    case "read":
                        Console.WriteLine("Введите путь к файлу для чтения:");
                        path = Console.ReadLine();
                        FileManager.ReadFile(path);
                        break;

                    case "write":
                        Console.WriteLine("Введите путь к файлу для записи:");
                        path = Console.ReadLine();
                        FileManager.WriteToFile(path);
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }

        
    }
}
