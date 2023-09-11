using Exercise6;

namespace Exercise6Tests.Tests
{
    [TestClass]
    public class CatTest
    {
        
        private Cat _cat;
        private Vegetable _vegetable;


        [TestInitialize]
        public void Setup()
        {
            _cat = new Cat("DEFAULT", "DEFAULT", 1, "DEFAULT", "DEFAULT");
            _vegetable = new Vegetable(1);

        }

        [TestMethod]
        public void EatFood_WithFood_FoodQuantityAdded()
        {
            _cat.EatFood(_vegetable);

            Assert.AreEqual(1, _cat.FoodEaten);
        }
    }
}