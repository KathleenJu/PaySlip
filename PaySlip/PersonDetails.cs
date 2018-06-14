using System.Globalization;

namespace PaySlip.Kata
{
    public class PersonDetails
    {
        private string FirstName { get; set; }// get rid of get and set
        private string LastName { get; set; }

        public PersonDetails(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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