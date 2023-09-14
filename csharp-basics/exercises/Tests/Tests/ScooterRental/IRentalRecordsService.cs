namespace ScooterRental;

public interface IRentalRecordsService
{
    void StartRent(string id, DateTime rentStart);
    RentedScooter StopRent(string id, DateTime rentEnd);
    IList<RentedScooter> GetScooters();
    RentedScooter GetScooterById(string scooterId);
}