namespace Exercise3;

public class Odometer
{
    public int counter;
    public int CurrentMileage;
    public FuelGauge fuelgauge;

    public Odometer(FuelGauge fuelGauge, int mileage)
    {
        fuelgauge = fuelGauge;
        CurrentMileage = mileage;
        counter = 0;
    }

    public int GetCurrentMileage()
    {
        return CurrentMileage;
    }

    public void IncrementMileage()
    {
        if (CurrentMileage == 999999) CurrentMileage = 0;
        CurrentMileage++;
        counter++;
        DecrementFuel();
    }

    public void DecrementFuel()
    {
        if (counter == 10)
        {
            fuelgauge.BurnFuel();
            counter = 0;
        }
    }
}