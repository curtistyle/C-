namespace AbstractClassesAndMethods
{ // Cod: 12.4
    public abstract class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SocialSecurityNumber { get; }

        // three-paremeter constructor
        public Employee(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        
        // return string representation of Employee object, using propierties
        public override string ToString() => $"{FirstName} {LastName}\n" +
            $"social security number: {SocialSecurityNumber}";

        // abstract method override by derived classess
        public abstract decimal Earnings(); // no implementation here
    }
}
