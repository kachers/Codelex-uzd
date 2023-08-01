using System;

namespace TenBillion;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Input an integer number less than ten billion: ");

        var input = Console.ReadLine();
        var number = Math.Abs(int.Parse(input));
        var result = number.ToString().Length;

        Console.WriteLine(result);
    }
}