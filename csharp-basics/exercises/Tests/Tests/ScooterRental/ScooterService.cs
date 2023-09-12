using System.Data;

namespace ScooterRental;

public class ScooterService : IScooterService
{
    private readonly List<Scooter> _scooters;
    public ScooterService(List<Scooter> scooterStorage)
    {
        _scooters = scooterStorage;
    }
    public void AddScooter(string id, decimal pricePerMinute)
    {
        if (_scooters.Any(s => s.Id == id))
        {
            throw new DuplicateScooterException();
        }

        if (pricePerMinute <= 0)
        {
            throw new NegativePriceException();
        }

        if (string.IsNullOrEmpty(id))
        {
            throw new InvalidIdException();
        }

        _scooters.Add(new Scooter(id, pricePerMinute));
    }

    public Scooter GetScooterById(string scooterId)
    {
        var scooter = _scooters.FirstOrDefault(s => s.Id == scooterId);

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

    public IList<Scooter> GetScooters()
    {
        return _scooters.ToList();
    }

    public void RemoveScooter(string id)
    {
        var scooter = _scooters.FirstOrDefault(s => s.Id.Equals(id)); 

        if (string.IsNullOrEmpty(id))
        {
            throw new InvalidIdException();
        }

        if (scooter == null)
        {
            throw new ScooterIdDoesNotExistException();
        }

        if (scooter.IsRented)
        {
            throw new CannotRemoveScooterWhileItIsRentedOutException();
        }

        _scooters.Remove(scooter);
    }
}