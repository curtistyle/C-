using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    public class Program
    {
        static void Main(string[] args)
        {
            var values = new List<int> { 3, 10, 6, 1, 4, 8, 2, 5, 9, 7 };

            Console.Write("Original values");
            values.Display(); // call Display extension method

            // display the Min, Max, Sum and Average
            Console.WriteLine($"\nMin: {values.Min()}");
            Console.WriteLine($"Max: {values.Max()}");
            Console.WriteLine($"Sum: {values.Sum()}");
            Console.WriteLine($"Average: {values.Average()}");

            // sum of values via Agregate
            Console.WriteLine("\nSum via agregate method: " +
                values.Aggregate(0, (x, y) => x + y));

            // sum of square of values via Agregate
            Console.WriteLine("Sum of squares via Agregate method: " +
                values.Aggregate(0, (x, y) => x + y * y));

            // product of values via Agregate 
            Console.WriteLine("Product via Agregate method: " + 
                values.Aggregate(1, (x, y) => x * y));

            // even values displayed in sorted order
            Console.Write("\nEven values displayed in sorted order: ");
            values.Where(value => value % 2 == 0) // find even integers
                .OrderBy(value => value)  // sort remmaining values
                .Display(); // show results
            
            // odd values multiplied by 10 and displayed in sorted order
            Console.Write("Odd values multiplied by 10 displayed in sorted order: ");
            values.Where(value => value % 2 != 0) // find odd integers
                .Select(value => value * 10) // multiply each by 10
                .OrderBy(value => value) // sort the value
                .Display(); // show results

            // display original values again to prove they were not midified 
            Console.Write("\nOriginal Values: ");
            values.Display(); // call Display extension method
        }
    }
    
    // declared an extendion method
    static class Extension
    {
        // extension method that displays all elements separated by space
        public static void Display<T>(this IEnumerable<T> data)
        {
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
