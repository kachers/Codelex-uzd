namespace Exercise3;

internal class Odometer
{
    private int _counter;
    private int _currentMileage;
    private readonly FuelGauge _fuelGauge;

    public Odometer(FuelGauge fuelGauge, int mileage)
    {
        _fuelGauge = fuelGauge;
        _currentMileage = mileage;
        _counter = 0;
    }

    public int GetCurrentMileage()
    {
        return _currentMileage;
    }

    public void IncrementMileage()
    {
        if (_currentMileage == 999999) _currentMileage = 0;
        _currentMileage++;
        _counter++;
        DecrementFuel();
    }

    public void DecrementFuel()
    {
        if (_counter == 10)
        {
            _fuelGauge.BurnFuel();
            _counter = 0;
        }
    }
}