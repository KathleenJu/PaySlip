using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PaySlip.Kata
{
    public class PaySlipGenerator
    {
        public void GeneratePaySlip()
        {
            var formQuestionsFile = @"../files/formQuestions.txt";
            var paySlipResultFile = @"../files/paySlipResult.txt";

            var personDetails = GeneratePersonDetails(GetPersonDetails(formQuestionsFile));
            var paySlipManager = new PaySlip(personDetails);
            var paySlipResult = paySlipManager.PaySlipCalculator();
            ReturnPaySlipResult(paySlipResult, paySlipResultFile);
        }

        private Dictionary<string, string> GetPersonDetails(string formQuestionsFile)
        {
            var userDetails = new Dictionary<string, string>();

            using (StreamReader file = new StreamReader(formQuestionsFile))
            {
                var json = file.ReadToEnd();
                JObject parsed = JObject.Parse(json);
                IDictionary<string, JToken> formFields = (JObject) parsed["formFields"];
                Console.Write(formFields);
                var dictionary = formFields.ToDictionary(pair => pair.Key, pair => Console.ReadLine());

//                string question;
//                while ((question = file.ReadLine()) != null)
//                {
//                    Console.Write(question);
//                    userDetails.Add("test", Console.ReadLine()); //put user input to dict
//                }
            }

            return userDetails;
        }

        private PersonDetails GeneratePersonDetails(Dictionary<string, string> userDetails)
        {
            return new PersonDetails(userDetails[firstName], userDetails[1], Convert.ToInt32(userDetails[2]),
                Convert.ToInt32(userDetails[3]), userDetails[4], userDetails[5]);
        } //access value by key

        private void ReturnPaySlipResult(PaySlipResult paySlip, string paySlipResultFile)
        {
            using (StreamReader file = new StreamReader(paySlipResultFile))
            {
                Console.WriteLine("\nYour payslip has been generated:\n");
                var json = file.ReadToEnd();
                var obj = JObject.Parse(json);
                var paySlipFile = obj["paySlip"][0];
                
                Console.WriteLine(paySlipFile["name"] + paySlip.FullName);
                Console.WriteLine(paySlipFile["payPeriod"] + paySlip.PaymentPeriod);
                Console.WriteLine(paySlipFile["grossIncome"].ToString() + paySlip.GrossIncome);
                Console.WriteLine(paySlipFile["incomeTax"].ToString() + paySlip.IncomeTax);
                Console.WriteLine(paySlipFile["netIncome"].ToString() + paySlip.NetIncome);
                Console.WriteLine(paySlipFile["super"].ToString() + paySlip.Super);
                
//                string formField;
//                while ((formField = file.ReadLine()) != null)
//                {
//                    Console.Write(formField);
//                    Console.WriteLine(paySlip.FullName + "\n");
//                }

                Console.WriteLine("\nThank you for using MYOB!");
            }
        }
    }
}