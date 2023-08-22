using System.Collections.Generic;
using System.Linq;

namespace AdApp;

public class Campaign
{
    private readonly List<Advert> _campaign;

    public Campaign()
    {
        _campaign = new List<Advert>();
    }

    public void AddAdvert(Advert a)
    {
        _campaign.Add(a);
        a.AdType = a.GetType().Name;
    }

    public int GetCost()
    {
        return _campaign.Sum(item => item.Cost());
    }

    public override string ToString()
    {
        return $"Advert Campaign {string.Join("", _campaign)} \nTotal Campaign Cost = {GetCost():C0}";
    }
}