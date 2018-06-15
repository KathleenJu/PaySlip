using System;
using System.Collections.Generic;

namespace PaySlip.Kata
{
    public class IncomeTaxCalculator
    {
        private readonly int _annualSalary;

        public IncomeTaxCalculator(int annualSalary)
        {
            _annualSalary = annualSalary;
        }

        private readonly List<TaxRateInfo> listOfTaxRate = new List<TaxRateInfo>
        {
            new TaxRateInfo(0, 18200, 0, 0, 0),
            new TaxRateInfo(18201, 37000, 18200, 0.19, 0),
            new TaxRateInfo(37001, 87000, 37000, 0.325, 3572),
            new TaxRateInfo(87001, 180000, 87000, 0.37, 19822),
            new TaxRateInfo(180001, Double.PositiveInfinity, 180000, 0.45, 54232) //special case for this
        };

        public double CalculateIncomeTax()
        {
            var nonTaxableSalary = 18200;
            var taxPerDollar = 0.0;
            foreach (var taxRange in listOfTaxRate)
            {
                if (_annualSalary >= taxRange.getMinimumSalary() && _annualSalary <= taxRange.getMaximumSalary())
                {
                    var taxableSalary = _annualSalary - taxRange.setNonTaxableSalary();
                    var taxOnSalary = taxableSalary * taxRange.getTaxPerDollar();
                    var incomeTax = Math.Round((taxOnSalary + taxRange.getExtraTax()) / 12);

                    return incomeTax;
                }
            } //must be pure function, shouldnt use the field listoftaxrate

            return 0;
        }
    }
}