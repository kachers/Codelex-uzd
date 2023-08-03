using System;

namespace Exercise4
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] myArray =
            {
                1789, 2035, 1899, 1456, 2013,
                1458, 2458, 1254, 1472, 2365,
                1456, 2265, 1457, 2456
            };

            var number = 1245;
            for(var i=0; i< myArray.Length; i++)
            {
                if (myArray[i] == number) Console.WriteLine("Contains!");
            }
        }
    }
}
    