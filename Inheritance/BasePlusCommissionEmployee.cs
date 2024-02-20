using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class BasePlusCommissionEmployee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SocialSecurityNumber { get; }
        private decimal grossSales; // gross weekly sales
        private decimal commissionRate; // commision percentage
        private decimal baseSalary; // base salary per week

        // sex-parameter constructor
        public BasePlusCommissionEmployee(string firstName, string lastName, string socialSecurityNumber, decimal grossSales, decimal commissionRate, decimal baseSalary)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            GrossSales = grossSales;
            CommissionRate = commissionRate;
            BaseSalary = baseSalary;
        }

        // property that gets and sets gross sales
        public decimal GrossSales
        {
            get
            {
                return grossSales;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(grossSales)} must be >= 0");
                }

                grossSales = value;
            }
        }

        // property that gets amd sets commission rate
        public decimal CommissionRate
        {
            get
            {
                return commissionRate;  
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(commissionRate)}");
                }
                commissionRate = value;
            }
        }   

        // property that gets and sets BasePlusCommissionEmployee's base salary
        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(BaseSalary)} must be >= 0");
                }
                baseSalary = value;
            }
        }

        // calculate earnings
        public decimal Earnings() => baseSalary + (commissionRate * grossSales);

        // return string representation of BasePlusCommissionEmployee
        public override string ToString() =>
            $"base-salaried commission employee: {FirstName} {LastName}\n" +
            $"social security number: {SocialSecurityNumber}\n" +
            $"gross sales: {grossSales:C}\n" +
            $"commission rate: {commissionRate:F2}\n" +
            $"base salary: {baseSalary:C}";
    }
}
