using System.Reflection.Metadata.Ecma335;

// main

List<Persona> personas = new List<Persona>
{
    new Persona("Carlos", 25, "Gualeguaychu"),
    new Persona("Marta", 18, "Concepcion del Uruguay"),
    new Persona("Emma", 17, "Concepcion del Uruguay"),
    new Persona("Pedro", 30, "Urdinarrain"),
    new Persona("Mirta", 16, "Rosario"),
};

void MayoresDe(List<Persona> prs, Predicate<Persona> condicion)
{
    var mayoresDe = prs.FindAll(condicion);
    mayoresDe.ForEach(value => Console.WriteLine(value.Name));
}

Console.WriteLine("Mayores de edad: ");
MayoresDe(personas, value => value.Age >= 18);

// usando un extension methods

Console.WriteLine("\nMenores de edad: ");
personas.MenoresDe(value => value.Age < 18);

// fin main


public class Persona
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }

    public Persona(string? name, int age, string? country)
    {
        Name = name;
        Age = age;
        Country = country;
    }
}

public static class Extensions
{
    public static void MenoresDe(this List<Persona> prs, Predicate<Persona> condicion)
    {
        var mayoresDe = prs.FindAll(condicion);
        mayoresDe.ForEach(value => Console.WriteLine(value.Name));
    }
}