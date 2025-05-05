using System;

public class MultiplicationWithValidation
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int number1, number2;
            bool isValidInput = true; 

            Console.WriteLine("Введите первое число (от 0 до 10):");
            if (!int.TryParse(Console.ReadLine(), out number1))
            {
                Console.WriteLine("Ошибка: Введите целое число.");
                isValidInput = false;
            }

            Console.WriteLine("Введите второе число (от 0 до 10):");
            if (!int.TryParse(Console.ReadLine(), out number2))
            {
                Console.WriteLine("Ошибка: Введите целое число.");
                isValidInput = false;
            }

            if (isValidInput && number1 >= 0 && number1 <= 10 && number2 >= 0 && number2 <= 10)
            {
                int result = number1 * number2;
                Console.WriteLine("Результат умножения: " + result);
                break;
            }
            else
            {
                if(isValidInput)
                {
                    Console.WriteLine("Введенные числа недопустимы. Пожалуйста, введите числа от 0 до 10.");
                }
            }
        }
    }
}