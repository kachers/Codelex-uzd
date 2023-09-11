using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using static System.Collections.Specialized.BitVector32;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        private IRentalCompany _rentalCompany;
        private string DEFAULT_COMPANY_NAME;
        private AutoMocker _mocker;

        [TestInitialize]
        public void Setup()
        {
            DEFAULT_COMPANY_NAME = "default";
            _mocker = new AutoMocker();
            var scooterServiceMock = _mocker.GetMock<IScooterService>();
            var recordsServiceMock = _mocker.GetMock<IRentalRecordsService>();
            _rentalCompany = new RentalCompany(
                DEFAULT_COMPANY_NAME,
                scooterServiceMock.Object,
                recordsServiceMock.Object);
        }

        [TestMethod]
        public void StartRent_ScooterRentStarted()
        {
            Scooter scooter = new("1", 0.1m);
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            
            _rentalCompany.StartRent("1");

            scooter.IsRented.Should().Be(true);
            _mocker.GetMock<IRentalRecordsService>()
                .Verify(r => 
                    r.StartRent("1", It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public void StartRent_StartRentWithEmptyId_ThrowsInvalidIdException()
        {
            Action action = () => _rentalCompany.StartRent("");

            action.Should().Throw<InvalidIdException>();
        }

        [TestMethod]
        public void StartRent_StartRentWithWrongId_ThrowsIdDoesNotExistException()
        {
            Scooter scooter = new("1", 0.1m);
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            
            Action action = () => _rentalCompany.StartRent("Wrong_id");

            action.Should().Throw<ScooterIdDoesNotExistException>();
        }

        [TestMethod]
        public void EndRent_RentEndedInSameDateAndTotalRentalPriceWasHigherThanMaximumDailyPrice_ReturnsMaximumDailyPrice()
        {
            Scooter scooter = new("1", 3000m){IsRented = true};
            RentedScooter rentedScooter = new("1", DateTime.Now.AddMinutes(-10)){RentEnd = DateTime.Now};
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);

            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(rentedScooter);
            
            var result = _rentalCompany.EndRent("1");

            result.Should().Be(2000);
            scooter.IsRented.Should().BeFalse();
        }

        [TestMethod]
        public void EndRent_RentEndInTheSameDateAndTotalRentalPriceWasLowerThanMaximumDailyPrice_ReturnsActualTotalRentalPrice()
        {
            Scooter scooter = new("1", 190m){IsRented = true};
            RentedScooter rentedScooter = new("1", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);

            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(rentedScooter);

            var result = _rentalCompany.EndRent("1");

            result.Should().Be(1900);
            scooter.IsRented.Should().BeFalse();
        }

        [TestMethod]
        public void EndRent_RentEndedInDifferentDateAndTotalRentalPriceForEachDayWasHigherThanMaximumDailyPrice_ReturnsMaximumSumOfDailyMaxPriceForEachDay()
        {
            Scooter scooter = new("1", 300m){IsRented = true};
            var rentStart = new DateTime(2020, 9, 12, 23, 50, 39);
            var rentEnd = new DateTime(2020, 9, 13, 00, 10, 39);
            RentedScooter rentedScooter = new("1", rentStart) { RentEnd = rentEnd };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);

            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(rentedScooter);

            var result = _rentalCompany.EndRent("1");

            result.Should().Be(4000);
            scooter.IsRented.Should().BeFalse();
        }

        [TestMethod]
        public void EndRent_RentEndedInDifferentDateAndTotalRentalPriceForEachDayWasLowerThanMaximumDailyPrice_ReturnsSumOfActualDailyPrices()
        {
            Scooter scooter = new("1", 150m) { IsRented = true };
            var rentStart = new DateTime(2020, 9, 12, 23, 50, 1);
            var rentEnd = new DateTime(2020, 9, 13, 00, 9, 1);
            RentedScooter rentedScooter = new("1", rentStart) { RentEnd = rentEnd };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);

            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(rentedScooter);

            var result = _rentalCompany.EndRent("1");

            result.Should().Be(3000);
            scooter.IsRented.Should().BeFalse();
        }

        [TestMethod]
        public void CalculateIncome_YearIsSetAndBoolIsTrueWithFinishedAndUnFinishedScooterRent_ReturnsScooterPriceWithMatchingRentYear()
        {
            Scooter scooter = new("1", 150m){IsRented = false};
            var rentStart = new DateTime(2020, 9, 12, 23, 50, 1);
            var rentEnd = new DateTime(2020, 9, 13, 00, 9, 1);
            RentedScooter finishedScooter = new("1", rentStart) { RentEnd = rentEnd };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(finishedScooter);

            Scooter scooter2 = new("2", 200m){IsRented = true};
            RentedScooter unFinishedScooter = new("2", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("2"))
                .Returns(scooter2);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);

            IList<RentedScooter> rentedScooters = new List<RentedScooter>() { finishedScooter, unFinishedScooter };
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.GetScooters()).Returns(rentedScooters);

            var result = _rentalCompany.CalculateIncome(2020,true);

            result.Should().Be(_rentalCompany.EndRent(finishedScooter.Id));
        }

        [TestMethod]
        public void CalculateIncome_YearIsSetAndBoolIsFalseWithFinishedAndUnFinishedScooterRent_ReturnsFinishedScooterPrice()
        {
            Scooter scooter = new("1", 190m) { IsRented = false }; 
            RentedScooter finishedScooter = new("1", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(finishedScooter);

            Scooter scooter2 = new("2", 190m){IsRented = true};
            RentedScooter unFinishedScooter = new("2", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("2"))
                .Returns(scooter2);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);

            IList<RentedScooter> rentedScooters = new List<RentedScooter>() { finishedScooter, unFinishedScooter };
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.GetScooters()).Returns(rentedScooters);

            var result = _rentalCompany.CalculateIncome(2023, false);

            result.Should().Be(_rentalCompany.EndRent(finishedScooter.Id));
        }

        [TestMethod]
        public void CalculateIncome_YearIsSetAndBoolIsTrueWithFinishedAndUnFinishedScooterRentInDifferentYears_ReturnsUnFinishedScooterPriceMatchingYear()
        {
            Scooter scooter = new("1", 300m) { IsRented = false };
            var rentEnd = new DateTime(2020, 9, 10, 18, 25, 39);
            var rentStart = new DateTime(2020, 9, 10, 18, 15, 39);
            RentedScooter finishedScooter = new("1", rentStart) { RentEnd = rentEnd };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(finishedScooter);

            Scooter scooter2 = new("2", 200m) { IsRented = true };
            RentedScooter unFinishedScooter = new("2", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("2"))
                .Returns(scooter2);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("2", It.IsAny<DateTime>())).Returns(unFinishedScooter);

            IList<RentedScooter> rentedScooters = new List<RentedScooter>() { finishedScooter, unFinishedScooter };
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.GetScooters()).Returns(rentedScooters);

            var result = _rentalCompany.CalculateIncome(2023,true);

            result.Should().Be(_rentalCompany.EndRent(finishedScooter.Id));
        }

        [TestMethod]
        public void CalculateIncome_YearIsNullAndBoolIsTrueWithUnFinishedScooterRent_ReturnsUnFinishedScooterPrice()
        {

            Scooter scooter = new("1", 300m){IsRented = true};
            var rentEnd = new DateTime(2020, 9, 10, 18, 25, 39);
            var rentStart = new DateTime(2020, 9, 10, 18, 15, 39);
            RentedScooter unFinishedScooter = new("1", rentStart) { RentEnd = rentEnd }; 
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(unFinishedScooter);

            
            IList<RentedScooter> rentedScooters = new List<RentedScooter>() { unFinishedScooter };
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.GetScooters()).Returns(rentedScooters);

            var result = _rentalCompany.CalculateIncome(null, true);

            result.Should().Be(_rentalCompany.EndRent(unFinishedScooter.Id));
        }

        [TestMethod]
        public void CalculateIncome_YearIsSetAndBoolIsFalseWithUnFinishedScooterRent_ReturnsZero()
        {

            Scooter scooter = new("1", 300m) { IsRented = true };
            var rentEnd = new DateTime(2020, 9, 10, 18, 25, 39);
            var rentStart = new DateTime(2020, 9, 10, 18, 15, 39);
            RentedScooter unFinishedScooter = new("1", rentStart) { RentEnd = rentEnd };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(unFinishedScooter);


            IList<RentedScooter> rentedScooters = new List<RentedScooter>() { unFinishedScooter };
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.GetScooters()).Returns(rentedScooters);

            var result = _rentalCompany.CalculateIncome(null, false);

            result.Should().Be(0);
        }

        [TestMethod]
        public void CalculateIncome_YearIsNullAndBoolIsFalseWithTwoFinishedScooterRentInDifferentYears_ReturnsSumOfFScooterPrices()
        {

            Scooter scooter = new("1", 300m) { IsRented = false };
            var rentEnd = new DateTime(2020, 9, 10, 18, 25, 39);
            var rentStart = new DateTime(2020, 9, 10, 18, 15, 39);
            RentedScooter finishedScooter = new("1", rentStart) { RentEnd = rentEnd };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(finishedScooter);

            Scooter scooter2 = new("2", 10m) { IsRented = false };
            RentedScooter finishedScooter2 = new("2", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now }; ;
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("2"))
                .Returns(scooter2);
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("2", It.IsAny<DateTime>())).Returns(finishedScooter2);

            IList<RentedScooter> rentedScooters = new List<RentedScooter>() { finishedScooter, finishedScooter2 };
            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.GetScooters()).Returns(rentedScooters);

            var result = _rentalCompany.CalculateIncome(null,false);

            result.Should().Be(_rentalCompany.EndRent(finishedScooter.Id) + _rentalCompany.EndRent(finishedScooter2.Id));
        }
        
        /*
        [TestMethod]
        public void EndRent_RentEndInTheDifferentDateAndTotalRentalPriceWasLowerThanMaximumDailyPrice_ReturnsActualTotalRentalPrice()
        {
            Scooter scooter = new("1", 190m);
            RentedScooter rentedScooter = new("1", DateTime.Now.AddMinutes(-10)) { RentEnd = DateTime.Now };
            _mocker.GetMock<IScooterService>()
                .Setup(s => s.GetScooterById("1"))
                .Returns(scooter);

            _mocker.GetMock<IRentalRecordsService>()
                .Setup(r =>
                    r.StopRent("1", It.IsAny<DateTime>())).Returns(rentedScooter);

            var result = _rentalCompany.EndRent("1");

            result.Should().Be(1900);
            scooter.IsRented.Should().BeFalse();
        }
        */
    }
}
