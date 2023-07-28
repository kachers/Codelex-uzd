namespace Exercise2;

internal class Program
{
    private static void Main(string[] args)
    {
        CheckOddEven(10);
    }

    private static void CheckOddEven(int number)
    {
        if (number % 2 != 0)
            Console.WriteLine("Odd Number");
        else
            Console.WriteLine("Even Number");

        Console.WriteLine("bye!");
    }
}