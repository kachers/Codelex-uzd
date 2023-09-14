using Exercise6;
using FluentAssertions;

namespace Exercise6Tests.Tests
{
    [TestClass]
    public class TigerTest
    {
        private Tiger _tiger;
        private Vegetable _vegetable;
        private Meat _meat;

        [TestInitialize]
        public void Setup()
        {
            _tiger = new Tiger("DEFAULT", "DEFAULT", 1, "DEFAULT");
            _vegetable = new Vegetable(5);
            _meat = new Meat(5);
        }

        [TestMethod]
        public void EatFood_Vegetable_ThrowWrongFoodException()
        {
            Action action = () => _tiger.EatFood(_vegetable);

            action.Should().Throw<WrongFoodException>();
        }

        [TestMethod]
        public void EatFood_Meat_FoodQuantityAdded()
        {
            _tiger.EatFood(_meat);

            Assert.AreEqual(5, _tiger.FoodEaten);
        }

        [TestMethod]
        public void Make_Sound_ReturnsString()
        {
            var result = _tiger.MakeSound();

            result.Should().Be("ROAAR!!!");
        }
    }
}