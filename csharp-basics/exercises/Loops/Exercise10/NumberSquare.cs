using System;

namespace Exercise10
{
    internal class NumberSquare
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" NumberSquare ");
            int min;
            int max;

            while (true)
            {
                Console.WriteLine("Provide a min number :");
                var input = Console.ReadLine();
                if (int.TryParse(input, out min))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            while (true)
            {
                Console.WriteLine("Provide a max number :");
                var input = Console.ReadLine();
                if (int.TryParse(input, out max))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine($"Min? {min}");
            Console.WriteLine($"Max? {max}");

            List<int> numbers = new List<int>();

            for (int i = min; i <= max; i++) numbers.Add(i);

            for (int i = 0; i < numbers.Count; i++)
            {
                for (var j = 0; j < numbers.Count; j++)
                {
                    Console.Write(numbers[j]);
                    if (numbers[j] == max) numbers[j] = min;
                    else numbers[j]++;
                    
                }

                Console.WriteLine();
            }
        }
    }
}