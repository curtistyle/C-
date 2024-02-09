using System.Linq;
using System.Collections.Generic;

// LINQ with List Collections

// populate a List of string
var items = new List<string>();
// add item to the end of the list
items.Add("aQua"); 
items.Add("RusT");
items.Add("yElLow");
items.Add("rEd");

// display initial List
Console.Write("items contains: ");
foreach (var item in items)
{
    Console.Write($" {item}");
}

Console.WriteLine(); // output end of line

var startsWithR =
    from item in items
    let uppercaseString = item.ToUpper()
    where uppercaseString.StartsWith("R")
    orderby uppercaseString
    select uppercaseString;

// display query results
Console.Write("results of query startsWithR:");
foreach (var item in startsWithR)
{
    Console.Write($" {item}");
}

Console.WriteLine(""); // output end of line

items.Add("rUbY"); // add "rUbY" to the end of the List
items.Add("SaFfRon"); // add "SaFfRon" to the end of the List

// display initial List
Console.Write("items contains: ");
foreach(var item in items)
{
    Console.Write($" {item}");
}

Console.WriteLine();

Console.Write("results of query startsWithR:");
foreach (var item in startsWithR)
{
    Console.Write($" {item}");
}

Console.WriteLine(); // output end of line

