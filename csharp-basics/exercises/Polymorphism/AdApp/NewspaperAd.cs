namespace AdApp;

public class NewspaperAd : Advert
{
    private readonly int _column;
    private readonly int _rate;
    private int _totalCostNewspaperAd;

    public NewspaperAd(int fee, int column, int rate) : base(fee)
    {
        _column = column;
        _rate = rate;
    }

    public override int Cost()
    {
        var fee = GetFee();
        _totalCostNewspaperAd += fee + _column * _rate;
        return _totalCostNewspaperAd;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}