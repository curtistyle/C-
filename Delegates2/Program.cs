// ********************************************
// FORMA 1 : DELEGADOS
// ********************************************

// Mayor
int BuscarNumeroMayor(List<int> lst_)
{
    return lst_.OrderByDescending(value => value).First();
}

// Menor
int BuscarNumeroMenor(List<int> lst_)
{
    return lst_.OrderBy(value => value).First();
}

Buscar fn1 = BuscarNumeroMayor;
Buscar fn2 = BuscarNumeroMenor;


Console.WriteLine("Mayor: " + fn1(new List<int> { 5, 2, 1, 3 })); 
Console.WriteLine("Menor: " + fn2(new List<int> { 5, 2, 1, 3 }));


// ********************************************
// FORMA 2 : DELEGADOS CON FUNCIONES ANONIMAS
// ********************************************

// Retorna el primer numero par
Buscar fn3 = delegate (List<int> lst)
{
    return lst.Where(value => value % 2 == 0)
        .First();
};


Console.WriteLine("Primer numero par de la lista: " + fn3(new List<int> { 3, 1, 7, 2, 5 }));

// Retorna la posicion del elemento mas grande
Buscar fn4 = (lst) => lst.IndexOf(lst.Max());

Console.WriteLine("La posicion del elemento mas grande es: " + fn4(new List<int> { 3, 1, 7, 2, 5 }));


// Otro ejemplo
Persona persona = new Persona();
persona.Mayor(fn4, [1, 3, 4, 5, 2]);


delegate int Buscar(List<int> lst);



class Persona
{
    public void Mayor(Buscar funcion, List<int> lst)
    {
        Console.WriteLine("Buscar el primer mayor de edad (18)!");

        int primerMayor = funcion(lst);

        Console.WriteLine("El primer mayor de edad esta en la posicino: "+ primerMayor.ToString());
    }
}