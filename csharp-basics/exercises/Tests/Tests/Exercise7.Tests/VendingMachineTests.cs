using FluentAssertions;
using ScooterRental;

namespace Exercise7.Tests
{
    [TestClass]
    public class VendingMachineTests
    {

        private Money _defaultMoney;
        private Product _defaultProduct;
        private Product _defaultProduct2;
        private Product[] _defaultProductArray;
        private VendingMachine _vendingMachine;
        private const int DefaultProductNumber = 0;

        [TestInitialize]
        public void Setup()
        {
            _defaultMoney = new Money { Euros = 2, Cents = 0 };
            _defaultProduct = new Product
                { Name = "DEFAULT_PRODUCT", Price = _defaultMoney, Available = 1 };
            _defaultProduct2 = new Product
            { Name = "DEFAULT_PRODUCT2", Price = _defaultMoney, Available = 1 };
                _defaultProductArray = new Product[] { _defaultProduct };
            _vendingMachine = new VendingMachine("DEFAULT_MANUFACTURER", _defaultProductArray);
        }


        [TestMethod]
        public void ReturnMoney_NoCoinInserted_ThrowNoCoinsInsertedException()
        {
            Action action = () => _vendingMachine.ReturnMoney();

            action.Should().Throw<NoCoinsInsertedException>();
        }

        [TestMethod]
        public void ReturnMoney_DefaultCoinInserted_ReturnDefaultCoin()
        {
            
            _vendingMachine.InsertCoin(_defaultMoney);
           var returnAmount = _vendingMachine.ReturnMoney();

           returnAmount.Should().Be(_defaultMoney);
        }

        [TestMethod]
        public void InsertCoin_MoneyWithNegativeValueInserted_ThrowNegativeMoneyValueException()
        {
            Money negativeMoney = new() { Euros = 0, Cents = -1};
            Action action = () => _vendingMachine.InsertCoin(negativeMoney);

            action.Should().Throw<NegativeMoneyValueException>();
        }

        [TestMethod]
        public void InsertCoin_MoneyWithWrongValueInserted_ReturnInsertedMoney()
        {
            Money moneyWithWrongValue = new() { Euros = 1, Cents = 60 };
            var action =  _vendingMachine.InsertCoin(moneyWithWrongValue);

            action.Should().Be(moneyWithWrongValue);
        }

        [TestMethod]
        public void InsertCoin_ValidMoneyValueInserted_ReturnsMoneyWithZeroValues()
        {
            Money expectedReturnedMoney = new();
            var action = _vendingMachine.InsertCoin(_defaultMoney);

            action.Should().Be(expectedReturnedMoney);
        }

        [TestMethod]
        public void InsertCoin_ValidMoneyValueInserted_AmountIncreasedByTheValueOfInsertedCoin()
        {
            _vendingMachine.InsertCoin(_defaultMoney);
            
            _vendingMachine.Amount.Should().Be(_defaultMoney);
        }

        [TestMethod]
        public void UpdateProduct_ProductNumberHigherThanProductCount_ThrowProductNumberOutOfRangeException()
        {
            var wrongProductNumber = _vendingMachine.Products.Length +1;
            Action action = () => _vendingMachine.UpdateProduct(wrongProductNumber, _defaultProduct.Name, _defaultProduct.Price, _defaultProduct.Available);

            action.Should().Throw<ProductNumberOutOfRangeException>();
        }

        [TestMethod]
        public void UpdateProduct_NegativeProductNumber_ThrowProductNumberCannotBeNegativeException()
        {
            var negativeProductNumber = -1;
            Action action = () => _vendingMachine.UpdateProduct(negativeProductNumber, _defaultProduct.Name, _defaultProduct.Price, _defaultProduct.Available);

            action.Should().Throw<ProductNumberCannotBeNegativeException>();
        }

        [TestMethod]
        public void UpdateProduct_EmptyProductName_ThrowProductNameCantBeNullOrEmptyException()
        {
            _defaultProduct.Name = string.Empty;
            Action action = () => _vendingMachine.UpdateProduct(DefaultProductNumber, _defaultProduct.Name, _defaultProduct.Price, _defaultProduct.Available);

            action.Should().Throw<ProductNameCannotBeNullOrEmptyException>();
        }

