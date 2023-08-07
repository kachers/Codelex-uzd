using System;

namespace SumAverageRunningInt;

internal class Program
{
    private static void Main(string[] args)
    {
        var sum = 0;
        const int lowerBound = 1;
        const int upperBound = 100;
        var average = (double)(lowerBound + upperBound) / 2;

        for (var number = lowerBound; number <= upperBound; ++number) sum += number;

        Console.WriteLine($"The sum of {lowerBound} to {upperBound} is {sum}\r\nThe average is {average}");
    }
}