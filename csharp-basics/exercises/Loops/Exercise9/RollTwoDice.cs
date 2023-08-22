using System.Diagnostics.CodeAnalysis;

namespace Exercise9
{
    internal class RollTwoDice
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RollTwoDice!\n");
            int userNumber;

            while (true)
            {
                Console.WriteLine("Provide desired sum :");
                var input = Console.ReadLine();
                if (int.TryParse(input, out userNumber))
                {
                    if (userNumber > 1 && userNumber < 13) break;
                }

                Console.WriteLine("Invalid input. Please enter a number from 2 to 12.");
            }

            Console.WriteLine($"Desired sum: {userNumber}");
            var sum =0;
            Random random = new Random();

            while(sum != userNumber)
            {
                var num1 = random.Next(1,7);
                var num2 = random.Next(1,7);
                sum = num1 + num2;
                Console.WriteLine($"{num1} and {num2} = {sum}");
            }
        }
    }
}