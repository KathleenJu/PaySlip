using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace PaySlip.Kata
{
    public class PaySlipGenerator
    {
        public void GeneratePaySlip()
        {
            StreamReader formQuestions = new StreamReader(@"files/formQuestions2.txt");
            StreamReader taxRateInfo = new StreamReader(@"files/taxRateInfo.json");
            
            var personDetails = GeneratePersonDetails(GetUserDetails(formQuestions));
            var paySlipManager = new PaySlipManager(personDetails);
            var paySlipResult = paySlipManager.PaySlipCalculator();
            ReturnPaySlipResult(paySlipResult);
        }

        private List<string> GetUserDetails(StreamReader formQuestions)
        {
            var userDetails = new List<string>();

            string question;
            while ((question = formQuestions.ReadLine()) != null)
            {
                Console.Write(question);
                userDetails.Add(Console.ReadLine());
            }

            return userDetails;
        }

        private PersonDetails GeneratePersonDetails(List<string> userDetails)
        {
//            PersonDetails personDetails = new PersonDetails
//            {
//                FirstName = userDetails[0],
//                LastName = userDetails[1],
//                AnnualSalary = Convert.ToInt32(userDetails[2]),
//                SuperRate = Convert.ToInt32(userDetails[3]),
//                PaymentStartDate = userDetails[4],
//                PaymentEndDate = userDetails[5]
//)
//            };
            return new PersonDetails(userDetails[0], userDetails[1], Convert.ToInt32(userDetails[2]),
                Convert.ToInt32(userDetails[3]),
                userDetails[4], userDetails[5]);
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