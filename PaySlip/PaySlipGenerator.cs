using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

namespace PaySlip.Kata
{
    public class PaySlipGenerator
    {
        public PersonDetails GeneratePaySlipForm()
        {
            Console.Write("Please input your name: ");
            var firstName = Console.ReadLine();

            Console.Write("Please input your surname: ");
            var lastName = Console.ReadLine();

            Console.Write("Please input your annual salary: ");
            var annualSalary = Convert.ToInt32(Console.ReadLine());
            //Int32.TryParse

            Console.Write("Please; enter your super rate: ");
            var superRate = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter your payment start date: ");
            var paymentStartDate = Console.ReadLine();

            Console.Write("Please enter your payment end date: ");
            var paymentEndDate = Console.ReadLine();

            return new PersonDetails(firstName, lastName, paymentStartDate, paymentEndDate, annualSalary, superRate);
        }

        public PersonDetails GeneratePaySlipFormV2()
        {
            //func takes a parameter, formQuestions (json file)
            List<string> userDetails = new List<string> { };

            var formQuestions = new[]
            {
                "Please input your name: ",
                "Please input your surname: ",
                "Please input your annual salary: ",
                "Please enter your super rate: ",
                "Please enter your payment start date: ",
                "Please enter your payment end date: "
            };

            foreach (var question in formQuestions)
            {
                Console.Write(question);
                userDetails.Add(Console.ReadLine());
            }

            return Foo(userDetails);
        }

        private PersonDetails Foo(List<string> userDetails)
        {
            return new PersonDetails(userDetails[0], userDetails[1], userDetails[2], userDetails[3],
                Convert.ToInt32(userDetails[4]), Convert.ToInt32(userDetails[5]));
        }

        public void GeneratePaySlip()
        {
            var personDetailsV2 = GeneratePaySlipFormV2();
            var personDetails = GeneratePaySlipForm(); //refactor, not clear that its returning a persondetails class

            var paySlipManager = new PaySlipManager();
            var paySlipResult = paySlipManager.PaySlipCalculator(personDetailsV2);
            ReturnPaySlipResult(paySlipResult);
        }

        private void ReturnPaySlipResult(PaySlipResult paySlip)
        {
            Console.WriteLine("\nYour payslip has been generated:\n");
            Console.WriteLine("Name: " + paySlip.FullName);
            Console.WriteLine("Pay Period: " + paySlip.PaymentPeriod);
            Console.WriteLine("Gross Income " + paySlip.GrossIncome);
            Console.WriteLine("Income Tax: " + paySlip.IncomeTax);
            Console.WriteLine("Net Income: " + paySlip.NetIncome);
            Console.WriteLine("Super: " + paySlip.Super);

            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}