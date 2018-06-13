using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PaySlip.Kata
{
    class TaxRateInfo
    {
        public double MinimumSalary { get; }
        public double MaximumSalary { get; }
        public double NonTaxableSalary { get; }
        public double TaxPerDollar { get; }
        public double ExtraTax { get; }

        public TaxRateInfo(IList<double> rateTaxInfo)
        {
            MinimumSalary = rateTaxInfo[0];
            MaximumSalary = rateTaxInfo[1];
            NonTaxableSalary = rateTaxInfo[2];
            TaxPerDollar = rateTaxInfo[3];
            ExtraTax = rateTaxInfo[4];
        }
    }
}