//List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };


//Console.WriteLine("MITAD: " + numeros.Count / 2);
//Console.WriteLine(numeros.Display());

//Console.WriteLine(numeros.Slice(numeros.Count / 2, numeros.Count / 2).Display());
//Console.WriteLine(numeros.Slice(0, (numeros.Count / 2)-1).Display());


int[] numeros = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];


Console.WriteLine(numeros.Display());

Console.WriteLine(numeros[0..(numeros.Length/2-1)].Display());
Console.WriteLine(numeros[(numeros.Length/2)..].Display());

public static class Extensions
{
    public static int[] Display(this int[] lista)
    {
        Console.Write("[ ");
        foreach (var item in lista)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("]");
        return lista;
    }
}