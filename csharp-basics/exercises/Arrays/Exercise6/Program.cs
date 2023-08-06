namespace Exercise6;

internal class Program
{
    private static void Main(string[] args)
    {
        var tenInt = new int[10];
        var tenIntCopy = new int[10];
        for (var i = 0; i < tenInt.Length; i++)
        {
            Random random = new();
            tenInt[i] = random.Next(1, 100);
        }

        for (var i = 0; i < tenInt.Length; i++)
        {
            tenIntCopy[i] = tenInt[i];
        }

        tenInt[tenInt.Length - 1] = -7;
        Console.WriteLine($"Array 1:{string.Join(" ", tenInt)}");
        Console.WriteLine($"Array 2:{string.Join(" ", tenIntCopy)}");
    }
}