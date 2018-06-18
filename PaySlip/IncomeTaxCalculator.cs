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
        private readonly string _taxRatesFile = "../files/taxRateInfo.json";
        private List<TaxRateInfo> _taxRateInfo;

        public IncomeTaxCalculator(int annualSalary)
        {
            _annualSalary = annualSalary;
        }

        public void TaxRateInfoLoader()
        {
            using (StreamReader file = new StreamReader(_taxRatesFile))
            {
                var json = file.ReadToEnd();
                var obj = JObject.Parse(json);
                for (int i = 0; i < ((JArray) obj["taxRateInfo"]).Count; i++)
                {
                    var taxRange = obj["taxRateInfo"][i];
                    _taxRateInfo.Add(new TaxRateInfo((double) taxRange["minimumSalary"],
                        (double) taxRange["maximumSalary"], (double) taxRange["nonTaxableSalary"],
                        (double) taxRange["taxPerDollar"], (double) taxRange["extraTax"]));
                }
            }

        }

        public double CalculateIncomeTax()
        {
            foreach (var taxRange in _taxRateInfo)
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