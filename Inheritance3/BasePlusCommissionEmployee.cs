using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance3
{
    public class BasePlusCommissionEmployee : CommissionEmployee
    {
        private decimal baseSalary; // base salary per week

        // six parameter derived-class constructor
        // with call to base class CommissionEmployee constructor

        public BasePlusCommissionEmployee(string firstName, string lastName, string socialSecurityNumber, decimal grossSales, decimal commissionRate, decimal baseSalary) :base(firstName, lastName, socialSecurityNumber, grossSales, commissionRate)
        {
            baseSalary = baseSalary; // validate base salary
        }

        // property that gets and sets 
        // BasePlusCommissionEmployee's

        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value <= 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(BaseSalary)} must be >= 0");
                }

                baseSalary = value;
            }
        }

        // calculate earnings
        public override decimal Earnings() => BaseSalary + base.Earnings();

        // return string representation of BasePlusCommissionEmployee
        public override string ToString() => $"base-salaried {base.ToString()}\nbase salary: {BaseSalary:C}";
    }
}
