// Equality, Relational Operators and Using the If Statement.

Console.WriteLine("Comparing integers. \n");

Console.Write("Enter first number: ");
int number1 = int.Parse(Console.ReadLine());

Console.Write("Enter second nmber: ");
int number2 = int.Parse(Console.ReadLine());

if (number1 == number2)
{
    Console.WriteLine($"{number1} == {number2}");
} 
if (number1 > number2)
{
    Console.WriteLine($"{number1} > {number2}");
}
if (number1 < number2)
{
    Console.WriteLine($"{number1} < {number2}");
}
if (number1 >= number2)
{
    Console.WriteLine($"{number1} >= {number2}");
}
if (number1 <= number2)
{
    Console.WriteLine($"{number1} <= {number2}");
}
if (number1 != number2)
{
    Console.WriteLine($"{number1} != {number2}");
}




