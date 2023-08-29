namespace Exercise3;

internal class Program
{
    private static void Main(string[] args)
    {
        var fuelGauge = new FuelGauge();
        fuelGauge.FillUp(3);

        var odometer = new Odometer(fuelGauge, 0);

        while (true)
            if (fuelGauge.FuelAmount > 0)
            {
                odometer.IncrementMileage();
                Console.WriteLine($"Current mileage is: {odometer.GetCurrentMileage()}" +
                                  $"\nLiters left : {fuelGauge.GetFuelAmount()}.");
            }
            else
            {
                Console.WriteLine($"We are out of fuel. Exactly {fuelGauge.GetFuelAmount()} liters " +
                                  $"left in fuel gauge.");
                break;
            }
    }
}