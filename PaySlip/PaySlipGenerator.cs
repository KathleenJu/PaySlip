using System;
using System.Collections.Generic;
using System.Globalization;

namespace PaySlip.Kata
{
    public class PaySlipGenerator
    {
        private readonly List<Array> listOfTaxableIncome = new List<Array>
        {
            new double[] {0, 18200, 0, 0, 0},
            new[] {18201, 37000, 18200, 0.19, 0},
            new[] {37001, 87000, 37000, 0.325, 3572},
            new[] {87001, 180000, 87000, 0.37, 19822},
            new[] {180001, Double.PositiveInfinity, 180000, 0.45, 54232} //special case for this
        };


        public double CalculateIncomeTax(int annualSalary)
        {
            var nonTaxableSalary = 18200;
            var taxPerDollar = 0.0;
            for (int i = 0; i < listOfTaxableIncome.Count; i++)
            {
                var taxRate = new TaxInfo((IList<double>) listOfTaxableIncome[i]);
                if (annualSalary > taxRate.MinimumSalary && annualSalary <= taxRate.MaximumSalary)
                {
                    var taxableSalary = annualSalary - taxRate.NonTaxableSalary;
                    var taxOnSalary = taxableSalary * taxRate.TaxPerDollar;
                    var incomeTax = Math.Round((taxOnSalary + taxRate.ExtraTax) / 12);

                    return incomeTax;
                }
            }
            return 0;
        }

        public void GeneratePaySlipForm()
        {
            Console.Write("Please input your name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please input your surname: ");
            var lastName = Console.ReadLine();
            Console.Write("Please input your annual salary: ");
            var annualSalary = Console.ReadLine();
        }

        public int CalculateGrossIncome(int annualSalary)
        {
            var grossIncome = annualSalary / 12;
            return grossIncome;
        }

        public string GenerateFullName(string firstName, string lastName)
        {
            firstName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(firstName);
            lastName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(lastName);
            var fullName = firstName + " " + lastName;
            return fullName;
        }

        public string GeneratePaymentPeriod(string paymentStart, string paymentEnd)
        {
            var paymentPeriod = paymentStart + " – " + paymentEnd;
            return paymentPeriod;
        }

        public double CalculateSuper(int grossIncome, int superRate)
        {
            var superRatePercentage = (double) superRate / 100;
            var super = grossIncome * superRatePercentage;
            return Math.Floor(super);
        }

        public decimal CalculateIncomeTax(int annualSalary,
            int extraTax)
        {
            var salaryTax = CalculateIncomeTax(annualSalary);
            var expectedTotalIncomeTax = Math.Round((salaryTax + extraTax) / 12);
            return (decimal) expectedTotalIncomeTax;
        }


        private static double GetTaxOnSalary(int annualSalary)
        {
            int nonTaxableSalary = 18200;
            double taxPerDollar = 0.0;

            if (annualSalary >= 18201 && annualSalary <= 37000)
            {
                nonTaxableSalary = 18200;
                taxPerDollar = 0.19;
            }

            if (annualSalary >= 37001 && annualSalary <= 87000)
            {
                nonTaxableSalary = 37000;
                taxPerDollar = 0.325;
            }

            if (annualSalary >= 87001 && annualSalary <= 180000)
            {
                nonTaxableSalary = 87000;
                taxPerDollar = 0.37;
            }

            if (annualSalary >= 180001)
            {
                nonTaxableSalary = 180000;
                taxPerDollar = 0.45;
            }

            var taxableSalary = annualSalary - nonTaxableSalary;
            var taxOnSalary = taxableSalary * taxPerDollar;

            return taxOnSalary;
            //used enum and foreach iterate data structure
        }
    }
}