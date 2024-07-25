
using System.Linq.Expressions;

Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();


keyValuePairs["name"] = "Curtis";
keyValuePairs["country"] = "Urdinarrain";
keyValuePairs["age"] = 18;

foreach (var item in keyValuePairs.Values)
{
    Console.WriteLine(item);
}


var aux = new MyClass();

aux[0] = "10";

Console.WriteLine(aux[0]);
Console.WriteLine("Count: " + aux);

Expression<Func<int, bool>> lambda = num => num < 5;



Console.WriteLine();


class MyClass
{
	private string? _data;

	private int Count;

	public string this[int index]
	{
		get
		{
			return _data;
		}
		set
		{
			_data = value;
		}
	}



}


