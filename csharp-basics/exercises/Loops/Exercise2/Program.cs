using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n, baseNumber;

            while (true)
            {
                Console.WriteLine("Input number of terms : ");
                var input =Console.ReadLine();
                if (int.TryParse(input, out n)) break;
                else Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            while (true)
            {
                Console.WriteLine("Input base number : ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out baseNumber)) break;
                else Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            
            int result = 1;
            for (i = 0; i < n; i++)
            {
                result *= baseNumber;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
