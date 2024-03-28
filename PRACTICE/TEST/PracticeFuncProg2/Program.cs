var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

Func<int, bool> GetPair = (value) => value % 2 == 0;

numbers.Where(GetPair)
    .ToList()
    .ForEach(value =>
    {
        Console.WriteLine(value);
    });

Action<int> print = (value) => Console.WriteLine("\n"+value);

print(2);

Action<List<int>> Display = (value) =>
{
    value.ForEach( value => print(value));
};

Display([1, 2, 3, 4, 5, 6, 6]);


Func<int, Func<int, int>, int> fnHigterOrder = (number, fn) =>
{
    if (number > 20)
    {
        return fn(number);
    }
    else
    {
        return number;
    }
};
Console.WriteLine("Funcion de orden superior:");
Console.WriteLine(
    fnHigterOrder(30, (value) => value * 2)
    );