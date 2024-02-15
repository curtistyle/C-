/*
 (Count occurrence of numbers) Write a program that reads the integers between 
1 and 100 and counts the occurrences of each. Assume the input ends with 0. Here 
is a sample run of the program: Note that if a number occurs more than one time, the 
plural word “times” is used in the output. Numbers are displayed in increasing order.
 */

void CountOccurrenceOfNumber()
{
    void Count(int[] Lyst)
    {
        Console.Write($"Enter number: ");
        int Number = int.Parse(Console.ReadLine());
        while (Number != 0)
        {
            if (Number >= 0 && Number <= 100)
            {
                Lyst[Number - 1]++;
            }
            Console.Write($"Enter number: ");
            Number = int.Parse(Console.ReadLine()); 
        }
    }

    void DisplayList(int[] Lyst)
    {
        int i = 0;
        while (Lyst[i] != 0)
        {
            Console.WriteLine($"{i + 1} occurs {Lyst[i]} time" + (Lyst[i] > 1 ? "s." : ". "));
            i++;
        }
    }

    int[] MyList = new int[10];
    Console.WriteLine($"Load list: ");
    Count(MyList);
    DisplayList(MyList);

}

CountOccurrenceOfNumber();

/*
(Imprimir números distintos) Escribe un programa que lea 10 números 
y muestre la cantidad de números distintos y los números 
distintos en su orden de entrada y separados por exactamente un espacio 
(es decir, si un número aparece varias veces, se muestra solo una vez). 
(Pista: Lee un número y guárdalo en un array si es nuevo. 
Si el número ya está en el array, ignóralo). 
Después de la entrada, el array contiene los números distintos. 
Aquí tienes una ejecución de ejemplo del programa:
 */

void PrintDistinctNumbers()
{
    int[] myList = new int[10];
    for (int i = 0; i < myList.Length; i++)
    {
        Console.Write("Enter a number: ");
        int Number = int.Parse(Console.ReadLine());
        bool isnew = false;

        for (int j = 0; i <= i + 1; j++)
        {
            if (myList[j] == Number)
            {

            }
        }
    }
}