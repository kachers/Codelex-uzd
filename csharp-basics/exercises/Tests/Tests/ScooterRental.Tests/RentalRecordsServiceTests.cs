using FluentAssertions;

namespace ScooterRental.Tests;

[TestClass]
public class RentalRecordsService_Tests
{
    private IRentalRecordsService _rentalRecordsService;
    private List<RentedScooter> _rentedScooterList;
    private const string DEFAULT_SCOOTE_ID = "1";

    [TestInitialize]
    public void Setup()
    {
        _rentedScooterList = new List<RentedScooter>();
        _rentalRecordsService = new RentalRecordsService(_rentedScooterList);
    }

    [TestMethod]
    public void StartRent_WithIdAndDate_ScooterAddedToList()
    {
        _rentalRecordsService.StartRent(DEFAULT_SCOOTE_ID, DateTime.Now);

        _rentedScooterList.Count.Should().Be(1);
    }

    [TestMethod]
    public void StartRent_WithDefaultId_ScooterAddedWithDefaultIdAndCorrectDateTime()
    {
        _rentalRecordsService.StartRent(DEFAULT_SCOOTE_ID, DateTime.Now);

        _rentedScooterList.First().Id.Should().Be(DEFAULT_SCOOTE_ID);
        _rentedScooterList.First().RentStart.Should().BeBefore(DateTime.Now);
    }

    [TestMethod]
    public void StartRent_WithDuplicatedScooterId_ShouldThrowScooterAlreadyRentedOutException()
    {
        _rentedScooterList.Add(new RentedScooter(DEFAULT_SCOOTE_ID, DateTime.Now));

        Action action = () => _rentalRecordsService.StartRent(DEFAULT_SCOOTE_ID, DateTime.Now);

        action.Should().Throw<ScooterAlreadyRentedOutException>();
    }

    [TestMethod]
    public void StartRent_StartRentWithEmptyId_ThrowsInvalidIdException()
    {
        Action action = () => _rentalRecordsService.StartRent(string.Empty, DateTime.Now);

        action.Should().Throw<InvalidIdException>();
    }

    [TestMethod]
    public void StopRent_StopRentWithEmptyId_ThrowsInvalidIdException()
    {
        Action action = () => _rentalRecordsService.StartRent(string.Empty, DateTime.Now);

        action.Should().Throw<InvalidIdException>();
    }

    [TestMethod]
    public void StopRent_StopRentWithWrongId_ThrowsScooterIdDoesNotExistException()
    {
        _rentedScooterList.Add(new RentedScooter(DEFAULT_SCOOTE_ID, DateTime.Now));

        Action action = () => _rentalRecordsService.StopRent("Wrong Id", DateTime.Now);

        action.Should().Throw<ScooterIdDoesNotExistException>();
    }

    [TestMethod]
    public void GetScooterById_GetScooterWithDefaultId_ReturnsScooterWithDefaultId()
    {
        _rentedScooterList.Add(new RentedScooter(DEFAULT_SCOOTE_ID, DateTime.Now));

        var rentedScooter = _rentalRecordsService.GetScooterById(DEFAULT_SCOOTE_ID);

        rentedScooter.Id.Should().Be(DEFAULT_SCOOTE_ID);
    }

    [TestMethod]
    public void GetScooterById_GetScooterWithInvalidId_ThrowsInvalidIdException()
    {
        _rentedScooterList.Add(new RentedScooter(DEFAULT_SCOOTE_ID, DateTime.Now));

        Action action = () => _rentalRecordsService.GetScooterById(string.Empty);

        action.Should().Throw<InvalidIdException>();
    }

    [TestMethod]
    public void GetScooterById_GetScooterWithWrongId_ThrowsScooterIdDoesNotExistException()
    {
        _rentedScooterList.Add(new RentedScooter(DEFAULT_SCOOTE_ID, DateTime.Now));

        Action action = () => _rentalRecordsService.GetScooterById("Wrong Id");

        action.Should().Throw<ScooterIdDoesNotExistException>();
    }

    [TestMethod]
    public void GetScooters_ReturnsRentedScooterList()
    {
        var rentedScooter = new RentedScooter(DEFAULT_SCOOTE_ID, DateTime.Now);
        _rentedScooterList.Add(rentedScooter);

        var result = _rentalRecordsService.GetScooters();

        result.Count.Should().Be(1);
        result.First().Should().Be(rentedScooter);
    }
}