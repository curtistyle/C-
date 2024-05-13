/*var url = "https://jsonplaceholder.typicode.com/todos";

var urls = new string[10].Select((u, index) => url + "/" + (index)).ToList();

urls.ForEach(url =>
{
    Console.WriteLine(url);
});
*/

////////////
///

/*string[] myList = { "Cristina", "Curtis", "Pablo", "Ana", "Marta", "Agustin", "Brian" };


var filterList =
    myList.Where((value) => value[0] == 'A').ToList();
    

Action<List<string>> Display = (value) => 
{
    value.ForEach((item) => {
        Console.WriteLine($"{item}");
    });
};

Display(filterList);
*/
/*
string[] myList = { "Sustantivo", "Adjetivo", "Verbo", "Adverbio" };


foreach (string item in Enum.GetNames<CategoriaGramatical>())
{
	Console.WriteLine(item);	
}


foreach (string element in Enum.GetNames(typeof(CategoriaGramatical)))
{
	Console.WriteLine(element);
}
*/
/*
string[] lyst =
{
	"Carlos",
	"Alan",
	"Pepe",
	"Curtis",
	"Willi",
	"Sebaz"
};


foreach (var item in lyst)
{
	Console.WriteLine(item);
}

var lystOrder = lyst.Order();

foreach (var item in lystOrder)
{
	Console.WriteLine(item);
}
*/



foreach (var item in Enum.GetValues(typeof(CategoriaGramatical)))
{
	Console.WriteLine(item.GetHashCode());
}

enum CategoriaGramatical
{
	Sustantivo,
	Adjetivo,
	Verbo,
	Pronombre,
	Adverbio,
	Preposicion
}



/*string[] myList = { "1", "2", "3", "4" };


Console.WriteLine(myList.Any(value => (value == "5")));*/