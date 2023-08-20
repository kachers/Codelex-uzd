namespace FuelConsumptionCalculator;

internal class Car
{
    private double _endKilometers;
    private double _liters;
    private readonly double _startKilometers;

    public Car(double startOdo, double endingOdo, double liters)
    {
        _startKilometers = startOdo;
        _endKilometers = endingOdo;
        _liters = liters;
    }

    public Car(double startOdo)
    {
        _startKilometers = startOdo;
        _endKilometers = 0;
        _liters = 0;
    }

    public void FillUp(int mileage, double litersFilled)
    {
        _liters += litersFilled;
        _endKilometers += mileage;
    }

    public double CalculateConsumption()
    {
        return _liters / (_endKilometers - _startKilometers) * 100;
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