using System;
using System.Collections.Generic;

namespace Delegates
{
    public class Program
    {
        // delegate for a function that recives an int and returns a bool
        public delegate bool NumberPredicate(int number);

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // create an instance of the NumberPredicate delegate type
            NumberPredicate evenPredicate = IsEven;

            // call IsEven using a delegate
            Console.WriteLine($"Call IsEven using a delegate variable: {evenPredicate(4)}");

            // filter the even numbers using method IsEven
            List<int> evenNumbers = FilterArray(numbers, evenPredicate);

            // display the result
            DisplayList("Use IsEven to filter even numbers: ", evenNumbers);

            // filter the odd numbers using method isOdd
            List<int> oddNumbers = FilterArray(numbers, IsOdd);

            // display the resutl
            DisplayList("Use IsOdd to filter odd numbers: ", oddNumbers);

            // filter number greater than 5 using method IsOver5
            List<int> numberOver5 = FilterArray(numbers, IsOver5);

            // display the result
            DisplayList("Use IsOver5 to filter number over 5: ", numberOver5);
        }

        // select an array's elements that satisfacy the predicate
        private static List<int> FilterArray(int[] intArray, NumberPredicate predicate)
        {
            // hold the selected elements 
            var result = new List<int>();

            // iterate over each elements in the array
            foreach(var item in intArray)
            {
                // if the element satisfies the predicate
                if (predicate(item)) // invoke method reference by predicate
                {
                    result.Add(item); // add the element to the result
                }
            }

            return result; // return the result
        }

        // determine whether an int is even
        private static bool IsEven(int number) => number % 2 == 0;

        // determine whether an int is odd
        private static bool IsOdd(int number) => number % 2 == 1;

        // determine whether an int greater than 5
        private static bool IsOver5(int number) => number > 5;

        // display the element of a List
        private static void DisplayList(string description, List<int> list)
        {
            Console.Write(description); // display the output's description

            // iterate over each elemnt in the list

            foreach ( var item in list)
            {
                Console.Write($"{item} "); // print item followed by the space 
            }

            Console.WriteLine(); // add a new line
        }

    }
}
