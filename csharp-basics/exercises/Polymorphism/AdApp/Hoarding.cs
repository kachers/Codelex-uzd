namespace AdApp;

public class Hoarding : Advert
{
    private readonly int _numDays;
    private readonly int _rate;
    private int _totalCostHoarding;

    public Hoarding(int fee, int rate, int numDays) : base(fee)
    {
        _rate = rate;
        _numDays = numDays;
    }

    public override int Cost()
    {
        var fee = GetFee();
        _totalCostHoarding += fee + _rate * _numDays;
        return _totalCostHoarding;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}