

List<int> listaNumeros = [1, 2, 3, 4, 5];

string[] listaCadenas = ["Lunes", "Martes", "Miercoles", "Jueves", "Viernes"];

listaNumeros.Display();

public static class Extensions
{
    public static void Display<TSource>(this List<TSource> list)
    {
        
        foreach (TSource item in list)
        {
            Console.WriteLine($"{item} ");
        }
        Console.WriteLine();
    }

}