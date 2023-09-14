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
        if (_rentedScooterList.Any(s => s.Id == id)) throw new ScooterAlreadyRentedOutException();

        if (string.IsNullOrEmpty(id)) throw new InvalidIdException();

        _rentedScooterList.Add(new RentedScooter(id, rentStart));
    }

    public RentedScooter StopRent(string id, DateTime rentEnd)
    {
        if (string.IsNullOrEmpty(id)) throw new InvalidIdException();

        if (!_rentedScooterList.Any(s => s.Id == id)) throw new ScooterIdDoesNotExistException();

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

        if (string.IsNullOrEmpty(scooterId)) throw new InvalidIdException();

        if (scooter == null) throw new ScooterIdDoesNotExistException();

        return scooter;
    }
}