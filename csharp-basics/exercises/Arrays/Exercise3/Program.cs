using System;

namespace Exercise3;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = { 20, 30, 25, 35, -16, 60, -100 };
        var sum = 0;

        for (var i = 0; i < numbers.Length; i++) sum = sum + numbers[i];

        var average = (double)sum / numbers.Length;
        Console.WriteLine("Average value of the array elements is : " + average);
    }
}