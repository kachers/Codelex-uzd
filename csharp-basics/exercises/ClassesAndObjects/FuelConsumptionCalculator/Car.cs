namespace FuelConsumptionCalculator;

internal class Car
{
    public double EndKilometers;
    public double Liters;
    public double StartKilometers;

    public Car(double startOdo, double endingOdo, double liters)
    {
        StartKilometers = startOdo;
        EndKilometers = endingOdo;
        Liters = liters;
    }

    public Car(double startOdo)
    {
        StartKilometers = startOdo;
        EndKilometers = 0;
        Liters = 0;
    }

    public void FillUp(int mileage, double litersFilled)
    {
        Liters += litersFilled;
        EndKilometers += mileage;
    }

    public double CalculateConsumption()
    {
        return Liters / (EndKilometers - StartKilometers) * 100;
    }

    public bool IsGasHog()
    {
        var consumption = CalculateConsumption();
        return consumption > 15;
    }

    public bool IsEconomyCar()
    {
        var consumption = CalculateConsumption();
        return consumption < 5;
    }
}