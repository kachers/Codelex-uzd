using FluentAssertions;
using Moq.AutoMock;
using ScooterRental;


namespace ScooterRental.Tests
{
    [TestClass]
    public class ScooterServiceTests
    {
        private ScooterService _scooterService;
        private List<Scooter> _scooterStorage;
        private const string DEFAULT_SCOOTE_ID = "1";
        private const decimal DEFAULT_PRICE_PER_MINUTE = 0.2m;

        [TestInitialize]
        public void Setup()
        {
            _scooterStorage = new List<Scooter>();
            _scooterService = new ScooterService(_scooterStorage);
        }

        [TestMethod]
        public void AddScooter_WithIdAndPricePerMinute_ScooterAdded()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, DEFAULT_PRICE_PER_MINUTE);

            _scooterStorage.Count.Should().Be(1);
        }

        [TestMethod]
        public void AddScooter_WithId1AndPricePerMinute1_ScooterAddedWithId1AndPrice1()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);

            var scooter = _scooterStorage.First();

            scooter.Id.Should().Be(DEFAULT_SCOOTE_ID);
            scooter.PricePerMinute.Should().Be(1m);
        }

        [TestMethod]
        public void AddScooter_AddDuplicateScooter_ThrowsDuplicateScooterException()
        {
            _scooterStorage.Add(new Scooter(DEFAULT_SCOOTE_ID, DEFAULT_PRICE_PER_MINUTE));

            Action action = () => _scooterService.AddScooter(DEFAULT_SCOOTE_ID, DEFAULT_PRICE_PER_MINUTE);

            action.Should().Throw<DuplicateScooterException>();
        }

        [TestMethod]
        public void AddScooter_AddScooterWithNegativePrice_ThrowsNegativePriceExceptionException()
        {
            Action action = () => _scooterService.AddScooter(DEFAULT_SCOOTE_ID, -DEFAULT_PRICE_PER_MINUTE);

            action.Should().Throw<NegativePriceException>();
        }

        [TestMethod]
        public void AddScooter_AddScooterWithEmptyId_ThrowsInvalidIdException()
        {
            Action action = () => _scooterService.AddScooter(string.Empty, DEFAULT_PRICE_PER_MINUTE);

            action.Should().Throw<InvalidIdException>();
        }

        [TestMethod]
        public void RemoveScooter_RemoveScooterWhileScooterIsRentedOut_ThrowsCannotRemoveScooterWhileItIsRentedOutException()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage[0].IsRented = true;

            Action action = () => _scooterService.RemoveScooter(DEFAULT_SCOOTE_ID);

            action.Should().Throw<CannotRemoveScooterWhileItIsRentedOutException>();
        }

        [TestMethod]
        public void RemoveScooter_RemoveScooterWithInvalidId_ThrowsInvalidIdException()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage.First().IsRented = false;

            Action action = () => _scooterService.RemoveScooter(string.Empty);

            action.Should().Throw<InvalidIdException>();
        }

        [TestMethod]
        public void RemoveScooter_RemoveScooterWrongId_ThrowsScooterIdDoesNotExistException()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage.First().IsRented = false;

            Action action = () => _scooterService.RemoveScooter("Wrong Id");

            action.Should().Throw<ScooterIdDoesNotExistException>();
        }

        [TestMethod]
        public void RemoveScooter_RemoveScooterWhenScooterIsNotRentedOut_ScooterRemoved()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage.First().IsRented = false;
            
            _scooterService.RemoveScooter(DEFAULT_SCOOTE_ID);

            _scooterStorage.Should().BeEmpty();
        }

        [TestMethod]
        public void GetScooterById_GetScooterWithInvalidId_ThrowsInvalidIdException()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage.First().IsRented = false;

            Action action = () => _scooterService.GetScooterById(string.Empty);

            action.Should().Throw<InvalidIdException>();
        }

        [TestMethod]
        public void GetScooterById_GetScooterWithWrongId_ThrowsScooterIdDoesNotExistException()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage.First().IsRented = false;

            Action action = () => _scooterService.GetScooterById("Wrong Id");

            action.Should().Throw<ScooterIdDoesNotExistException>();
        }

        [TestMethod]
        public void GetScooterById_GetScooterWithDefaultId_ScooterWithDefaultIdReturned()
        {
            _scooterService.AddScooter(DEFAULT_SCOOTE_ID, 1m);
            _scooterStorage.First().IsRented = false;

            Scooter returnedScooter = _scooterService.GetScooterById(DEFAULT_SCOOTE_ID);

            returnedScooter.Id.Should().Be(DEFAULT_SCOOTE_ID);
        }
    }
}