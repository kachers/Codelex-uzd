using ScooterRental;

namespace Exercise7
{
    public class VendingMachine : IVendingMachine
    {
        public VendingMachine(string manufacturer, Product[] products)
        {
            
            Manufacturer = manufacturer;
            _productList = new List<Product>(products);
            _insertedMoney = new Money();
        }

        private readonly List<Product> _productList;
        private Money _insertedMoney;
        public string Manufacturer { get; }
        public bool HasProducts { get; }

        public Money Amount => _insertedMoney;

        public Product[] Products => _productList.ToArray();

        public bool AddProduct(string name, Money price, int count)
        {
            var existingNames = Products.Where(p => p.Name.Equals(name)).ToList();

            if (string.IsNullOrEmpty(name)) throw new ProductNameCannotBeNullOrEmptyException();

            if (existingNames.Count != 0) throw new ProductNameAlreadyExistsException();

            if (price.Euros < 0 || price.Cents < 0) throw new ProductPriceCannotBeNullOrNegativeException();

            if (count < 0) throw new ProductQuantityCannotBeNegativeException();

            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Available = count
            };

            _productList.Add(newProduct);
            return true;
        }

        public Money InsertCoin(Money amount)
        {
            if (amount.Euros < 0 || amount.Cents < 0) throw new NegativeMoneyValueException();

            if (amount is { Euros: 2, Cents: 0 } or { Euros: 1, Cents: 0 } or { Euros: 0, Cents: 50 } or { Euros: 0, Cents: 20 } or { Euros: 0, Cents: 10 })
            {
                _insertedMoney.Euros += amount.Euros;
                _insertedMoney.Cents += amount.Cents;

                if (_insertedMoney.Cents >= 100)
                {
                    _insertedMoney.Euros += _insertedMoney.Cents / 100;
                    _insertedMoney.Cents %= 100;
                }

                return new Money();
            }

            return new Money
            {
                Euros = amount.Euros,
                Cents = amount.Cents
            };
        }

        public Money ReturnMoney()
        {
            if (Amount.Euros == 0 && Amount.Cents == 0) throw new NoCoinsInsertedException();

            Money returnedAmount = Amount;
            _insertedMoney = new Money();

            return returnedAmount;
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            if (productNumber < 0) throw new ProductNumberCannotBeNegativeException();

            if (productNumber > Products.Length) throw new ProductNumberOutOfRangeException();

            if (string.IsNullOrEmpty(name)) throw new ProductNameCannotBeNullOrEmptyException();

            if (amount < 0) throw new AvailableCannotBeNegativeException();

            if (price.HasValue)
            {
                if (price.Value.Euros < 0 || price.Value.Cents < 0) throw new ProductPriceCannotBeNegativeException();
            }

            _productList[productNumber] = new Product
            {
                Name = name,
                Price = (Money) price,
                Available = amount
            };
            
            var productPrice = _productList[productNumber].Price.Euros * 100 + _productList[productNumber].Price.Cents;
            var totalBalance = Amount.Euros * 100 + Amount.Cents;
            int totalCentsLeft = totalBalance - productPrice;
            int euros;

            if (totalCentsLeft >= 100) euros = (int)Math.Floor((double)(totalCentsLeft / 100));
            else euros = 0;

            _insertedMoney = new Money
            {
                Euros = Math.Abs(euros),
                Cents = totalCentsLeft % 100
            };

            return true;
        }
    }
}