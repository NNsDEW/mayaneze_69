using System;
using System.Collections.Generic;

class ComputerBuildingNovel
{
    static void Main()
    {
        int budget = 1500; // Увеличенный бюджет для большего выбора
        int step = 0;
        Dictionary<string, string> components = new Dictionary<string, string>();
        Dictionary<string, int> prices = new Dictionary<string, int>();
        Random rand = new Random();

        Console.WriteLine("=== НОВЕЛЛА 'СБОРКА КОМПЬЮТЕРА' ===");
        Console.WriteLine($"Ваш бюджет: {budget}$\n");

        // Главный цикл с 20 итерациями (шагами)
        while (step < 20 && budget > 0)
        {
            step++;
            Console.WriteLine($"\n=== ШАГ {step}/20 ===");
            Console.WriteLine($"Текущий бюджет: {budget}$");
            
            // Случайный выбор типа компонента для каждого шага
            string componentType = GetRandomComponentType(rand);
            
            // Если компонент уже выбран, предлагаем улучшить его
            if (components.ContainsKey(componentType))
            {
                Console.WriteLine($"Хотите улучшить {componentType}? (Текущий: {components[componentType]} за {prices[componentType]}$)");
                Console.WriteLine("1. Да\n2. Нет");
                if (Console.ReadLine() != "1") continue;
            }

            // Выбор компонента
            bool validChoice = false;
            while (!validChoice && budget > 0)
            {
                Console.WriteLine($"\nВыберите {componentType}:");
                var options = GetComponentOptions(componentType);
                
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {options[i].Name} - {options[i].Price}$");
                }
                Console.WriteLine("0. Пропустить этот шаг");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= options.Count)
                {
                    if (choice == 0) break;

                    var selected = options[choice-1];
                    if (selected.Price <= budget)
                    {
                        budget -= selected.Price;
                        components[componentType] = selected.Name;
                        prices[componentType] = selected.Price;
                        validChoice = true;
                        Console.WriteLine($"\nВыбрано: {selected.Name} (-{selected.Price}$)");
                    }
                    else
                    {
                        Console.WriteLine("\n⚠ Недостаточно средств! Выберите другой вариант.");
                    }
                }
                else
                {
                    Console.WriteLine("\n⚠ Некорректный ввод! Пожалуйста, введите число.");
                }
            }
        }

        // Вывод результатов
        Console.WriteLine("\n=== ВАША ФИНАЛЬНАЯ СБОРКА ===");
        foreach (var item in components)
        {
            Console.WriteLine($"{item.Key}: {item.Value} ({prices[item.Key]}$)");
        }
        Console.WriteLine($"\nОстаток бюджета: {budget}$");

        // Определение концовки
        Console.WriteLine("\n=== ИТОГ ===");
        DetermineEnding(components, prices, budget);
    }

    static string GetRandomComponentType(Random rand)
    {
        string[] types = {
            "процессор", "видеокарта", "оперативная память", 
            "материнская плата", "накопитель", "корпус",
            "блок питания", "охлаждение", "звуковая карта",
            "сетевая карта", "дополнительные вентиляторы",
            "подсветка", "аксессуары"
        };
        return types[rand.Next(types.Length)];
    }

    static List<ComponentOption> GetComponentOptions(string componentType)
    {
        var options = new List<ComponentOption>();
        
        switch (componentType.ToLower())
        {
            case "процессор":
                options.Add(new ComponentOption("Intel Core i9-13900K", 600));
                options.Add(new ComponentOption("AMD Ryzen 9 7950X", 550));
                options.Add(new ComponentOption("Intel Core i7-13700K", 400));
                options.Add(new ComponentOption("AMD Ryzen 7 7700X", 350));
                options.Add(new ComponentOption("Intel Core i5-13600K", 300));
                break;
                
            case "видеокарта":
                options.Add(new ComponentOption("NVIDIA RTX 4090", 1600));
                options.Add(new ComponentOption("AMD RX 7900 XTX", 1000));
                options.Add(new ComponentOption("NVIDIA RTX 4080", 1200));
                options.Add(new ComponentOption("AMD RX 6800 XT", 650));
                options.Add(new ComponentOption("NVIDIA RTX 3060", 350));
                break;
                
            // ... аналогично для других компонентов ...
        }

        return options;
    }

    static void DetermineEnding(Dictionary<string, string> components, Dictionary<string, int> prices, int budget)
    {
        bool hasHighEndGPU = components.ContainsKey("видеокарта") && 
                            (components["видеокарта"].Contains("4090") || 
                             components["видеокарта"].Contains("7900"));
        bool hasHighEndCPU = components.ContainsKey("процессор") && 
                            (components["процессор"].Contains("i9") || 
                             components["процессор"].Contains("Ryzen 9"));
        bool hasRGB = components.ContainsKey("подсветка");
        bool hasWaterCooling = components.ContainsKey("охлаждение") && 
                              components["охлаждение"].Contains("водяное");
        bool hasSSD = components.ContainsKey("накопитель") && 
                     components["накопитель"].Contains("NVMe");
        bool hasSoundCard = components.ContainsKey("звуковая карта");
        bool hasNetworkCard = components.ContainsKey("сетевая карта");
        bool hasExtraFans = components.ContainsKey("дополнительные вентиляторы");
        bool hasAccessories = components.ContainsKey("аксессуары");
        bool hasHighEndPSU = components.ContainsKey("блок питания") && 
                            components["блок питания"].Contains("1000W");

        // 10 различных концовок
        if (hasHighEndGPU && hasHighEndCPU && hasWaterCooling)
        {
            Console.WriteLine("КОНЦОВКА 1: АБСОЛЮТНАЯ МОЩЬ\nВаш компьютер - это монстр производительности! Ни одна задача не сможет его остановить.");
        }
        else if (hasHighEndGPU && !hasHighEndCPU)
        {
            Console.WriteLine("КОНЦОВКА 2: ГЕЙМЕРСКИЙ КОМПРОМИСС\nОтличная видеокарта, но процессор мог бы быть мощнее. Идеально для игр в 4K!");
        }
        else if (!hasHighEndGPU && hasHighEndCPU)
        {
            Console.WriteLine("КОНЦОВКА 3: РАБОЧАЯ СТАНЦИЯ\nМощный процессор отлично подходит для работы, но для игр не хватает видеокарты.");
        }
        else if (hasRGB && hasExtraFans && hasAccessories)
        {
            Console.WriteLine("КОНЦОВКА 4: КОРОЛЕВСКИЙ СТИЛЬ\nВаш компьютер выглядит потрясающе с подсветкой и модными аксессуарами!");
        }
        else if (hasSoundCard && !hasHighEndGPU)
        {
            Console.WriteLine("КОНЦОВКА 5: АУДИОФИЛЬСКИЙ ВАРИАНТ\nИдеальный выбор для ценителей качественного звука!");
        }
        else if (hasNetworkCard && hasHighEndPSU)
        {
            Console.WriteLine("КОНЦОВКА 6: СЕРВЕРНЫЙ УРОВЕНЬ\nВаш ПК готов к круглосуточной работе и быстрой передаче данных.");
        }
        else if (budget > 800)
        {
            Console.WriteLine("КОНЦОВКА 7: ЭКОНОМНЫЙ СБОРЩИК\nВы уложились в бюджет и сохранили много денег для других покупок!");
        }
        else if (components.Count < 5)
        {
            Console.WriteLine("КОНЦОВКА 8: МИНИМАЛИСТИЧНЫЙ ПОДХОД\nВы собрали только самое необходимое, без излишеств.");
        }
        else if (hasSSD && !hasHighEndGPU && !hasHighEndCPU)
        {
            Console.WriteLine("КОНЦОВКА 9: ОФИСНЫЙ ВАРИАНТ\nБыстрый накопитель - главное достоинство вашей сборки. Отлично подходит для работы.");
        }
        else
        {
            Console.WriteLine("КОНЦОВКА 10: СБАЛАНСИРОВАННЫЙ ВЫБОР\nХорошая сборка без явных слабых мест. Надежный компьютер на все случаи жизни!");
        }
    }
}

class ComponentOption
{
    public string Name { get; }
    public int Price { get; }

    public ComponentOption(string name, int price)
    {
        Name = name;
        Price = price;
    }
}