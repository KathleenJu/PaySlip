using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaySlip.Kata
{
    public class IncomeTaxCalculator
    {
        private readonly int _annualSalary;
        private readonly string _taxRateInfo;

        public IncomeTaxCalculator(int annualSalary, string file)
        {
            _annualSalary = annualSalary;
            _taxRateInfo = file;
        }

        public List<TaxRateInfo> TaxRateInfoLoader()
        {
            List<TaxRateInfo> TaxRateInfo = new List<TaxRateInfo>();
            using (StreamReader file =
                new StreamReader(@"/Users/kathleen.jumamoy/Projects/Katas/PaySlip/PaySlip/files/taxRateInfo.json"))
            {
//                var json = file.ReadToEnd();
                var obj = JObject.Parse(file.ReadToEnd());
                foreach (var i in obj)
                {
                    var taxRange = obj["taxRateInfo"][0];
                    TaxRateInfo.Add(new TaxRateInfo((double) taxRange["minimumSalary"],
                        (double) taxRange["maximumSalary"], (double) taxRange["nonTaxableSalary"],
                        (double) taxRange["taxPerDollar"], (double) taxRange["extraTax"]));
                }
            }

            return TaxRateInfo;
        }

        public double CalculateIncomeTax()
        {
            var nonTaxableSalary = 18200;
            var taxPerDollar = 0.0;
            var foo = TaxRateInfoLoader();
            foreach (var taxRange in foo)
            {
                if (_annualSalary >= taxRange.getMinimumSalary() && _annualSalary <= taxRange.getMaximumSalary())
                {
                    var taxableSalary = _annualSalary - taxRange.getNonTaxableSalary();
                    var taxOnSalary = taxableSalary * taxRange.getTaxPerDollar();
                    var incomeTax = Math.Round((taxOnSalary + taxRange.getExtraTax()) / 12);

                    return incomeTax;
                }
            } //must be pure function, shouldnt use the field listoftaxrate

            return 0;
        }
    }
}