using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PaySlip.Kata
{
    class TaxRateInfo
    {
        private double MinimumSalary { get; }
        private double MaximumSalary { get; }
        private double NonTaxableSalary { get; }
        private double TaxPerDollar { get; }
        private double ExtraTax { get; }

//        public double getMinimumSalary()
//        {
//            return MinimumSalary;
//        }
//
//        public void setMininumSalary(double MinimunSalary)
//        {
//            this.MinimumSalary = MinimunSalary;
//        }

        public TaxRateInfo(IList<double> taxRateInfo)
        {
            MinimumSalary = taxRateInfo[0];
            MaximumSalary = taxRateInfo[1];
            NonTaxableSalary = taxRateInfo[2];
            TaxPerDollar = taxRateInfo[3];
            ExtraTax = taxRateInfo[4];
        }
    }
}