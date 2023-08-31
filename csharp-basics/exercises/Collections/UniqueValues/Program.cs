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
           
            var result = values.GroupBy(value => value).Where(group => group.Count() == 1).ToList();
            foreach (var group in result)
            {
                Console.WriteLine(string.Join(",", group.Key));
            }
        }
    }
}