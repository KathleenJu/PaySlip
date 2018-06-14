using System;
using System.Collections.Generic;
using System.Globalization;
using static PaySlip.Kata.PaySlipManager;

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
            var annualSalary = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Please; enter your super rate: ");
            var superRate = Convert.ToInt32(Console.ReadLine()) ;
            superRate = superRate / 100;
            
            Console.Write("Please enter your payment start date: ");
            var paymentStartDate = Console.ReadLine();
            
            Console.Write("Please enter your payment end date: ");
            var paymentEndDate = Console.ReadLine();

            GeneratePaySlip(firstName, lastName, paymentStartDate, paymentEndDate, annualSalary, superRate);
        }

        private void GeneratePaySlip(string firstName, string lastName, string paymentStartDate, string paymentEndDate,
            int annualSalary, int superRate)
        {
            var personName = new NameGenerator(firstName, lastName);
            var fullName = personName.getFullName();
            
            var paymentPeriod = GeneratePaymentPeriod(paymentStartDate, paymentEndDate);
            var grossIncome = CalculateGrossIncome(annualSalary);
            var incomeTax = CalculateIncomeTax(annualSalary);
            var netIncome = CalculateNetIncome(grossIncome, (int) incomeTax);
            var super = CalculateSuper(grossIncome, superRate);
            
            ReturnPaySlipResult(fullName, paymentPeriod, grossIncome, incomeTax, netIncome, super);
        }

        private static void ReturnPaySlipResult(string fullName, string paymentPeriod, int grossIncome, double incomeTax,
            int netIncome, double super)
        {
            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine("Name: " + fullName);
            Console.WriteLine("Pay Period: " + paymentPeriod);
            Console.WriteLine("Gross Income " + grossIncome);
            Console.WriteLine("Income Tax: " + incomeTax);
            Console.WriteLine("Net Income: " + netIncome);
            Console.WriteLine("Super: " + super);

            Console.WriteLine("\nThank you for using MYOB!");
        }

    }
}