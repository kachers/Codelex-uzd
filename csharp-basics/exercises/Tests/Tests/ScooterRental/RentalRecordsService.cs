namespace ScooterRental;

public class RentalRecordsService : IRentalRecordsService
{
    private readonly List<RentedScooter> _rentedScooterList;

    public RentalRecordsService(List<RentedScooter> rentedScooterList)
    {
        _rentedScooterList = rentedScooterList;
    }

    public void StartRent(string id, DateTime rentStart)
    {
        _rentedScooterList.Add(new RentedScooter(id, DateTime.Now));
    }

    public RentedScooter StopRent(string id, DateTime rentEnd)
    {
        var rentalRecord = _rentedScooterList
            .FirstOrDefault(s => s.Id == id && !s.RentEnd.HasValue);
        rentalRecord.RentEnd = rentEnd;

        return rentalRecord;
    }

    public IList<RentedScooter> GetScooters()
    {
        return _rentedScooterList.ToList();
    }

    public RentedScooter GetScooterById(string scooterId)
    {
        var scooter = _rentedScooterList.FirstOrDefault(s => s.Id == scooterId);

        if (string.IsNullOrEmpty(scooterId))
        {
            throw new InvalidIdException();
        }

        if (scooter == null)
        {
            throw new ScooterIdDoesNotExistException();
        }

        return scooter;
    }
}