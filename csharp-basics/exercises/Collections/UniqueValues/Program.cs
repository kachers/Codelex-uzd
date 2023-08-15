using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueValues
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var values = new List<string> { "Hi", "Meow", "Hello", "Meow", "Hi!", "Meow", "Hi", "Bye" };
            var result = (from value in values
                let count = values.Count(str => str == value)
                where count == 1
                select value).ToList();
            Console.WriteLine(string.Join(",", result));
        }
    }
}