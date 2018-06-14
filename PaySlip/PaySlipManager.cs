using System;
using System.Collections.Generic;
using System.Globalization;

namespace PaySlip.Kata
{
    public class PaySlipManager
    {
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

        public static int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            int netIncome = grossIncome - incomeTax;
            return netIncome;
        }
    }
}