using System;
using System.Collections.Generic;
// Cod: 19.7
namespace LambdaExpression
{
    class Program
    {
        // delegate for a function that recives an int and returns a bool
        public delegate bool NumberPredicate(int number);

        static void Main(string[] args)
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // create an instance of the NumberPredicate delegate type using an
            // implicit lambda expresion
            NumberPredicate evenPredicate = (number) => number % 2 == 0;

            // call a lambda expression through a variable
            Console.WriteLine($"Use a lambda-expresion variable: {evenPredicate(4)}");

            // filter the even number using a lamda expression
            List<int> evenNumbers = FilterArray(numbers, evenPredicate);

            // display the result
            DisplayList("Use a lamda expresion to filter even numbers: ", evenNumbers);

            // filter the odd numbers using an explicity typed lamda expression
            List<int> oddNumbers = FilterArray(numbers, (int number) => number % 2 == 1);

            // display the resutl
            DisplayList("Use a lamda expression to filter odd number: ", oddNumbers);

            // filter numbers greater than 5 using an impricit lamda statement 
            List<int> numbersOver5 = FilterArray(numbers, number => { return number > 5; });

            // display the result 
            DisplayList("Use a lamda expression to filter numbers over 5: ", numbersOver5);
        }

        // select and array's elements that satisfy the predicate
        private static List<int> FilterArray(int[] intArray, NumberPredicate predicate)
        {
            // hold the selected elements 
            var result = new List<int>();

            // iterate over each element in the array
            foreach (var item in intArray)
            {
                // if the element satisfies the predicate 
                if (predicate(item))
                {
                    result.Add(item); // add the element to the result
                }
            }

            return result; // return the result
        }

        // display the elements of a List
        private static void DisplayList(string description,  List<int> list)
        {
            Console.Write(description); // display the output's description

            // iterate over each element in the List
            foreach (var item in list)
            {
                Console.Write($"{item} "); // print item followed by a space 
            }

            Console.WriteLine(); // add a new line 
        }

    }
}
