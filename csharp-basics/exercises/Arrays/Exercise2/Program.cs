using System;

namespace Exercise2
{
    class Program
    {  
        private static void Main(string[] args)
        {
            var sum = 0;

            Console.WriteLine("Please enter a min number");
            var minNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a max number");
            var maxNumber = int.Parse(Console.ReadLine());

            for (var i = minNumber; i <= maxNumber; i++) sum++;

            Console.WriteLine("The sum is " + sum);
            Console.ReadKey();
        }
    }
}
