namespace Exercise9;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(BMIcondition(60, 185));
    }

    private static string BMIcondition(int weightKg, int heightCm)
    {
        var decision = "";
        var weightPounds = weightKg * 2.20462;
        var heightInches = heightCm * 0.393700787;
        var bmiIndex = weightPounds * 703 / Math.Pow(heightInches, 2);

        if (bmiIndex < 25 && bmiIndex > 18.5) decision = "You are sedentary!";
        if (bmiIndex > 25) decision = "You are overweight!";
        if (bmiIndex < 18.5) decision = "You are underweight!";
        Console.WriteLine(bmiIndex);
        return decision;
    }
}