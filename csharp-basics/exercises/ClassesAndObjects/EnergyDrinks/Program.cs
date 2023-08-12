using System;

namespace EnergyDrinks;

internal class Program
{
    private const int NumberedSurveyed = 12467;
    private const double PurchasedEnergyDrinks = 0.14;
    private const double PreferCitrusDrinks = 0.64;
    private static readonly double energyDrinkers = CalculateEnergyDrinkers(NumberedSurveyed);
    private static readonly double preferCitrus = CalculatePreferCitrus(NumberedSurveyed);

    private static void Main(string[] args)
    {
        Console.WriteLine("Total number of people surveyed " + NumberedSurveyed);
        Console.WriteLine("Approximately " + energyDrinkers + " bought at least one energy drink");
        Console.WriteLine(preferCitrus + " of those " + "prefer citrus flavored energy drinks.");
    }

    public static double CalculateEnergyDrinkers(int numberSurveyed)
    {
        var energyDrinkers = NumberedSurveyed * PurchasedEnergyDrinks;
        return energyDrinkers;
    }

    public static double CalculatePreferCitrus(int numberSurveyed)
    {
        var preferCitrus = NumberedSurveyed * PreferCitrusDrinks;
        return preferCitrus;
    }
}