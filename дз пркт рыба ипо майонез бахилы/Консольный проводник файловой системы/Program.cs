using System;
using System.IO;
using System.Text;

class FileExplorer
{
    static void Main()
    {
        DriveInfo selectedDrive = null;
        while (true)
        {
            selectedDrive = SelectDrive();
            if (selectedDrive == null)
                break;

            ExploreDrive(selectedDrive);
        }
    }

    static DriveInfo SelectDrive()
    {
        while (true)
        {
            Console.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                DriveInfo drive = drives[i];
                if (drive.IsReady)
                {
                    Console.WriteLine($"{i + 1}. {drive.Name} ({drive.DriveType}, {FormatBytes(drive.AvailableFreeSpace)} свободно из {FormatBytes(drive.TotalSize)})");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {drive.Name} (Не готов)");
                }
            }
            Console.WriteLine("\nВведите номер диска или 'Q' для выхода:");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Q")
                return null;

            if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= drives.Length)
            {
                DriveInfo selectedDrive = drives[selectedIndex - 1];
                if (!selectedDrive.IsReady)
                {
                    Console.WriteLine("Диск не готов. Выберите другой.");
                    Console.ReadKey();
                    continue;
                }
                return selectedDrive;
            }
            else
            {
                Console.WriteLine("Неверный ввод.");
                Console.ReadKey();
            }
        }
    }

    static void ExploreDrive(DriveInfo drive)
    {
        string currentPath = drive.RootDirectory.FullName;

        while (true)
        {
            try
            {
                ShowDirectoryContents(currentPath);
                Console.WriteLine("\nДействия:");
                Console.WriteLine("1. Открыть папку/файл");
                Console.WriteLine("2. Создать папку");
                Console.WriteLine("3. Создать файл");
                Console.WriteLine("4. Удалить элемент");
                Console.WriteLine("5. Информация о диске");
                Console.WriteLine("6. Вернуться к выбору диска");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите действие: ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        OpenItem(ref currentPath);
                        break;
                    case "2":
                        CreateDirectory(currentPath);
                        break;
                    case "3":
                        CreateFile(currentPath);
                        break;
                    case "4":
                        DeleteItem(currentPath);
                        break;
                    case "5":
                        ShowDriveInfo(drive);
                        break;
                    case "6":
                        return;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.ReadKey();
            }
        }
    }

    static void ShowDirectoryContents(string path)
    {
        Console.Clear();
        Console.WriteLine($"Текущий путь: {path}\n");

        string[] directories;
        string[] files;

        try
        {
            directories = Directory.GetDirectories(path);
            files = Directory.GetFiles(path);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Ошибка доступа к каталогу.");
            return;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Каталог не найден.");
            return;
        }

        Console.WriteLine("Папки:");
        for (int i = 0; i < directories.Length; i++)
        {
            Console.WriteLine($"{i + 1}. [Папка] {Path.GetFileName(directories[i])}");
        }

        Console.WriteLine("\nФайлы:");
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{directories.Length + i + 1}. [Файл] {Path.GetFileName(files[i])}");
        }
    }

    static void OpenItem(ref string currentPath)
    {
        Console.Write("Введите номер элемента: ");
        if (!int.TryParse(Console.ReadLine(), out int itemNumber))
        {
            Console.WriteLine("Неверный номер.");
            Console.ReadKey();
            return;
        }

        string[] directories;
        string[] files;

        try
        {
            directories = Directory.GetDirectories(currentPath);
            files = Directory.GetFiles(currentPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadKey();
            return;
        }

        int totalItems = directories.Length + files.Length;
        if (itemNumber < 1 || itemNumber > totalItems)
        {
            Console.WriteLine("Неверный номер элемента.");
            Console.ReadKey();
            return;
        }

        if (itemNumber <= directories.Length)
        {
            currentPath = directories[itemNumber - 1];
        }
        else
        {
            string filePath = files[itemNumber - directories.Length - 1];
            if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine($"\nСодержимое файла:\n{content}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Поддерживается только просмотр текстовых файлов (.txt).");
            }
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    static void CreateDirectory(string currentPath)
    {
        Console.Write("Введите имя папки: ");
        string dirName = Console.ReadLine();
        string newDir = Path.Combine(currentPath, dirName);

        if (Directory.Exists(newDir))
        {
            Console.WriteLine("Папка уже существует.");
            Console.ReadKey();
            return;
        }

        try
        {
            Directory.CreateDirectory(newDir);
            Console.WriteLine("Папка создана.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void CreateFile(string currentPath)
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(currentPath, fileName);

        if (File.Exists(filePath))
        {
            Console.WriteLine("Файл уже существует.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Введите текст (для завершения введите 'END' с новой строки):");
        StringBuilder content = new StringBuilder();
        string line;
        while ((line = Console.ReadLine()) != "END")
        {
            content.AppendLine(line);
        }

        try
        {
            File.WriteAllText(filePath, content.ToString());
            Console.WriteLine("Файл создан.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void DeleteItem(string currentPath)
    {
        Console.Write("Введите номер элемента: ");
        if (!int.TryParse(Console.ReadLine(), out int itemNumber))
        {
            Console.WriteLine("Неверный номер.");
            Console.ReadKey();
            return;
        }

        string[] directories;
        string[] files;

        try
        {
            directories = Directory.GetDirectories(currentPath);
            files = Directory.GetFiles(currentPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadKey();
            return;
        }

        int totalItems = directories.Length + files.Length;
        if (itemNumber < 1 || itemNumber > totalItems)
        {
            Console.WriteLine("Неверный номер элемента.");
            Console.ReadKey();
            return;
        }

        string targetPath;
        bool isDirectory;

        if (itemNumber <= directories.Length)
        {
            targetPath = directories[itemNumber - 1];
            isDirectory = true;
        }
        else
        {
            targetPath = files[itemNumber - directories.Length - 1];
            isDirectory = false;
        }

        Console.Write($"Вы уверены, что хотите удалить {targetPath}? (Y/N): ");
        if (Console.ReadLine().ToUpper() != "Y")
            return;

        try
        {
            if (isDirectory)
            {
                Directory.Delete(targetPath, true);
                Console.WriteLine("Папка удалена.");
            }
            else
            {
                File.Delete(targetPath);
                Console.WriteLine("Файл удален.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void ShowDriveInfo(DriveInfo drive)
    {
        Console.Clear();
        Console.WriteLine($"Информация о диске {drive.Name}:");
        if (drive.IsReady)
        {
            Console.WriteLine($"Тип: {drive.DriveType}");
            Console.WriteLine($"Формат: {drive.DriveFormat}");
            Console.WriteLine($"Общий объем: {FormatBytes(drive.TotalSize)}");
            Console.WriteLine($"Свободно: {FormatBytes(drive.AvailableFreeSpace)}");
        }
        else
        {
            Console.WriteLine("Диск не готов.");
        }
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static string FormatBytes(long bytes)
    {
        string[] suffix = { "B", "KB", "MB", "GB", "TB" };
        int i = 0;
        double dblBytes = bytes;

        while (dblBytes >= 1024 && i < suffix.Length - 1)
        {
            dblBytes /= 1024;
            i++;
        }

        return $"{dblBytes:0.##} {suffix[i]}";
    }
}