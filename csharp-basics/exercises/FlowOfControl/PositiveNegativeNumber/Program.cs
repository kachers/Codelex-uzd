using System;

namespace PositiveNegativeNumber;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the number.");
        var input = Console.ReadKey();
        var number = int.Parse(input.KeyChar.ToString());

        if (number > 0)
            Console.WriteLine("Number is positive");
        else if (number < 0)
            Console.WriteLine("Number is negative");
        else
            Console.WriteLine("Number is zero");
    }
}