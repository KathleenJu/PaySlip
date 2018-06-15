using System.Globalization;

namespace PaySlip.Kata
{
    public class PersonDetails
    {
        private string FirstName { get; }
        private string LastName { get; }
        public string PaymentStartDate { get; }
        public string PaymentEndDate { get; }
        public int AnnualSalary { get; }
        public int SuperRate { get; }

        public PersonDetails(string firstName, string lastName, string paymentEndDate, string paymentStartDate,
            int annualSalary, int superRate)
        {
            FirstName = firstName;
            LastName = lastName;
            PaymentEndDate = paymentEndDate;
            PaymentStartDate = paymentStartDate;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
        }

        public string GetFullName()
        {
            var fullName = ToCapitalise(FirstName) + " " + ToCapitalise(LastName);
            return fullName;
        }

        private string ToCapitalise(string name)
        {
            var titleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name);
            return titleCase;
        }
    }
}