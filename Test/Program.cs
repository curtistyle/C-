/*string name = "Curtis Style";

Console.WriteLine(name);

var nameSplit = name.Split(" ").ToList();

var newList =
    nameSplit.Select((value, index) => (value, index))
    .Where((value, index) => index == 0)
    .First();

Console.WriteLine("nameSplit: ");
foreach (var item in nameSplit)
{
    Console.Write($"{item}, ");
}
Console.WriteLine();
Console.WriteLine("newList: ");
Console.WriteLine(newList.value);

*/
/*foreach (var element in newList)
{
    Console.Write($"{element}, ");
}*/

string city = "manchester city";

// manchester city
var citySplit = city.Split(' ');
// [manchester, city]
var newList =
    citySplit.Select(value => value.ToList())
    .Select((value, index) => (value, index))
    .Where((value, index) => index == 0)
    .Select(value => value.value.ToString());
    


foreach (var item in newList)
{
    Console.Write($"{item}, ");
}
