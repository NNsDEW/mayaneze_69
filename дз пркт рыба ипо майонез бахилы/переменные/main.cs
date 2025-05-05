using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите ФИО: ");
        string fullName = Console.ReadLine();

        Console.Write("Введите возраст: ");
        byte age = byte.Parse(Console.ReadLine());

        Console.Write("Введите рост (см): ");
        ushort height = ushort.Parse(Console.ReadLine());

        Console.Write("Введите вес (кг): ");
        float weight = float.Parse(Console.ReadLine());

        // Способ 1: Построчно
        Console.WriteLine("\nСпособ 1:");
        Console.WriteLine($"ФИО: {fullName}");
        Console.WriteLine($"Возраст: {age}");
        Console.WriteLine($"Рост: {height} см");
        Console.WriteLine($"Вес: {weight} кг");

        // Способ 2: В одну строку
        Console.WriteLine("\nСпособ 2:");
        Console.WriteLine($"{fullName}, {age} лет, {height} см, {weight} кг");

        // Способ 3: Форматированный вывод
        Console.WriteLine("\nСпособ 3:");
        Console.WriteLine("ФИО: {0}\nВозраст: {1} лет\nРост: {2} см\nВес: {3} кг", 
                          fullName, age, height, weight);
    }
}