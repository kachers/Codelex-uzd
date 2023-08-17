using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "VolksWagen", "Mercedes", "Tesla" };

            List<string> list = new();
            list.AddRange(array);
            Console.WriteLine(string.Join(",",list));

            HashSet<string> stringSet = new();
            
            foreach (var t in array) stringSet.Add(t);

            Console.WriteLine(string.Join(",", stringSet));

            Dictionary<string,string> carDictionary = new() 
            {
                { "Audi", "Germany" },
                { "BMW", "Germany" },
                { "Honda", "Japan" },
                { "Mercedes", "Germany" },
                { "VolksWagen", "Germany" },
                { "Tesla", "USA" }
            };

            foreach (var kvp in carDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
