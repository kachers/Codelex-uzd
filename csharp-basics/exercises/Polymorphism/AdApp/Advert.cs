namespace AdApp;

public class Advert
{
    private int _fee;

    public Advert()
    {
        _fee = 0;
    }

    public Advert(int fee)
    {
        _fee = fee;
    }

    public string AdType { get; set; }

    public void SetFee(int fee)
    {
        _fee = fee;
    }

    public int GetFee()
    {
        return _fee;
    }

    public virtual int Cost()
    {
        return _fee;
    }

    public override string ToString()
    {
        return $"\nAdvert: {AdType} Fee =  {_fee:C0}  \nTotal {AdType} cost= {Cost():C0}";
    }
}