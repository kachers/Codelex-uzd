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
        const int maxPricePerDay = 2000;
        decimal rentalPrice = 0;
        var scooter = _scooterService.GetScooterById(id);
        var rentedScooter = _rentalRecordsService.StopRent(scooter.Id, DateTime.Now);
        var rentEndDate = rentedScooter.RentEnd ?? DateTime.MinValue;
        scooter.IsRented = false;

        Debug.Assert(rentedScooter != null, nameof(rentedScooter) + " != null");
        if (rentEndDate.Date == rentedScooter.RentStart.Date)
        {
            TimeSpan rentalDurationMinutes = (TimeSpan)(rentEndDate - rentedScooter.RentStart);

            if ((int)rentalDurationMinutes.TotalMinutes * scooter.PricePerMinute >= maxPricePerDay)
            {
                rentalPrice += maxPricePerDay;
            }
            else
            {
                for (var i = 0; i < (int)rentalDurationMinutes.TotalMinutes; i++)
                {
                    rentalPrice += scooter.PricePerMinute;
                }
            }
        }
        else
        {
            var rentDuration = rentEndDate.Date - rentedScooter.RentStart.Date;
            var durationInDays = rentDuration.Days - 1;
            var minutesUsedInFirstDay = minutesInOneDay - rentedScooter.RentStart.TimeOfDay.TotalMinutes;
            //var minutesUsedInFirstDay = (int)(rentEndDate - rentedScooter.RentStart).TotalMinutes;
            var minutesUsedInLastDay = rentEndDate.TimeOfDay.TotalMinutes;//rentEndDate.TimeOfDay.TotalMinutes;

            if (minutesUsedInFirstDay * (double)scooter.PricePerMinute >= maxPricePerDay)
            {
                rentalPrice += maxPricePerDay;
            }
            else
            {
                for (var i = 0; i < minutesUsedInFirstDay; i++)
                {
                    rentalPrice += scooter.PricePerMinute;
                }
            }

            if (minutesUsedInLastDay * (double)scooter.PricePerMinute >= maxPricePerDay)
            {
                rentalPrice += maxPricePerDay;
            }
            else
            {
                for (var i = 0; i <= (int)minutesUsedInLastDay; i++)
                {
                    rentalPrice += scooter.PricePerMinute;
                }
            }
            
            if (durationInDays > 2 && minutesInOneDay * scooter.PricePerMinute >= maxPricePerDay)
            {
                rentalPrice += durationInDays * maxPricePerDay;
            }
            else
            {
                rentalPrice += durationInDays * minutesInOneDay * scooter.PricePerMinute;
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
            var incomeForAllRentals = rentedScooters
                .Where(s => s.RentStart.Year == year)
                .Sum(s => EndRent(s.Id));

            return incomeForAllRentals;
        }

        if (year.HasValue && !includeNotCompletedRentals)
        {
            var yearMatchScooters = rentedScooters.Where(s => s.RentStart.Year == year).ToList();

            var finishedScooters = yearMatchScooters.Where(s =>!_scooterService.GetScooterById(s.Id).IsRented).ToList();

            var incomeForFinishedRentals = finishedScooters.Sum(s => EndRent(s.Id));

            /*var incomeForFinishedRentals = rentedScooters
                .Where(s => s.RentStart.Year == year && s.RentEnd.HasValue)
                .Sum(s => EndRent(s.Id));
            */

            return incomeForFinishedRentals;
        }

        if (!year.HasValue && includeNotCompletedRentals)
        {
            var incomeForAllRental = rentedScooters.Sum(s => EndRent(s.Id));

            return incomeForAllRental;
        }

        var finishedScootersList = rentedScooters.Where(s => !_scooterService.GetScooterById(s.Id).IsRented).ToList();

        return finishedScootersList.Sum(s => EndRent(s.Id)); ; //rentedScooters.Where(s => s.RentEnd.HasValue).Sum(s => EndRent(s.Id));
    }
}