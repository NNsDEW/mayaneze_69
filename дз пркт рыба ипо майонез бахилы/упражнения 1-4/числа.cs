using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите первое число (0-10): ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второе число (0-10): ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a >= 0 && a <= 10 && b >= 0 && b <= 10)
            {
                Console.WriteLine($"Результат умножения: {a * b}");
                break;
            }
            else
            {
                Console.WriteLine("Ошибка: числа должны быть в диапазоне от 0 до 10. Повторите ввод.");
            }
        }
    }
}