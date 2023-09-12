using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace ScooterRental;

public class RentalCompany : IRentalCompany
{
    private readonly IScooterService _scooterService;
    private readonly IRentalRecordsService _rentalRecordsService;
    public RentalCompany(string name, IScooterService scooterService, IRentalRecordsService rentalRecordsService)
    {
        Name = name;
        _scooterService = scooterService;
        _rentalRecordsService = rentalRecordsService;
    }
    public string Name { get; }
    public void StartRent(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new InvalidIdException();
        }

        if (_scooterService.GetScooterById(id) == null)
        {
            throw new ScooterIdDoesNotExistException();
        }
        var scooter = _scooterService.GetScooterById(id);
        scooter.IsRented = true;
        _rentalRecordsService.StartRent(scooter.Id, DateTime.Now);
    }

    public decimal EndRent(string id)
    {
        const int minutesInOneDay = 24 * 60;
        const int dailyMax = 2000;
        decimal rentalPrice = 0;
        var scooter = _scooterService.GetScooterById(id);
        var minutePrice = (decimal)scooter.PricePerMinute;
        var rentedScooter = _rentalRecordsService.StopRent(scooter.Id, DateTime.Now);
        var rentEndDate = rentedScooter.RentEnd ?? DateTime.MinValue;
        scooter.IsRented = false;

        Debug.Assert(rentedScooter != null, nameof(rentedScooter) + " != null");
        if (rentEndDate.Date == rentedScooter.RentStart.Date)
        {
            TimeSpan rentMinutes = (TimeSpan)(rentEndDate - rentedScooter.RentStart);

            if ((int)rentMinutes.TotalMinutes * minutePrice >= dailyMax)
            {
                rentalPrice += dailyMax;
            }
            else
            {
                for (var i = 0; i < (int)rentMinutes.TotalMinutes; i++)
                {
                    rentalPrice += minutePrice;
                }
            }
        }
        else
        {
            var rentDuration = rentEndDate.Date - rentedScooter.RentStart.Date;
            var minutesInFirstDay = (decimal)minutesInOneDay - (decimal)rentedScooter.RentStart.TimeOfDay.TotalMinutes;
            var minutesInLastDay = (decimal)rentEndDate.TimeOfDay.TotalMinutes;

            if (minutesInFirstDay * minutePrice >= dailyMax)
            {
                rentalPrice += dailyMax;
            }
            else
            {
                for (var i = 0; i < minutesInFirstDay; i++)
                {
                    rentalPrice += minutePrice;
                }
            }

            if (minutesInLastDay * minutePrice >= dailyMax)
            {
                rentalPrice += dailyMax;
            }
            else
            {
                for (var i = 0; i <= (int)minutesInLastDay; i++)
                {
                    rentalPrice += minutePrice;
                }
            }
            
            if ((rentDuration.Days - 1) > 2 && minutesInOneDay * minutePrice >= dailyMax)
            {
                rentalPrice += (rentDuration.Days - 1) * dailyMax;
            }
            else
            {
                rentalPrice += (rentDuration.Days - 1) * minutesInOneDay * minutePrice;
            }
        }

        return Math.Round(rentalPrice, 2);
    }

    public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
    {
        var rentedScooters = _rentalRecordsService.GetScooters();

        if (rentedScooters == null)
        {
            throw new InvalidIdException();
        }

        if (year.HasValue && includeNotCompletedRentals)
        {
            return rentedScooters
                .Where(s => s.RentStart.Year == year)
                .Sum(s => EndRent(s.Id));
        }

        if (year.HasValue && !includeNotCompletedRentals)
        {
            return rentedScooters
                .Where(s => s.RentStart.Year == year)
                .Where(s => !_scooterService.GetScooterById(s.Id).IsRented)
                .Sum(s => EndRent(s.Id)); 
        }

        if (!year.HasValue && includeNotCompletedRentals)
        {
            return rentedScooters.Sum(s => EndRent(s.Id)); 
        }

        return rentedScooters
            .Where(s => !_scooterService.GetScooterById(s.Id).IsRented)
            .Sum(s => EndRent(s.Id));
    }
}