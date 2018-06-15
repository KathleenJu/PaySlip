using System;
using System.Collections.Generic;
using System.Globalization;
using static PaySlip.Kata.PaySlipGenerator;

namespace PaySlip.Kata
{
    public class PaySlipForm
    {
        public PersonDetails GeneratePaySlipForm()
        {
            Console.Write("Please input your name: ");
            var firstName = Console.ReadLine();

            Console.Write("Please input your surname: ");
            var lastName = Console.ReadLine();

            Console.Write("Please input your annual salary: ");
            var annualSalary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please; enter your super rate: ");
            var superRate = Convert.ToInt32(Console.ReadLine());
//            SuperRate = SuperRate / 100;

            Console.Write("Please enter your payment start date: ");
            var paymentStartDate = Console.ReadLine();

            Console.Write("Please enter your payment end date: ");
            var paymentEndDate = Console.ReadLine();

            return new PersonDetails(firstName, lastName, paymentStartDate, paymentEndDate, annualSalary, superRate);
        }
    }
}