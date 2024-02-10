﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedConstructors
{
    public class Time2
    {
        private int hour;
        private int minute;
        private int second;

        // constructor can be called with zero, one, two or three arguments
        public Time2(int hour = 0, int minute = 0, int second = 0)
        {
             SetTime(hour, minute, second);
        }

        // Time2 constructor: another Time2 object supplied as an argument
        public Time2(Time2 time) : this(time.Hour, time.Minute, time.Second) { }

        // set a new time value using universal time; invalid values
        // cause the properties' set accessors to throw exceptions
        public void SetTime(int hour, int minute, int second)
        {           
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        // property that gets and sets the hour
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Hour)} must be 0-23");
                }
                hour = value;
            }
        }

        // property that gets and sets the minute
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Minute)} must be 0-59");
                }

                minute = value;
            }
        }

        // property that gets and sets the second
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if ( value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Second)} must be 0.59");
                }

                second = value;
            }

        }

        // convert to string in universal-time format (HH:MM:SS)
        public string ToUniversalString() =>
            $"{Hour:D2}:{Minute:D2}:{Second:D2}";
        // convert to string in universal-time format (H:MM:SS AM or FM)
        public override string ToString() =>
            $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}:" +
            $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")}";
    }
}
