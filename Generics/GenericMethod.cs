// Cod 18.3 GenericMethod
// Using a generic method to display arrays of different types


public class GenericMethod
{
    public void Main()
    {
        // create arrays of int, double and char
        int[] intArray = { 1, 2, 4, 5, 6 };
        double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7 };
        char[] charArray = { 'H', 'E', 'L', 'L', 'O' };

        Console.Write("Array intArray contains: ");
        DisplayArray(intArray); // pass an int array argument
        Console.Write("Array doubleArray contains: ");
        DisplayArray(doubleArray); // pass a double array argument
        Console.Write("Array charArray contains: ");
        DisplayArray(charArray); // pass a char array argument
    }

       
    // output array of all types
    private static void DisplayArray<T>(T[] inputArray)
    {
        foreach (var element in inputArray)
        {
            Console.Write($"{element} ");
        }

        Console.WriteLine();    
    }
}