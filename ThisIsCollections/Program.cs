// List<T> Collection

List<int> intList; // declare intList as a List Collection that can store only int value

List<string> stringList;  // declares stringList as a List of references to String


// create a new List of string
var items = new List<string>();

// display List's Count and Capacity before adding elements
Console.WriteLine("Before adding to items: " + $"Count = {items.Count}; Capacity {items.Capacity}");

items.Add( "Red" ); // append an item to the list
items.Insert(0, "Yellos"); // insert the value at index 0

// display List's Count and Capacity after adding two elements 
Console.WriteLine("After adding two elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

// display the colors in the list
Console.Write("\nDisplay list contents with counter-controlled loop: ");
for (var i = 0; i < items.Count; i++)
{
    Console.Write($" {items[i]}");
}

items.Add("Green"); // add "green" to the end of the List
items.Add("Yellow"); // add "yellow" to the end of the List

// display List's Count and Capacity after adding two more elements
Console.WriteLine("\n\nAfter adding two more elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

// display the List
Console.Write("\nList with two new elements: ");
foreach (var item in items)
{
    Console.Write($" {item}");
}

items.Remove("Yellow"); // remove the first yellow

// display the List
Console.Write("\n\nRemove first instance of yellow: ");
foreach (var item in items)
{
    Console.Write($" {item}");
}

// display List's Count and Capacity after removing two elements 
Console.WriteLine("\nAfter removing two elements from items: " + $"Count = {items.Count}; Capacity {items.Capacity}");

// check if a value is in the List
Console.WriteLine($"{(items.Contains("red") ? string.Empty : "not ")} in the List");

Console.WriteLine("\n\"red\" is " + $"{(items.Contains("red") ? string.Empty : " not")} in the list");

items.Add("Orange"); // add "orange" to the end of the list
items.Add("Violet"); // add "violet" to the end of the list
items.Add("Blue"); // add "blue" to the end of the list

// display List's Count and Capacity after adding there elements
Console.WriteLine("\nAfter adding theree more elements to items: " + $"Count {items.Count}; Capacity = {items.Capacity}");

// display the List
Console.Write("List with three new elements: ");
foreach (var item in items)
{
    Console.Write($" {item}");
}
Console.WriteLine();