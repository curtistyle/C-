/*int product;
int index = 1;

Console.Write("Enter a number 1..10: ");
product = int.Parse(Console.ReadLine());

if ((product >= 1) & (product <= 10))
{
    while (index <= 10)
    {
        Console.WriteLine($"{product} x {index} = {product * index}");
        index++;
    }
}

Console.ReadKey();
Console.Clear();
index = 1;

Console.Write("Enter a number 1..10: ");
product = int.Parse(Console.ReadLine());

while (((product >= 0) & (product <= 10)) & (index <= 10))
{
    Console.WriteLine($"{product} x {index} = {product * index}");
    index++;
}

Console.ReadKey();
Console.Clear();
index = 1;
bool sentinela = true;

Console.Write("Enter a number 1..10: ");
product = int.Parse(Console.ReadLine());

while (sentinela)
{
    Console.WriteLine(index <= 10 ? $"{product} x {index} = {index * product}" : sentinela = false);
    index++;
}
Console.ReadKey();
Console.Clear();
*/

// implementing counter-controlled iterataor

/*
 A una clase de 10 estudiantes se les aplicó un examen. Las caliﬁcaciones (enteros en el rango de 0 a 100) de este exa-
men están disponibles para su análisis. Determine el promedio de la clase en el examen.
 */

int numberStudent = 1; // numero de estudiante
int qualification = 0;
double average = 0.0;

while (numberStudent <= 10)
{
    Console.Write($"Enter qualification of student {numberStudent}: ");
    qualification = int.Parse(Console.ReadLine());
    numberStudent++;
}






