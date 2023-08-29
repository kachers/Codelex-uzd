namespace Exercise3;

internal class FuelGauge
{
    private int _fuelAmount;

    public FuelGauge()
    {
        _fuelAmount = 0;
    }

    public int GetFuelAmount()
    {
        return _fuelAmount;
    }

    public void FillUp(int amount)
    {
        _fuelAmount += amount;
    }

    public int BurnFuel()
    {
        return _fuelAmount--;
    }
}