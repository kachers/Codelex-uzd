namespace Exercise6;

internal class FizzBuzz
{
    private static void Main(string[] args)
    {
        int number;
        while (true)
        {
            Console.WriteLine("Provide a number :");
            var input = Console.ReadLine();
            if (int.TryParse(input, out number)) break;
            Console.WriteLine("Invalid input. Please enter a number.");
        }

        var counter = 0;
        for (var i = 1; i <= number; i++)
        {
            if (counter == 20)
            {
                Console.Write("\n");
                counter = 0;
            }

            if (i % 3 == 0 && i % 5 == 0) Console.Write("FizzBuzz ");
            else if (i % 5 == 0) Console.Write("Buzz ");
            else if (i % 3 == 0) Console.Write("Fizz ");
            else Console.Write(i + " ");
            counter++;
        }
    }
}