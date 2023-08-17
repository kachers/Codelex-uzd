using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Exercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number.");
            var number = Console.ReadLine();
            var tempNumber = number;

            do
            {
                var numbers = tempNumber.ToCharArray();
                double sum = 0;
                foreach (var num in numbers)
                {
                    sum += Math.Pow(char.GetNumericValue(num), 2);
                }

                tempNumber = sum.ToString();
            } while (tempNumber != "4" && tempNumber != "1");

            Console.WriteLine(tempNumber == "1" ? "happy" : "not happy");
            Console.ReadKey();
        }
    }
}