namespace Exercise5;

internal class Program
{
    private static void Main(string[] args)
    {
        var lineLength = 30;
        Console.WriteLine("Enter first word: ");
        var firstWord = Console.ReadLine();
        Console.WriteLine("Enter second word: ");
        var secondWord = Console.ReadLine();

        var numberOfDots = lineLength - (firstWord.Length + secondWord.Length);

        Console.Write(firstWord);
        for (var i = 0; i < numberOfDots; i++) Console.Write(".");
        Console.Write(secondWord);
    }
}