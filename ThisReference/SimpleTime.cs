using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisReference
{
    public class SimpleTime
    {
        private int hour;
        private int minute;
        private int second;

        // if the constructor uses parameter names identical to instance-variable 
        // names, the "this" reference is required to distinguish between the names
        public SimpleTime(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        // use explicit and implicit "this" to call ToUniversalString
        public string BuildString() =>
            $"{"this.ToUniversalString()",24}: {this.ToUniversalString()}" +
            $"{"ToUniversalString()",24}: {ToUniversalString()}";
        
        // convert to string in universal-time format(HH:MM:SS);
        // "this" is not required here to access instance variables, 
        // because the method does not have local variables with the same 
        // names as the instance variables
        public string ToUniversalString() =>
            $"{this.hour:D2}:{this.minute:D2}:{this.second:D2}";
    }
}
