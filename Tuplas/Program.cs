Person prs = new Person("Sebastian", "Maldonado");
Person prs2 = new Person("Lorraine", "Martinez");
Person prs3 = new Person("Pedro", "Clinton");

// ******************************
// TUPLAS
// ******************************

// FORMA 1
(Person, int, string) cliente = (prs, 12, "Urdinarrain");
Console.WriteLine("FORMA 1: " + cliente + "\n");

// FORMA 2
var cliente2 = (prs2, 12, "Gualeguaychu");
Console.WriteLine("FORMA 2: "+cliente2);
Console.WriteLine(cliente2.Item1);
Console.WriteLine(cliente2.Item2);
Console.WriteLine(cliente2.Item3 + "\n");

// FORMA 3
var cliente3 = (
    Persona: prs3,
    Edad: 22,
    Ciudad:  
    "Concepcion del Uruguay"
    ); 
Console.WriteLine("FORMA 3: " + cliente3 +"\n");

// DESCONTRUCTOR (Deconstructing )

var (nombre, apellido) = new Person("Curtis", "Style");
Console.WriteLine($"Deconstruct / {nameof(nombre)} : {nombre}, {nameof(apellido)} : {apellido}");

class Person
{
    public string Name { get; set; }
    public string LastName { get; set; }


    public void Deconstruct(out string name, out string lastName) => 
        (name, lastName) = (Name, LastName);

    public Person(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }

    public string Repr()
    {
        return $"{nameof(Person)}({Name}, {LastName})";
    }

    public override string? ToString()
    {
        return Repr();
    }
}


/*class Cuadrado
{
    public int Altura { get; set; }
    public int Ancho { get; set; }

    public Cuadrado(int altura, int ancho)
    {
        Altura = altura;
        Ancho = ancho;
    }
}*/