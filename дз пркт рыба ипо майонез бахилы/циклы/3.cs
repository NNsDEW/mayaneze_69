using System;

public class MultiplicationTable
{
    public static void Main(string[] args)
    {
        int tableSize = 10;
        Console.Write("   |");
        for (int i = 1; i <= tableSize; i++)
        {
            Console.Write($"{i,3}");
        }
        Console.WriteLine();
        Console.WriteLine("---+-------------------------------");

        for (int i = 1; i <= tableSize; i++)
        {
            Console.Write($"{i,2} |");
            for (int j = 1; j <= tableSize; j++)
            {
                Console.Write($"{i * j,3}");
            }
            Console.WriteLine();
        }
    }
}

