
using FundamentsOfDB.Models;

CervezaDB nuevo = new CervezaDB();

var ls= nuevo.Conectar();

foreach (var item in ls)
{
    Console.WriteLine(item);
}

