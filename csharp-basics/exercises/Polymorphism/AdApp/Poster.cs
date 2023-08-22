namespace AdApp;

internal class Poster : Advert
{
    private readonly int _amountOfCoppies;
    private readonly double _costPerCoppy;
    private readonly int _dimnensions;
    private int _totalCostPoster;

    public Poster(int fee, int dimensions, int amountOfCoppies, double costPerCoppy) : base(fee)
    {
        _dimnensions = dimensions;
        _amountOfCoppies = amountOfCoppies;
        _costPerCoppy = costPerCoppy;
    }

    public override int Cost()
    {
        var fee = GetFee();
        _totalCostPoster += fee + _dimnensions * _amountOfCoppies * (int)_costPerCoppy;
        return _totalCostPoster;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}