using Exercise6;
using FluentAssertions;

namespace Exercise6Tests.Tests
{
    [TestClass]
    public class CatTest
    {
        private Cat _cat;
        private Vegetable _vegetable;
        private Meat _meat;

        [TestInitialize]
        public void Setup()
        {
            _cat = new Cat("DEFAULT", "DEFAULT", 1, "DEFAULT", "DEFAULT");
            _vegetable = new Vegetable(5);
            _meat = new Meat(5);
        }

        [TestMethod]
        public void EatFood_Vegetable_FoodQuantityAdded()
        {
            _cat.EatFood(_vegetable);

            Assert.AreEqual(5, _cat.FoodEaten);
        }

        [TestMethod]
        public void EatFood_Meat_FoodQuantityAdded()
        {
            _cat.EatFood(_meat);

            Assert.AreEqual(5, _cat.FoodEaten);
        }

        [TestMethod]
        public void Make_Sound_ReturnsString()
        {
            var result = _cat.MakeSound();

            result.Should().Be("Meowwww");
        }
    }
}