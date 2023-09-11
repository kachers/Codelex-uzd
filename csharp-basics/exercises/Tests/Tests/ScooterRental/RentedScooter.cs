namespace ScooterRental;

public class RentedScooter
{
    public RentedScooter(string id, DateTime startTime)
    {
        Id = id;
        RentStart = startTime;
        PricePerMinute = 0;
    }
    public double PricePerMinute { get; }
    public string Id { get; }
    public DateTime RentStart { get; }
    public DateTime? RentEnd { get; set; }
}