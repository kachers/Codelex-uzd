using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class Account
    {
        private string _name;
        private double _balance;

        public Account(string name, double balance)
        {
            _name = name;
            _balance = balance;
        }

        public string Name { get{return _name; } }
        public double Balance { get { return _balance; } }

        public string GetName()
        {
            return Name;
        }

        public double GetBalance()
        {
            return Balance;
        } 
    }
}
