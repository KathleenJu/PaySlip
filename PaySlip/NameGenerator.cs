using System.Globalization;

namespace PaySlip.Kata
{
    public class NameGenerator
    {
        //class name to personDetails?
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string FullName { get; set; }

        public NameGenerator(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        //is it necessary to have parameters in constructor? as they have setters

        public string getFirstName()
        {
            return FirstName;
        }

        public void setFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public string getLastName()
        {
            return LastName;
        }

        public void setLastName(string lastName)
        {
            LastName = lastName;
        }

        public string getFullName()
        {
            return FullName;
        }

        public void setFullName(string firstName, string lastName)
        {
            firstName = ToCapitalise(firstName);
            lastName = ToCapitalise(lastName);
            FullName = firstName + " " + lastName;
        }

//        public string GenerateFullName(string firstName, string lastName)
//        {
//            firstName = ToCapitalise(firstName);
//            lastName = ToCapitalise(lastName);
//            var fullName = firstName + " " + lastName;
//            return fullName;
//        }

        private string ToCapitalise(string name)
        {
            var titleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name);
            return titleCase;
        }
    }
}