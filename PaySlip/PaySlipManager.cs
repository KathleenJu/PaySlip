using System;
using System.Collections.Generic;
using System.Globalization;

namespace PaySlip.Kata
{
    public class PaySlipManager
    {

        private static readonly List<TaxRateInfo> listOfTaxRate = new List<TaxRateInfo>
        {
            new TaxRateInfo(0, 18200, 0, 0, 0),
            new TaxRateInfo(18201, 37000, 18200, 0.19, 0),
            new TaxRateInfo(37001, 87000, 37000, 0.325, 3572),
            new TaxRateInfo(87001, 180000, 87000, 0.37, 19822)   ,
            new TaxRateInfo(180001, Double.PositiveInfinity, 180000, 0.45, 54232) //special case for this
        };

        public static int CalculateGrossIncome(int annualSalary)
        {
            var grossIncome = annualSalary / 12;
            return grossIncome;
        }

        public static string GeneratePaymentPeriod(string paymentStart, string paymentEnd)
        {
            var paymentPeriod = paymentStart + " – " + paymentEnd;
            return paymentPeriod;
        }

        public static double CalculateSuper(int grossIncome, double superRate)
        {
            var superRatePercentage = superRate / 100;
            var super = grossIncome * superRatePercentage;
            return Math.Floor(super);
        }

        public static double CalculateIncomeTax(int annualSalary)
        {
            var nonTaxableSalary = 18200;
            var taxPerDollar = 0.0;
            foreach (var taxRange in listOfTaxRate)
            {
                if (annualSalary >= taxRange.getMinimumSalary() && annualSalary <= taxRange.getMaximumSalary())
                {
                    var taxableSalary = annualSalary - taxRange.setNonTaxableSalary();
                    var taxOnSalary = taxableSalary * taxRange.getTaxPerDollar();
                    var incomeTax = Math.Round((taxOnSalary + taxRange.getExtraTax()) / 12);

                    return incomeTax;
                }
            }//must be pure function, shouldnt use the field listoftaxrate
            return 0;
        }

        public static int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            int netIncome = grossIncome - incomeTax;
            return netIncome;
        }
    }
}