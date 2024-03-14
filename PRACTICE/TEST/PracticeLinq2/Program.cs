List<int> GenerateListOfRandInt(int N, int range)
{
    List<int> list = new List<int>(N);
    Random random = new Random();
    for (int i = 0; i < N; i++)
    {
        list.Add(random.Next(range));
    }
    return list;
}

List<int> myList = GenerateListOfRandInt(10, 100);

myList.Display();

// Display in console all prime numbers
// Sintaxis de Método (Method Syntax):
myList.Where(value => value.IsPrime())
    .Display();

// Sintaxis de Consulta (Query Syntax):

var filter = 
    from value in myList
    where value.IsPrime()
    select value;

filter.Display();

// Display in console all pair and odd numbers
// Syntaxis de Metodo (Method Syntax)
filter =
    from value in myList
    where value.Pair()
    select value;

filter.Display();

filter = from value in myList
    where value.Odd()
    select value;

filter.Display();

// Systaxis de Consulta (Query Syntaxis)
myList.Where(value => value.Pair())
    .Display();

myList.Where(value => value.Odd())
    .Display();



public static class Extension
{
    public static bool IsPrime(this int numero)
    {
        int divisor = 2;
        while (divisor < numero)
        {
            int resto = numero % divisor;
            if (resto == 0)
            {
                return false;
            }
            divisor = divisor + 1;
        }
        return true;
    }

    public static void Display<T>(this IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n");
    }

    public static List<T> ModifyByIndex<T>(this List<T> lyst, T value, int index)
    {
        lyst.Insert(index, value);
        return lyst;
    }

    public static bool Pair(this int value)
    {
        return value % 2 == 0;
    }

    public static bool Odd(this int value)
    {
        return value % 2 != 0;
    }

}
    



