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




string palabra = "asd";


Console.WriteLine(palabra.GetHashCode());