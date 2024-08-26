

Person CreatePerson(Func<Person, Person> value)
{
    return new Person();
}

class Person
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; } = default;
}