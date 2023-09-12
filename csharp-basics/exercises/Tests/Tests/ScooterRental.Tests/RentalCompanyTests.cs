using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace ScooterRental.Tests;

[TestClass]
public class RentalCompanyTests
{
    private AutoMocker _mocker;
    private IRentalCompany _rentalCompany;
    private string DEFAULT_COMPANY_NAME;
    private string DEFAULT_ID;
    private Scooter SCOOTER;
    private Scooter SCOOTER2;
    private RentedScooter RENTED_SCOOTER;
    private DateTime RENT_START_TIME;
    private IList<RentedScooter> RENTED_SCOOTERS_LIST;

    [TestInitialize]
    public void Setup()
    {
        DEFAULT_COMPANY_NAME = "default";
        DEFAULT_ID = "1";
        SCOOTER = new Scooter(DEFAULT_ID, 0.5m) { IsRented = false }; ;
        SCOOTER2 = new Scooter("2", 0.5m) { IsRented = true };
        RENT_START_TIME = new DateTime(2023, 9, 10, 18, 15, 39);
        RENTED_SCOOTER = new RentedScooter(DEFAULT_ID, RENT_START_TIME);
        RENTED_SCOOTERS_LIST = new List<RentedScooter> { RENTED_SCOOTER };
        _mocker = new AutoMocker();
        var scooterServiceMock = _mocker.GetMock<IScooterService>();
        var recordsServiceMock = _mocker.GetMock<IRentalRecordsService>();
        
        _rentalCompany = new RentalCompany(
            DEFAULT_COMPANY_NAME,
            scooterServiceMock.Object,
            recordsServiceMock.Object);

        _mocker.GetMock<IScooterService>()
            .Setup(s => s.GetScooterById(DEFAULT_ID))
            .Returns(SCOOTER);

        _mocker.GetMock<IScooterService>()
            .Setup(s => s.GetScooterById(SCOOTER2.Id))
            .Returns(SCOOTER2);

        _mocker.GetMock<IRentalRecordsService>()
            .Setup(r =>
                r.StopRent(DEFAULT_ID, It.IsAny<DateTime>())).Returns(RENTED_SCOOTER);

        _mocker.GetMock<IRentalRecordsService>()
            .Setup(r =>
                r.GetScooters()).Returns(RENTED_SCOOTERS_LIST);
    }

    [TestMethod]
    public void StartRent_ScooterRentStarted()
    {
        _rentalCompany.StartRent(DEFAULT_ID);

        SCOOTER.IsRented.Should().Be(true);
        _mocker.GetMock<IRentalRecordsService>()
            .Verify(r =>
                r.StartRent(DEFAULT_ID, It.IsAny<DateTime>()), Times.Once);
    }

    [TestMethod]
    public void StartRent_WithEmptyId_ThrowsInvalidIdException()
    {
        var action = () => _rentalCompany.StartRent(string.Empty);

        action.Should().Throw<InvalidIdException>();
    }

    [TestMethod]
    public void StartRent_WithWrongId_ThrowsIdDoesNotExistException()
    {
        var action = () => _rentalCompany.StartRent("Wrong_id");

        action.Should().Throw<ScooterIdDoesNotExistException>();
    }

    [TestMethod]
    public void EndRent_1minuteRent_ReturnsPricePerMinuteAndIsRentedSetToFalse()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddMinutes(1);

        var result = _rentalCompany.EndRent(DEFAULT_ID);

