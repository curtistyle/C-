var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
bool esDivisible(int value) => value % 2 == 0;

var miPredicado = new Predicate<int>(esDivisible);

var divisibles = numeros.FindAll(miPredicado);

Console.WriteLine("Predicado : \'Numeros divisibles x 2\'");
divisibles.ForEach(value =>
{
    Console.Write(value + " ");
});

// *********************************************** invierte el resultado del predicado

Console.WriteLine("\nPredicado : \'Numeros NO divisibles x 2\'");

Predicate<int> miPredicadoNegativo = value => !miPredicado(value);


var noDivisibles = numeros.FindAll(miPredicadoNegativo);

noDivisibles.ForEach(value =>
{
    Console.Write(value + " ");
});
