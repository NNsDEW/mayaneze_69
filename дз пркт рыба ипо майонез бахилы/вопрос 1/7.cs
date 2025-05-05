Console.WriteLine("Введите номер операции: 1.Сложение 2.Вычитание 3.Умножение");
int operation = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите первое число: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Введите второе число: ");
double num2 = Convert.ToDouble(Console.ReadLine());

switch (operation)
{
    case 1:
        Console.WriteLine($"Результат: {num1 + num2}");
        break;
    case 2:
        Console.WriteLine($"Результат: {num1 - num2}");
        break;
    case 3:
        Console.WriteLine($"Результат: {num1 * num2}");
        break;
    default:
        Console.WriteLine("Операция не определена");
        break;
}