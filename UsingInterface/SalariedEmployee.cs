﻿// Cod: 12.5
namespace UsingInterface
{
    public class SalariedEmployee : Employee
    {
        private decimal weeklySalary;


        // four-parameter constructor 
        public SalariedEmployee(string firstName, string lastName, string socialSecurityNumber, decimal weeklySalary) :
            base(firstName, lastName, socialSecurityNumber)
        {
            WeeklySalary = weeklySalary; // validate salary
        }


        // property that gets and sets salaried employee's salary
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            }
            set
            {

                if (value < 0) //validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(WeeklySalary)} must be >= 0");
                }

                weeklySalary = value;
            }
        }

        // calculate earnings: override abstract methods Earnings in Employee
        public override decimal Earnings() => WeeklySalary;

        // return string representation of SalariedEmployee object
        public override string ToString() =>
            $"salaried employee: {base.ToString()}\n" +
            $"weecky salary: {weeklySalary:C}";
    }
}
