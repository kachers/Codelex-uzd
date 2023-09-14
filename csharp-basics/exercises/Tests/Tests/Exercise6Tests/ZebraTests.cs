using Exercise6;
using FluentAssertions;

namespace Exercise6Tests.Tests
{
    [TestClass]
    public class ZebraTest
    {
        private Zebra _zebra;
        private Vegetable _vegetable;
        private Meat _meat;

        [TestInitialize]
        public void Setup()
        {
            _zebra = new Zebra("DEFAULT", "DEFAULT", 1, "DEFAULT");
            _vegetable = new Vegetable(5);
            _meat = new Meat(5);
        }

        [TestMethod]
        public void EatFood_Vegetable_FoodQuantityAdded()
        {
            _zebra.EatFood(_vegetable);

            Assert.AreEqual(5, _zebra.FoodEaten);
        }

        [TestMethod]
        public void EatFood_Meat_FoodQuantityAdded()
        {
            Action action = () => _zebra.EatFood(_meat);

            action.Should().Throw<WrongFoodException>();
        }

        [TestMethod]
        public void Make_Sound_ReturnsString()
        {
            var result = _zebra.MakeSound();

            result.Should().Be("Im am a Zebra!");
        }
    }
}