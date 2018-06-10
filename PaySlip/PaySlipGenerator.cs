using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PaySlip
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
    }
}
