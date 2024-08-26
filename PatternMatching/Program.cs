List<Person> persons = new List<Person>()
{
    new Person("Carlos", 39, "Parera"),
    new Person("Marta", 22, "Urdinarrain"),
    new Person("Pedro", 12, "Urdinarrain"),
    new Person("Agustin", 40, "Parera")
};

string RangoEdad(Person person) => person.Age switch
{
    >= 0 and <= 4   => "Bebe",
    > 4  and <= 13  => "Niñes",
    > 13 and <= 17  => "Adolecencia",
    > 17 and <= 35  => "Adulto Joven",
    > 35 and <= 64  => "Adulto",
    > 64  => "Tercera Edad",
    _ => "Error"
};

Console.WriteLine(RangoEdad(persons[1]));

class Person
{
    public Person(string? name, int age, string? country)
    {
        Name = name;
        Age = age;
        Country = country;
    }

    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}