using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace Firm
{
    internal class Commissions : Hourly
    {
        private double _totalSales;
        private double _commissionRate;

        public Commissions(string name, string address, string ePhone, string socSecNumber, double rate,
            double commissionRate) : base(name, address, ePhone, socSecNumber, rate)
        {
            _commissionRate = commissionRate;
            _totalSales = 0;
        }

        public void AddSales(double totalSales)
        {
            _totalSales += totalSales;
        }

        public override double Pay()
        {
            var payment = base.Pay() + _totalSales * _commissionRate;
            _totalSales = 0;
            return payment;
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += "\nTotal sales: " + _totalSales;
            return result;
        }
    }
}
