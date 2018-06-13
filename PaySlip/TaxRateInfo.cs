using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PaySlip.Kata
{
    class TaxRateInfo
    {
        private double MinimumSalary;
        public double MaximumSalary { get; }
        public double NonTaxableSalary { get; }
        public double TaxPerDollar { get; }
        public double ExtraTax { get; }


        public double getMinimumSalary()
        {
            return MinimumSalary;
        }

        public void setMininumSalary(double MinimunSalary)
        {
            this.MinimumSalary = MinimunSalary;
        }

        public TaxRateInfo(double MinimunSalary, double MaximumSalary)
        {
            setMininumSalary(MinimunSalary);
            setM
        }
    }
}