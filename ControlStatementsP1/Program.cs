// Control statements 

// if single-selection statements (declaracion if de seleccion simple)


Console.WriteLine("if single selection\n");

float studentGrade1 = 7;

if (studentGrade1 >= 6)
{
    Console.WriteLine($"{nameof(studentGrade1)} -> Aproved");
}

// if double-selection statements

Console.WriteLine("\n\nif double-selection");

float studentGrade2 = 3;


if (studentGrade2 >= 6)
{
    Console.WriteLine($"{nameof(studentGrade2)} -> Aproved");
}
else
{
    Console.WriteLine($"{nameof(studentGrade2)} -> Failed");
}

// Nested if-else statements

Console.WriteLine("\n\nNested if-else");

Console.Write("Enter studen Grade: ");
float studentGrade3 = float.Parse(Console.ReadLine()); 

if ((studentGrade3 > 6) & (studentGrade3 <= 10))
{
    Console.WriteLine("Aproved");
}
else
{
    if ((studentGrade3 >= 0) & (studentGrade3 < 6))
    {
        Console.WriteLine("Failed");
    }
    else
    {
        if (studentGrade3 == 6)
        {
            Console.WriteLine("Regular");
        }
        else
        {
            Console.WriteLine("out of range");
        }
    }
}

// Conditional Operator

Console.WriteLine("\nConditional operator\n");

Console.Write("The car have 3 o 4 wheels?: ");
int wheels = int.Parse(Console.ReadLine());

Console.WriteLine(wheels == 4 ? "True" : "False");

Console.Write("The bike have 3 or 2 wheels?: ");
wheels = int.Parse(Console.ReadLine());

Console.WriteLine(wheels == 2 ? "True" : "False");
