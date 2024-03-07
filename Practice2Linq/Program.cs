using System.Collections.Generic;
using System.Linq;

int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

list.Mostrar();

var newList =
    list.Where(value => value > 4)
    .Select(value => value);

newList.Mostrar();

newList.Select(value => Math.Pow(value,3))
    .Mostrar();



static class Expressions
{
    public static void Mostrar<T>(this IEnumerable<T> myList)
    {
        foreach (var item in myList)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}