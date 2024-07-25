using System.Collections.Immutable;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using UseIEnumerable;

List<Coche> coches = new List<Coche>()
{
	new Coche("Ford", 4, 3, 2010),
	new Coche("Mercedez Benz", 4, 5, 2023),
	new Coche("Toyota", 4, 5, 2024),
	new Coche("Chevrolet", 4, 4, 2022)
};

/*Tuple<int, int> car = new Tuple<int, int>(2, 2);

Console.WriteLine(car.Item1);*/

var enums = ImmutableList.Create(coches);




foreach (var (item, index) in coches.Select((item, index) => (item, index)))
{
	Console.WriteLine($"{index} : {item.Marca}");
}