Person person = new Person() { Name="Curtis", Age=33,Country="Gualeguay" };

var properties = typeof(Person).GetProperties().ToList();

properties.ForEach(p =>
{
    Console.WriteLine("Name: "+ p.Name);
    Console.WriteLine("Type: " + p.PropertyType.ToString());
    Console.WriteLine("Value: " + p.GetValue(person).ToString());
});

class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }

}

