namespace Exercise4;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Product1ToN(10));
    }

    private static int Product1ToN(int n)
    {
        var result = 1;
        for (var i = 1; i <= n; i++) result = result * i;

        return result;
    }
}