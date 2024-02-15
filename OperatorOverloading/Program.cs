// prompt the user to enter the first complex number
using OperatorOverloading;

Console.WriteLine("Enter the real part of complex number x: ");
double realPart = double.Parse(Console.ReadLine());

Console.WriteLine("Enter the imaginary part of complex number x: ");
double imaginaryPart = double.Parse(Console.ReadLine());
var x = new ComplexNumber(realPart, imaginaryPart);

// prompt the user to enter the second complex number
Console.WriteLine("\nEnter the real part of complex number y: ");
realPart = double.Parse(Console.ReadLine());
Console.WriteLine("Enter the imaginary part of complex number y: ");
imaginaryPart = double.Parse(Console.ReadLine());
var y = new ComplexNumber(realPart, imaginaryPart);

// display the results of calculations with x and y 
Console.WriteLine();
Console.WriteLine($"{x} + {y} = {x + y}");
Console.WriteLine($"{x} - {y} = {x - y}");
Console.WriteLine($"{x} * {y} = {x * y}");
