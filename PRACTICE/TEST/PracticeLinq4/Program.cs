int[] list1 = new int[] { 1, 2, 3, 4, 5 };
int[] list2 = new int[] {4, 5, 6, 7, 8, 9 };

// unir 2 arreglos

int[] unionList =
    list1.Union(list2).ToArray();

unionList.ToList().ForEach(x =>
{
    Console.Write($"{x} ");
});
Console.WriteLine("\n");

// crea una tipla 1 a 1 mesclando 2 lista

int[] list3 = {1, 2, 3, 4, 5};
string[] list4 = { "One", "Two", "Three", "Four", "Five" };

var zipList = 
    list3.Zip(list4).ToList();

zipList.ToList().ForEach(x =>
{
    Console.Write($"{x.ToString()} ");
});


// Concatena los elementos de la matriz especificada o los
// miembros de una colección, usando el separador indicado entre todos los elementos o miembros.

var beers = new List<(string Name, int IdBrand)>{
    ("Pikantus", 1),
    ("Dunkel", 1),
    ("London Porter", 2),
    ("London Pride", 2)
};

var brand = new List<(int IdBrand, string Name)>
{
    (1, "Erdinger"),
    (2, "Fuller's")
};

var newJoin =
    beers.Join(brand, x => x.IdBrand, y => y.IdBrand, (beer, brand) =>
    {
        return new
        {
            Name = beer.Name,
            BrandName = brand.Name,
        };
    });
Console.WriteLine("\n\n");
newJoin.ToList().ForEach(x =>
{
    Console.WriteLine($"{x.Name} {x.BrandName}");
});

Console.WriteLine();

// Determina si todos los elementos de una secuencia satisfacen una condición.

int[] list5 = new int[] { 1, 2, 3, 4, 5 };
int[] list6 = new int[] { 6, 7, 8, 9, 10 };

Console.WriteLine(list5.All(value => value > 5));
Console.WriteLine(list6.All(value => value > 5));

//

var beerBrand = new List<(string Name, List<string> Beer)>
{
    ("Erdinger", new List<string> {"Pikantus", "Dunkel"}),
    ("Delirium", new List<string> {"Tremes", "Red"}),
};

var beerDetail = 
    beerBrand.SelectMany(())