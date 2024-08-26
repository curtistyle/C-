string[] ciudades1 = ["Urdinarrain", "Gualeguaychu", "Aldea San Antonio"];
string[] ciudades2 = ["Concepcion del Uruguay", "Herrera", "Caseros"];
string[] ciudades3 = ["Parana", "Oro Verde", "Federacion"];

string[] todasLasCiudades = [.. ciudades1,.. ciudades2,.. ciudades3];

foreach(var ciudad in todasLasCiudades)
{
    Console.WriteLine(ciudad);
}

