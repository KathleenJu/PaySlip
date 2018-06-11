using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PaySlip.Kata
{
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
            return fullName ;
        }
        
        public string GeneratePaymentPeriod(string paymentStart, string paymentEnd)
        {
            var paymentPeriod = paymentStart + " – " + paymentEnd;
            return paymentPeriod;
        }
        
        public double CalculateSuper(int grossIncome, int superRate)
        {
            var superRatePercentage = (double)superRate / 100;
            var super = grossIncome * superRatePercentage;
            return Math.Floor(super);
        }
        
            //Dictionary for the taxable income (minimumAmount, maximumAmount), Tax on this income
        public decimal CalculateIncomeTax(int annualSalary, int minimumTaxableSalary, decimal taxPerDollar,
            int extraTax)
        {
            var taxableSalary = annualSalary - minimumTaxableSalary;
            var incomeTax = taxableSalary * taxPerDollar;
            var expectedTotalIncomeTax = Math.Round((incomeTax + extraTax) / 12);
            return expectedTotalIncomeTax;
        }
    }
}
