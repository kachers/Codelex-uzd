using System;

namespace MoreVariablesAndPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Zed A. Shaw";
            int age = 35;
            int height = 74;  // inches                    
            int weight = 180; // lbs          
            string eyes = "Blue";
            string teeth = "White";
            string hair = "Brown";
            double heightConverted = Math.Round((double)height*2.54,2); // centimeters
            double weightConverted = Math.Round((double)weight* 0.453592,2); // kilograms

            Console.WriteLine("Let's talk about " + name + ".");
            Console.WriteLine("He's " + height + " inches tall.");
            Console.WriteLine("He's " + weight + " pounds heavy.");
            Console.WriteLine("Actually, that's not too heavy.");
            Console.WriteLine("He's got " + eyes + " eyes and " + hair + " hair.");
            Console.WriteLine("His teeth are usually " + teeth + " depending on the coffee.");

            Console.WriteLine("If I add " + age + ", " + height + ", and " + weight
                               + " I get " + (age + height + weight) + ".");

            Console.ReadKey();
        }
    }
}