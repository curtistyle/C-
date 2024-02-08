using System.Linq;

// create a integer array
var values = new[] { 2, 9, 5, 0, 3, 7, 1, 4, 8, 5 };

// display original values
Console.Write("Original array: ");
foreach (var element in values)
{
    Console.Write($" {element}");
}

// Consulta LINQ, que obtiene valores mayores a 4 del arreglo
var filtered =
    from value in values // source data is value
    where value > 4
    select value;

// display filtered results
Console.Write("\nArray values greater than 4: ");
foreach (var element in filtered)
{
    Console.Write($" {element}");
}

// use la clausula orderby para ordenar los valores originales en orden ascendente
var sorted =
    from value in values // source data is value
    orderby value
    select value;

// display sorted results
Console.Write("\nOriginal array, sorted: ");
foreach (var element in sorted)
{
    Console.Write($" {element}");
}

// sort the filtred results into desending order
var sortFilteredResults =
    from value in filtered
    orderby value descending
    select value;

// display the sorted results
Console.Write("\nValues greater than 4, desending order (two queries)");
foreach (var element in sortFilteredResults)
{
    Console.Write($" {element}");
}

// filtred original array and sort results in descending order
var sortAndFilter = 
    from value in values
    where value > 4
    orderby value descending
    select value;

// display the filtered and sorted results
Console.Write("\nValues greater than 4, descending order (one query)");
foreach (var element in sortAndFilter)
{
    Console.Write($" {element}");
}

Console.WriteLine();

