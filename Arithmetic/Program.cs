// Arithmetic

int x;
int y;
float res;

// Addition
Console.WriteLine("Addition");
Console.Write("Enter x: ");
x = int.Parse(Console.ReadLine());
Console.Write("Enter y: ");
y = int.Parse(Console.ReadLine());

res = x + y;

Console.WriteLine("Result Addition: " + res);

Console.ReadKey();
Console.Clear();

// Subtraction
Console.WriteLine("Subtraction");
Console.Write("Enter x: ");
x = int.Parse(Console.ReadLine());
Console.Write("Enter y: ");
y = int.Parse(Console.ReadLine());

res = x - y;


Console.WriteLine("Result Subtraction: " + res);

Console.ReadKey();
Console.Clear();

//Multiplication
Console.WriteLine("Multiplication");
Console.Write("Enter x: ");
x = int.Parse(Console.ReadLine());
Console.Write("Enter y: ");
y = int.Parse(Console.ReadLine());

res = x * y;

Console.WriteLine("Result Subtraction: " + res);

Console.ReadKey();
Console.Clear();

// Division
Console.WriteLine("Division");
Console.Write("Enter x: ");
x = int.Parse(Console.ReadLine());
Console.Write("Enter y (y=!0): ");
y = int.Parse(Console.ReadLine());

res = x / y;

Console.WriteLine("Result Division: " + res);

Console.ReadKey();
Console.Clear();

//Remainder
Console.WriteLine("Remainder");
Console.Write("Enter x: ");
x = int.Parse(Console.ReadLine());
Console.Write("Enter y: ");
y = int.Parse(Console.ReadLine());

res = x % y;

Console.WriteLine("Result Remainder: " + res);

Console.ReadKey();
Console.Clear();