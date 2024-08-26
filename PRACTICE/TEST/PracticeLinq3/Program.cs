using PracticeLinq3;

Library publicLinary = new Library("Public Library", new List<Book> {
    new Book("C# in a NutShell", "Developer", "Joseph Albahari", 2024),
    new Book("C# 6 for Programmers", "Developer", "Paul Deitel", 2012),
    new Book("C# ASP.NET Core in Action", "Developer", "Andrew Lock", 2021),
    new Book("Functional Programming with C#", "Developer", "Simon Painter", 2023),
    new Book("Fundamentos de Sistemas de Bases de Datos", "Data Base", "Elmasri & Navathe", 2007),
    new Book("Procesamiento de Bases de Datos; Fundamentos, Diseño e Implementación", "Data Base", "David M. Kroenke", 2003),
    new Book("Transmision de Datos y Redes de Comunicaciones", "Network", "Behrouz Forouzan", 2005)
});

Library privateLibrary = new Library("Private Library", new List<Book> {
    new Book("C# in a NutShell", "Developer", "Joseph Albahari", 2024),
    new Book("Electrónica de Potencia - Convertidores, aplicaciones y diseño", "Electronics", "Ned Mohan", 2004),
    new Book("Procesamiento de Bases de Datos; Fundamentos, Diseño e Implementación", "Data Base", "David M. Kroenke", 2003),
    new Book("Transmision de Datos y Redes de Comunicaciones", "Network", "Behrouz Forouzan", 2005),
    new Book("Álgebra lineal", "Algebra", "Ismael Gutiérrez García", 2010)
});

publicLinary.Books
    .Where(value => (value.Genre == "Developer"))
    .Display();

var filterYear =
from value in privateLibrary.Books
where value.Year < 2010
select value;

filterYear
    .OrderBy(value => value.Year)
    .Display();

int[] myCadena = [1, 2, 3];

myCadena.Display();

public static class Extensions
{
    public static void Display<T>(this IEnumerable<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine($"{item} ");
        }
        Console.WriteLine();
    }
}

