﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    public class Date
    {
        private int month; // 1-12
        private int day; // 1-31 based on month
        public int Year { get; private set; }

        // constructor: use property Month to confirm proper value for month;
        // use property Day to confirm proper value for day

        public Date(int month, int day, int year)
        {
            Month = month;
            Year = year;
            Day = day;
            Console.WriteLine($"Date object constructor for date {this}");
        }
    
        public int Month
        {
            get
            {
                return month;
            }

            private set // make writing inaccessible outside the class
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Month)} must be 1-12");
                }
                month = value;
            }
        }

        // property that gets and sets the day
        public int Day
        {
            get
            {
                return day;
            }
            private set // make writing inaccessible outside the class
            {
                int[] dayPerMonth = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                // check if day in range for month
                if (value <= 0 || value > dayPerMonth[Month])
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Day)} out of range for current month/year");
                }
                // check for leap year 
                if (Month == 2 && value == 29 && !(Year % 400 == 0 || (Year % 4 == 0 && Year % 100 != 0)))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Day)} out of range for current month/year");
                }

                day = value;
            }
        }

        // return a string of the form month/day/year
        public override string ToString() => $"{Month}/{Day}/{Year}";
    }
}
