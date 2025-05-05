Console.Write("Введите сумму вклада: ");
double deposit = Convert.ToDouble(Console.ReadLine());
double percent = 0;

if (deposit < 100)
    percent = 0.05;
else if (deposit <= 200)
    percent = 0.07;
else
    percent = 0.10;

double total = deposit * (1 + percent);
Console.WriteLine($"Сумма вклада с процентами: {total}");