using System;

namespace Exercise4;

internal class Program
{
    private static void Main(string[] args)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        for (var i = 0; i < vowels.Length; i++) Console.WriteLine(vowels[i]);

        foreach (var c in vowels) Console.WriteLine(c);
    }
}