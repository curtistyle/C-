PersonServices personServices = new PersonServices();

personServices.ConfigurePerson(value =>
{
    value.Name = "Carlos";
    value.Age = 22;
    value.Country = "Uruguay";
});




class PersonServices
{
    public void ConfigurePerson(Action<Person> configure)
    {
        Person person = new Person();

        configure(person);

        Console.WriteLine($"Cambios Aplicado: Name={person.Name}, {person.Age}, {person.Country}");
    }
}

class Person
{
    public string? Name { get; set; }
    public int Age { get; set; } = default;
    public string? Country { get; set; }
}

