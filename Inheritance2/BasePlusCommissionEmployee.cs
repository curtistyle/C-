﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance2
{
    public class BasePlusCommissionEmployee : CommissionEmployee
    {
        private decimal baseSalary;

        public BasePlusCommissionEmployee(string firstName, string lastName, string socialSecurityNumber, decimal grossSales, decimal commissionRate, decimal baseSalary) : base(firstName, lastName, socialSecurityNumber, grossSales, commissionRate)
        {
            BaseSalary = baseSalary;
        }

        // property that gets and sets 
        // BasePlusCommissionEmployee's base salary
        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value < 0) //validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(BaseSalary)}");
                }

                baseSalary = value;
            }
        }   
        // calculate earnings
        public override decimal Earnings() => baseSalary + (commissionRate * grossSales);

        // return string representation of BasePlusCommissionEmployee
        public override string ToString() =>
            $"base-salaried commission employee: {FirstName} {LastName}\n" +
            $"social security number: {SocialSecurityNumber}\n" +
            $"gross sales: {grossSales:C}\n" +
            $"commission rate: {commissionRate:F2}\n" +
            $"base salary: {baseSalary}";
    }
}
