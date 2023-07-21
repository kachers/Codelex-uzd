using System;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
            Console.ReadKey();
        }

        static void First()
        {
            // can't change variable types.
            string a = "1";
            int b = 2;
            int c = 3;
            double d = 4;
            float e = 5;

            //fixme - should be 15 :|
            //int sum = a + b + c + d + e;
            //Console.WriteLine(sum);
        }

        static void Second()
        {
            // can't change variable types.
            string a = "1";
            int b = 2;
            int c = 3;
            double d = 4.2;
            float e = 5.3f;

            //fixme - should be 15.5 :| 
            //float sum = a + b + c + d + e;
            //Console.WriteLine(sum);
        }
    }
}
