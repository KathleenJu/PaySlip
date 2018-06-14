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

        public void setMininumSalary(double minimumSalary)
        {
            MinimumSalary = minimumSalary;
        }

        public double getMaximumSalary()
        {
            return MaximumSalary;
        }

        public void setMaxinumSalary(double maximumSalary)
        {
            MaximumSalary = maximumSalary;
        }
        
        public double setNonTaxableSalary()
        {
            return NonTaxableSalary;
        }

        public void setNonTaxableSalary(double nonTaxableSalary)
        {
            NonTaxableSalary = nonTaxableSalary;
        }
        
        public double getTaxPerDollar()
        {
            return TaxPerDollar;
        }

        public void setTaxPerDollar(double taxPerDollar)
        {
            TaxPerDollar = taxPerDollar;
        }
        
        public double getExtraTax()
        {
            return ExtraTax;
        }

        public void setExtraDollar(double extraTax)
        {
            ExtraTax = extraTax;
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