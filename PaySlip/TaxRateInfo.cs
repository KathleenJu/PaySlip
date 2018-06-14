using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PaySlip.Kata
{
    class TaxRateInfo
    {
        private double MinimumSalary { get; set; }
        private double MaximumSalary { get; set; }
        private double NonTaxableSalary { get; set; }
        private double TaxPerDollar { get; set; }
        private double ExtraTax { get; set; }

        public double getMinimumSalary()
        {
            return MinimumSalary;
        }

        public double getMaximumSalary()
        {
            return MaximumSalary;
        }

        public double setNonTaxableSalary()
        {
            return NonTaxableSalary;
        }

        public double getTaxPerDollar()
        {
            return TaxPerDollar;
        }

        public double getExtraTax()
        {
            return ExtraTax;
        }

        public TaxRateInfo(double minimumSalary, double maximumSalary, double nonTaxableSalary, double taxPerDollar, double extraTax)
        {
            MinimumSalary = minimumSalary;
            MaximumSalary = maximumSalary;
            NonTaxableSalary = nonTaxableSalary;
            TaxPerDollar = taxPerDollar;
            ExtraTax = extraTax;
        }
    }
}