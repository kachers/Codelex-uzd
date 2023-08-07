namespace Exercise11;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(MoranOrNot(134));
    }

    private static string MoranOrNot(int n)
    {
        var nSum = 0;
        var result = "";
        var nString = n.ToString();

        for (var i = 0; i < nString.Length; i++) nSum += int.Parse(nString[i].ToString());

        if (n % nSum != 0) result = "Neither";
        else
            for (var i = 2; i <= Math.Sqrt(nSum); i++)
                if (n / nSum % i == 0) result = "H";

                else result = "M";

        return result;
    }
}