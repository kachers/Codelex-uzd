namespace Exercise1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(IfEquals(-10, 25));
    }

    private static bool IfEquals(int a, int b)
    {
        if (a == 15 || b == 15 || a + b == 15 || a - b == 15)
            return true;
        return false;
    }
}