        result.Should().Be(SCOOTER.PricePerMinute);
        SCOOTER.IsRented.Should().BeFalse();
    }

    [TestMethod]
    public void EndRent_WithTotalPriceAboveMaxPrice_ReturnsMaxPrice()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddHours(1);
       
        var result = _rentalCompany.EndRent(DEFAULT_ID);

        result.Should().Be(20);
    }

    [TestMethod]
    public void EndRent_WithTotalPriceBelowMaxPrice_ReturnsActualPrice()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddMinutes(10);

        var result = _rentalCompany.EndRent(DEFAULT_ID);

        result.Should().Be(5);
    }

    [TestMethod]
    public void EndRent_MultipleDaysTotalPricePerEachDayHigherThanMaxPrice_ReturnsSumOfDailyMaxPrices()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddDays(4);

        var result = _rentalCompany.EndRent(DEFAULT_ID);

        result.Should().Be(100m);
    }

    [TestMethod]
    public void EndRent_MultipleDaysTotalPricePerEachDayLowerThanMaxPrice_ReturnsSumOfActualDailyPrices()
    {
        Scooter scooter = new(DEFAULT_ID, 0.01m) { IsRented = true };
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddDays(4).AddMinutes(39);

        _mocker.GetMock<IScooterService>()
            .Setup(s => s.GetScooterById(DEFAULT_ID))
            .Returns(scooter);

        var result = _rentalCompany.EndRent(DEFAULT_ID);

        result.Should().Be(58);
    }

    [TestMethod]
    public void EndRent_WithEmptyId_ThrowsInvalidIdException()
    {
        Action action = () => _rentalCompany.EndRent(string.Empty);

        action.Should().Throw<InvalidIdException>();
    }

    [TestMethod]
    public void EndRent_WithWrongId_ThrowsIdDoesNotExistException()
    {
        Action action = () => _rentalCompany.EndRent("Wrong_id");

        action.Should().Throw<ScooterIdDoesNotExistException>();
    }

    [TestMethod]
    public void CalculateIncome_YearIsSetAndBoolIsTrueWithFinishedAndUnFinishedRents_ReturnsSumOfBothRents()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddMinutes(10);
        RentedScooter unFinishedScooter = new("2", RENT_START_TIME.AddMinutes(-10)) { RentEnd = DateTime.Now };
        _mocker.GetMock<IRentalRecordsService>()
            .Setup(r =>
                r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);
        RENTED_SCOOTERS_LIST.Add(unFinishedScooter);

        var result = _rentalCompany.CalculateIncome(2023, true);

        result.Should().Be(_rentalCompany.EndRent(DEFAULT_ID) + _rentalCompany.EndRent("2"));
    }

    [TestMethod]
    public void CalculateIncome_YearIsNullAndBoolIsFalseWithFinishedAndUnFinishedRents_ReturnsSumOfFinishedRents()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddMinutes(10);
        RentedScooter unFinishedScooter = new("2", RENT_START_TIME.AddMinutes(-10)) { RentEnd = DateTime.Now };
        _mocker.GetMock<IRentalRecordsService>()
            .Setup(r =>
                r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);
        RENTED_SCOOTERS_LIST.Add(unFinishedScooter);

        var result = _rentalCompany.CalculateIncome(null, false);

        result.Should().Be(_rentalCompany.EndRent(DEFAULT_ID));
    }

    [TestMethod]
    public void
        CalculateIncome_YearIsSetAndBoolIsFalseWithFinishedAndUnFinishedRents_ReturnsSumOfFinishedRentsMatchingYear()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddMinutes(10);
        RentedScooter unFinishedScooter = new("2", RENT_START_TIME) { RentEnd = DateTime.Now };
        _mocker.GetMock<IRentalRecordsService>()
            .Setup(r =>
                r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);
        RENTED_SCOOTERS_LIST.Add(unFinishedScooter);

        var result = _rentalCompany.CalculateIncome(2023, false);

        result.Should().Be(_rentalCompany.EndRent(DEFAULT_ID));
    }

    [TestMethod]
    public void CalculateIncome_YearIsNullAndBoolIsTrueWithFinishedAndUnFinishedRents_ReturnsSumOfAllRents()
    {
        RENTED_SCOOTER.RentEnd = RENT_START_TIME.AddMinutes(10);
        RentedScooter unFinishedScooter = new("2", RENT_START_TIME.AddYears(-3)) { RentEnd = DateTime.Now };
        _mocker.GetMock<IRentalRecordsService>()
            .Setup(r =>
                r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);
        RENTED_SCOOTERS_LIST.Add(unFinishedScooter);

        var result = _rentalCompany.CalculateIncome(null, true);

        result.Should().Be(_rentalCompany.EndRent(DEFAULT_ID) + _rentalCompany.EndRent("2"));
    }
}