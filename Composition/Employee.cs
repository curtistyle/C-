using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Date BirthDate { get; }
        public Date HireDate { get; }

        // constructor to initialize name, birth date and hore date
        public Employee(string firstName, string lastName, Date birthDate, Date hireDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            HireDate = hireDate;
        }
        // convert Employee to string format
        public override string ToString() => $"{LastName}, {BirthDate} " + $"Hired: {HireDate} Birthday: {BirthDate}";
    }
}


