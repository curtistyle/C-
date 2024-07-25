using System.Collections.Frozen;

List<int> list = [1, 2, 3, 4, 5];

var newList = list.ConvertAll(new Converter<int, string>(IntToString));

foreach (var item in newList)
{
	Console.WriteLine($"{item} : TYPE: {item.GetType()}");
}

static string IntToString(int value)
{
	return value.ToString();
}
