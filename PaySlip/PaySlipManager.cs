using System;
using System.Collections.Generic;
using System.Globalization;

namespace PaySlip.Kata
{
    public class PaySlipManager
    {
        private static readonly List<Array> listOfTaxRate = new List<Array>
        {
            new double[] {0, 18200, 0, 0, 0},
            new[] {18201, 37000, 18200, 0.19, 0},
            new[] {37001, 87000, 37000, 0.325, 3572},
            new[] {87001, 180000, 87000, 0.37, 19822},
            new[] {180001, Double.PositiveInfinity, 180000, 0.45, 54232} //special case for this
        };

        public static int CalculateGrossIncome(int annualSalary)
        {
            var grossIncome = annualSalary / 12;
            return grossIncome;
        }

        public static string GenerateFullName(string firstName, string lastName)
        {
            firstName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(firstName);
            lastName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(lastName);
            var fullName = firstName + " " + lastName;
            return fullName;
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
            for (int i = 0; i < listOfTaxRate.Count; i++)
            {
                var taxRate = new TaxRateInfo((IList<double>) listOfTaxRate[i]);
                if (annualSalary >= taxRate.MinimumSalary && annualSalary <= taxRate.MaximumSalary)
                {
                    var taxableSalary = annualSalary - taxRate.NonTaxableSalary;
                    var taxOnSalary = taxableSalary * taxRate.TaxPerDollar;
                    var incomeTax = Math.Round((taxOnSalary + taxRate.ExtraTax) / 12);

                    return incomeTax;
                }
            }

            return 0;
        }

        public static int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            int netIncome = grossIncome - incomeTax;
            return netIncome;
        }
    }
}