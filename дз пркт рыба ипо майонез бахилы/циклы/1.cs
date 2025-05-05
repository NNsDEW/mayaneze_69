using System;

public class BankDepositCalculator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите сумму вклада:");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Введите количество месяцев:");
        int numberOfMonths = int.Parse(Console.ReadLine());

        decimal currentAmount = depositAmount;

        for (int i = 0; i < numberOfMonths; i++)
        {
            decimal interest = currentAmount * 0.07m;
            currentAmount += interest;
        }

        Console.WriteLine("Конечная сумма вклада: " + currentAmount);
    }
}
