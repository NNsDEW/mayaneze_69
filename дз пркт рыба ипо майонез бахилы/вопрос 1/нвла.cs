using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== НОВЕЛЛА 'СБОРКА КОМПЬЮТЕРА' ===");
        Console.WriteLine("Вы решили собрать свой первый компьютер. Ваш бюджет: 1000$");
        Console.WriteLine("Шаг 1. Выберите процессор:");
        Console.WriteLine("1. Intel Core i5 - 300$");
        Console.WriteLine("2. AMD Ryzen 5 - 250$");
        Console.WriteLine("3. Эконом вариант - 150$");
        
        int choice = Convert.ToInt32(Console.ReadLine());
        int budget = 1000;
        string components = "";
        
        // Шаг 1 - Выбор процессора
        switch(choice)
        {
            case 1:
                budget -= 300;
                components += "Intel Core i5, ";
                break;
            case 2:
                budget -= 250;
                components += "AMD Ryzen 5, ";
                break;
            case 3:
                budget -= 150;
                components += "Бюджетный процессор, ";
                break;
        }

        // Шаг 2 - Выбор видеокарты
        Console.WriteLine("\nШаг 2. Выберите видеокарту:");
        Console.WriteLine($"Остаток бюджета: {budget}$");
        Console.WriteLine("1. NVIDIA RTX 3060 - 400$");
        Console.WriteLine("2. AMD RX 6600 - 350$");
        Console.WriteLine("3. Встроенная графика - 0$");
        
        choice = Convert.ToInt32(Console.ReadLine());
        
        switch(choice)
        {
            case 1:
                if(budget >= 400)
                {
                    budget -= 400;
                    components += "RTX 3060, ";
                }
                else
                {
                    Console.WriteLine("Не хватает денег! Выбирайте другой вариант.");
                    return;
                }
                break;
            case 2:
                if(budget >= 350)
                {
                    budget -= 350;
                    components += "RX 6600, ";
                }
                else
                {
                    Console.WriteLine("Не хватает денег! Выбирайте другой вариант.");
                    return;
                }
                break;
            case 3:
                components += "Встроенная графика, ";
                break;
        }

        // Шаг 3 - Выбор оперативной памяти
        Console.WriteLine("\nШаг 3. Выберите оперативную память:");
        Console.WriteLine($"Остаток бюджета: {budget}$");
        Console.WriteLine("1. 16GB DDR4 - 80$");
        Console.WriteLine("2. 32GB DDR4 - 150$");
        Console.WriteLine("3. 8GB DDR4 - 50$");
        
        choice = Convert.ToInt32(Console.ReadLine());
        
        switch(choice)
        {
            case 1:
                budget -= 80;
                components += "16GB RAM, ";
                break;
            case 2:
                if(budget >= 150)
                {
                    budget -= 150;
                    components += "32GB RAM, ";
                }
                else
                {
                    Console.WriteLine("Не хватает денег! Выбирайте другой вариант.");
                    return;
                }
                break;
            case 3:
                budget -= 50;
                components += "8GB RAM, ";
                break;
        }

        // Шаг 4 - Выбор SSD
        Console.WriteLine("\nШаг 4. Выберите SSD накопитель:");
        Console.WriteLine($"Остаток бюджета: {budget}$");
        Console.WriteLine("1. 1TB NVMe - 100$");
        Console.WriteLine("2. 500GB NVMe - 60$");
        Console.WriteLine("3. 256GB SATA - 40$");
        
        choice = Convert.ToInt32(Console.ReadLine());
        
        switch(choice)
        {
            case 1:
                if(budget >= 100)
                {
                    budget -= 100;
                    components += "1TB SSD, ";
                }
                else
                {
                    Console.WriteLine("Не хватает денег! Выбирайте другой вариант.");
                    return;
                }
                break;
            case 2:
                budget -= 60;
                components += "500GB SSD, ";
                break;
            case 3:
                budget -= 40;
                components += "256GB SSD, ";
                break;
        }

        // Шаг 5 - Выбор корпуса
        Console.WriteLine("\nШаг 5. Выберите корпус:");
        Console.WriteLine($"Остаток бюджета: {budget}$");
        Console.WriteLine("1. Игровой с RGB - 120$");
        Console.WriteLine("2. Стандартный - 70$");
        Console.WriteLine("3. Бюджетный - 40$");
        
        choice = Convert.ToInt32(Console.ReadLine());
        
        switch(choice)
        {
            case 1:
                if(budget >= 120)
                {
                    budget -= 120;
                    components += "Игровой корпус";
                }
                else
                {
                    Console.WriteLine("Не хватает денег! Выбирайте другой вариант.");
                    return;
                }
                break;
            case 2:
                budget -= 70;
                components += "Стандартный корпус";
                break;
            case 3:
                budget -= 40;
                components += "Бюджетный корпус";
                break;
        }

        // Определение концовки
        Console.WriteLine("\n=== РЕЗУЛЬТАТ ===");
        Console.WriteLine($"Собранный компьютер: {components}");
        Console.WriteLine($"Остаток бюджета: {budget}$");
        
        if(components.Contains("RTX 3060") && components.Contains("32GB RAM"))
        {
            Console.WriteLine("\nКОНЦОВКА 1: ИГРОВАЯ МАШИНА");
            Console.WriteLine("Вы собрали мощный игровой ПК! Теперь можно играть в любые игры на ультра настройках.");
        }
        else if(components.Contains("Встроенная графика") && components.Contains("Бюджетный процессор"))
        {
            Console.WriteLine("\nКОНЦОВКА 2: ОФИСНЫЙ ПК");
            Console.WriteLine("Вы собрали самый бюджетный вариант. Подойдет для работы с документами и интернета.");
        }
        else if(budget > 300)
        {
            Console.WriteLine("\nКОНЦОВКА 3: ЭКОНОМНЫЙ СБОРЩИК");
            Console.WriteLine("Вы уложились в бюджет и еще остались деньги на периферию!");
        }
        else if(components.Contains("Игровой корпус") && !components.Contains("RTX 3060"))
        {
            Console.WriteLine("\nКОНЦОВКА 4: СТИЛЬ ПРЕВЫШЕ ВСЕГО");
            Console.WriteLine("Корпус с подсветкой выглядит круто, но производительность оставляет желать лучшего.");
        }
        else
        {
            Console.WriteLine("\nКОНЦОВКА 5: СБАЛАНСИРОВАННЫЙ ВАРИАНТ");
            Console.WriteLine("Вы нашли золотую середину между ценой и производительностью.");
        }
    }
}