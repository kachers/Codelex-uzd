namespace Exercise3;

public class FuelGauge
{
    public int FuelAmount;

    public FuelGauge()
    {
        FuelAmount = 0;
    }

    public int GetFuelAmount()
    {
        return FuelAmount;
    }

    public void FillUp(int amount)
    {
        FuelAmount += amount;
    }

    public int BurnFuel()
    {
        return FuelAmount--;
    }
}