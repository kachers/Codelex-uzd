namespace Exercise8;

internal class AsciiFigure
{
    private static void Main(string[] args)
    {
        const int input = 7;
        const int rowGrowth = 8;
        const int totalWidth = input * rowGrowth - rowGrowth;
        var growthSum = 0;

        for (var i = 0; i < input; i++)
        {
            var escCharSize = totalWidth / 2 - growthSum / 2;
            var backslashSize = totalWidth / 2 - growthSum / 2;
            Console.Write(new string('/', backslashSize));
            Console.Write(new string('*', growthSum));
            Console.Write(new string('\\', escCharSize) + "\n");
            growthSum += rowGrowth;
        }
    }
}