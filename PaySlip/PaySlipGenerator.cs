using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PaySlip.Kata
{
    class levelInfo
    {
        private int low;
        private int high;

        levelInfo(int low, int high)
        {
        }
    }

    public class PaySlipGenerator
    {

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

        //Dictionary for the taxable income (minimumAmount, maximumAmount), Tax on this income
        public decimal CalculateIncomeTax(int annualSalary,
            int extraTax)
        {
            var salaryTax = GetSalaryTax(annualSalary);
            var expectedTotalIncomeTax = Math.Round((salaryTax + extraTax) / 12);
            return (decimal) expectedTotalIncomeTax;
        }

        private static double GetSalaryTax(int annualSalary)
        {
            int notTaxableSalary = 18200;
            double taxPerDollar = 0.0;
            
            if (annualSalary >= 18201 && annualSalary <= 37000)
            {
                notTaxableSalary = 18200;
                taxPerDollar = 0.19;
            }
            if (annualSalary >= 37001 && annualSalary <= 87000)
            {
                notTaxableSalary = 37000;
                taxPerDollar = 0.325;
            }
            if (annualSalary >= 87001 && annualSalary <= 180000)
            {
                notTaxableSalary = 87000;
                taxPerDollar = 0.37;
            }
            if (annualSalary >= 180001)
            {
                notTaxableSalary = 180000;
                taxPerDollar = 0.45;
            }
            
            var taxableSalary = annualSalary - notTaxableSalary;
            var taxOnSalary = taxableSalary * taxPerDollar;

            return taxOnSalary;
            //used enum and foreach iterate data structure
        }
    }
}