using System;

namespace LargestNumber;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Input the 1st number: ");
        var input1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Input the 2nd number: ");
        var input2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Input the 3rd number: ");
        var input3 = int.Parse(Console.ReadLine());

        Console.WriteLine(LargestNr(input1, input2, input3));
    }

    private static int LargestNr(int inputA, int inputB, int inputC)
    {
        if (inputA > inputB && inputA > inputC) return inputA;
        if (inputA < inputB && inputB > inputC) return inputB;
        return inputC;
    }
}