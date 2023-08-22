namespace AdApp;

public class TVAd : Advert
{
    private readonly bool _peak;
    private readonly int _rate;
    private readonly int _seconds;
    private int _totalCostTvAd;

    public TVAd(int fee, int seconds, int rate, bool peak) : base(fee)
    {
        _seconds = seconds;
        _rate = rate;
        _peak = peak;
    }

    public override int Cost()
    {
        var fee = GetFee();
        return _peak ? _totalCostTvAd += fee + _seconds * _rate * 2 : _totalCostTvAd += fee + _seconds * _rate;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}