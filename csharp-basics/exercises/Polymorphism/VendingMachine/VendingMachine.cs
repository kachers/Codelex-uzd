using System;
using System.Collections.Generic;

namespace VendingMachine
{
    internal class VendingMachine : IVendingMachine
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
            _insertedMoney.Euros += amount.Euros; 
            _insertedMoney.Cents += amount.Cents;

            if (_insertedMoney.Cents >= 100)
            {
                _insertedMoney.Euros += _insertedMoney.Cents / 100;
                _insertedMoney.Cents %= 100;
            }

            return new Money
            {
                Euros = _insertedMoney.Euros, 
                Cents = _insertedMoney.Cents
            }; 
        }

        public Money ReturnMoney()
        {
            Money returnedAmount = Amount;
            _insertedMoney = new Money();

            return returnedAmount;
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            for (var i = 0; i < _productList.Count; i++)
            {
                if (_productList[i].Name.ToLower() == name)
                {
                    var productQuantityUpdate = _productList[i];
                    _productList[i] = new Product
                    {
                        Name = productQuantityUpdate.Name, 
                        Price = productQuantityUpdate.Price,
                        Available =  amount
                    };

                    var productPrice = productQuantityUpdate.Price.Euros * 100 + productQuantityUpdate.Price.Cents;
                    var totalBalance = Amount.Euros * 100 + Amount.Cents;
                    int totalCentsLeft = totalBalance - productPrice;
                    int euros;

                    if (totalCentsLeft >= 100) euros = (int)Math.Floor((double)(totalCentsLeft /100));
                    else euros = 0;

                    _insertedMoney = new Money
                    {
                        Euros = Math.Abs(euros), 
                        Cents = totalCentsLeft%100
                    };
                }
            }

            return true;
        }
    }
}