        [TestMethod]
        public void UpdateProduct_NegativeProductQuantity_ThrowAvailableCannotBeNegativeException()
        {
            _defaultProduct.Available = -1;
            Action action = () => _vendingMachine.UpdateProduct(DefaultProductNumber, _defaultProduct.Name, _defaultProduct.Price, _defaultProduct.Available);

            action.Should().Throw<AvailableCannotBeNegativeException>();
        }

        [TestMethod]
        public void UpdateProduct_UpdateProductWithNegativePrice_ThrowProductPriceCannotBeNegativeException()
        {
            Money negativePrice = new() { Euros = -1, Cents = -1 };
            Action action = () => _vendingMachine.UpdateProduct(DefaultProductNumber, _defaultProduct.Name, negativePrice, _defaultProduct.Available);

            action.Should().Throw<ProductPriceCannotBeNegativeException>();
        }

        [TestMethod]
        public void UpdateProduct_UpdateProductWithValidName_ProductNameUpdated()
        {
            _vendingMachine.UpdateProduct(DefaultProductNumber, "New_Name", _defaultProduct.Price, _defaultProduct.Available);

            var updatedProductName = _vendingMachine.Products[DefaultProductNumber].Name;

            updatedProductName.Should().Be("New_Name");
        }

        [TestMethod]
        public void UpdateProduct_UpdateProductWithValidQuantity_ProductAvailableUpdated()
        {
            var newProductQuantity = 10;
            _vendingMachine.UpdateProduct(DefaultProductNumber, _defaultProduct.Name, _defaultProduct.Price, newProductQuantity);

            var updatedProductQuantity = _vendingMachine.Products[DefaultProductNumber].Available;

            updatedProductQuantity.Should().Be(newProductQuantity);
        }

        [TestMethod]
        public void UpdateProduct_UpdateProductWithValidPrice_ProductPriceUpdated()
        {
            Money newPrice = new() { Euros = 5, Cents = 10 };
            _vendingMachine.UpdateProduct(DefaultProductNumber, _defaultProduct.Name, newPrice, _defaultProduct.Available);
            var updatedEuroPrice = _vendingMachine.Products[DefaultProductNumber].Price.Euros;
            var updatedCentsPrice = _vendingMachine.Products[DefaultProductNumber].Price.Cents;

            updatedEuroPrice.Should().Be(newPrice.Euros);
            updatedCentsPrice.Should().Be(newPrice.Cents);
        }

        [TestMethod]
        public void AddProduct_AddValidProduct_ProductAddedInProductsArray()
        {
            var initialProductCount = _vendingMachine.Products.Length;
            _vendingMachine.AddProduct(_defaultProduct2.Name, _defaultProduct2.Price, _defaultProduct2.Available);
            var updatedProductCount = _vendingMachine.Products.Length;

            updatedProductCount.Should().Be(initialProductCount + 1);
        }

        [TestMethod]
        public void AddProduct_AddProductWithEmptyProductName_ThrowProductNameCantBeNullOrEmptyException()
        {
            var emptyName = string.Empty;
            Action action = () =>
                _vendingMachine.AddProduct(emptyName, _defaultProduct.Price, _defaultProduct.Available);

            action.Should().Throw<ProductNameCannotBeNullOrEmptyException>();
        }

        [TestMethod]
        public void AddProduct_AddProductWithExistingProductName_ThrowProductNameAlreadyExistsException()
        {
            var existingName = _defaultProduct.Name;
            Action action = () =>
                _vendingMachine.AddProduct(_defaultProduct.Name, _defaultProduct.Price, _defaultProduct.Available);

            action.Should().Throw<ProductNameAlreadyExistsException>();
        }

        [TestMethod]
        public void AddProduct_AddProductWithNegativePrice_ThrowProductPriceCannotBeNullOrNegativeException()
        {
            Money negativePrice = new() { Euros = -1, Cents = -1 };

            Action action = () =>
                _vendingMachine.AddProduct(_defaultProduct2.Name, negativePrice, _defaultProduct2.Available);

            action.Should().Throw<ProductPriceCannotBeNullOrNegativeException>();
        }

        [TestMethod]
        public void AddProduct_AddProductWithNegativeProductQuantity_ThrowProductQuantityCannotBeNegativeException()
        {
            var newProductQuantity = -1;
            Action action = () =>
                _vendingMachine.AddProduct(_defaultProduct2.Name, _defaultProduct2.Price, newProductQuantity);

            action.Should().Throw<ProductQuantityCannotBeNegativeException>();
        }
    }
}