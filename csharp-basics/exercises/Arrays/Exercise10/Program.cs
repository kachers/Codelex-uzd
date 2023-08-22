namespace Exercise10;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(CountPosSumNeg(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 }));
    }

    private static int[] CountPosSumNeg(int[] pos)
    {
        var posCount = 0;
        var negSum = 0;
        foreach (var i in pos)
        {
            if (i > 0) posCount++;
            else negSum += i;
        }
            

        if (posCount > 0 || negSum > 0)
        {
            int[] result = { posCount, negSum };
            return result;
        }

        var emptyArray = new int[0];
        return emptyArray;
    }
}