namespace Exercise3;

internal class Odometer
{
    public int Counter;
    public int CurrentMileage;
    public FuelGauge FuelGauge;

    public Odometer(FuelGauge fuelGauge, int mileage)
    {
        FuelGauge = fuelGauge;
        CurrentMileage = mileage;
        Counter = 0;
    }

    public int GetCurrentMileage()
    {
        return CurrentMileage;
    }

    public void IncrementMileage()
    {
        if (CurrentMileage == 999999) CurrentMileage = 0;
        CurrentMileage++;
        Counter++;
        DecrementFuel();
    }

    public void DecrementFuel()
    {
        if (Counter == 10)
        {
            FuelGauge.BurnFuel();
            Counter = 0;
        }
    }
}