using Exercise6;
using FluentAssertions;
using System;

namespace Exercise6Tests.Tests
{
    [TestClass]
    public class MouseTest
    {
        private Mouse _mouse;
        private Vegetable _vegetable;
        private Meat _meat;

        [TestInitialize]
        public void Setup()
        {
            _mouse = new Mouse("DEFAULT", "DEFAULT", 1, "DEFAULT");
            _vegetable = new Vegetable(5);
            _meat = new Meat(5);
        }

        [TestMethod]
        public void EatFood_Vegetable_ThrowWrongFoodException()
        {
            _mouse.EatFood(_vegetable);

            Assert.AreEqual(5, _mouse.FoodEaten);
        }

        [TestMethod]
        public void EatFood_Meat_FoodQuantityAdded()
        {
            Action action = () => _mouse.EatFood(_meat);

            action.Should().Throw<WrongFoodException>();
        }

        [TestMethod]
        public void Make_Sound_ReturnsString()
        {
            var result = _mouse.MakeSound();

            result.Should().Be("Im am a mouse!");
        }
    }
}