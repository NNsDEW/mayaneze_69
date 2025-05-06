using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = Convert.ToInt16(Console.ReadLine());
            int b = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            if (b == 0)
            {
                Console.WriteLine("Деление на ноль!");
                Console.WriteLine("Деление на ноль!");
            }
            else
            {
                Console.WriteLine(a % b);
                Console.WriteLine(a / b);
                
            }
            Console.WriteLine(a * b);
            
        }
    }
}
