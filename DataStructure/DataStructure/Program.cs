// main 

using DataStructure;

int[] lst = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

//Console.WriteLine(lst[..(lst.Length/2)].Display());

int[] valor = BusquedaBinaria.Busqueda(lst, 2);


valor.ToList().ForEach(x =>
{
    Console.WriteLine(">" + x);
});

