namespace Exercise5;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("I'm thinking of a number between 1-100.  Try to guess it.");
        var rnd = new Random();
        var number = rnd.Next(1, 100);
        var input = int.Parse(Console.ReadLine());

        if (input == number) Console.WriteLine("You guessed it!  What are the odds?!?");
        else if (input > number) Console.WriteLine($"Sorry, you are too high.  I was thinking of {number}.");
        else Console.WriteLine($"Sorry, you are too low.  I was thinking of {number}.");
    }
}