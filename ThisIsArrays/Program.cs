// Declaring and creating arrays

string[] dias = new string[7];

void printList(Array list)
{
    Console.Write("[ ");
    foreach (var item in list)
    {
        Console.Write(item + " ");    
    }
    Console.WriteLine("]");
}


string[] colorList = { "Red", "Blue", "Green", "White", "Black" };

// printList(colorList);


void anotherPrintList(Array list)
{
    var enumerator = list.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine($"Enumerator colorList is {enumerator.Current}");
    }
}


// anotherPrintList(colorList);

/*
Console.WriteLine("Length: ",dias.Length);

for (int i = 0; i < dias.Length; i++)
{
    dias[i] = Console.ReadLine();
}

for (int i = 0;i < dias.Length; i++)
{
    Console.WriteLine(dias[i]);
}
*/

void ValueToStoreInEachArrayElement()
{
    const int ArrayLength = 5;
    int[] array = new int[ArrayLength];

    // calculate value for each array element
    for (int i = 0; i < ArrayLength; i++)
    {
        array[i] = 2 + 2 * i;
    }

    Console.WriteLine($"{"Index"}{"Value",8}");

    for (int i = 0;i < ArrayLength; i++)
    {
        Console.WriteLine($"{i,5}{array[i],8}");
    }

}

// ValueToStoreInEachArrayElement();

void MoreOnImplicitlyTypedLocalVariables()
{
    var numbers = new[] { 100, 300, 500, 600 };
    
    for (int i = 0;i < numbers.Length; i++)
    {
        Console.WriteLine(numbers[i]);
    }
}

// MoreOnImplicitlyTypedLocalVariables();

/*
    Twenty students were asked to rate on a scale of 1 to 5 the quality of the food in the
    student cafeteria, with 1 being “awful” and 5 being “excellent.” Place the 20 responses
    in an integer array and determine the frequency of each rating.
 */


void StudentPol()
{
    // student response array (more typically, input at runtime)
    int[] responses = { 1, 2, 5, 4, 3, 5, 2, 1, 3, 3, 1, 4, 3, 3, 3, 2, 3, 3, 2, 14 };

    var frecuency = new int[6]; // array of frecuency counters

    // for each answer, select responses element and use that value
    // as frecuency index to determine element to increment

    for (var answer = 0; answer < responses.Length; ++answer)
    {
        try
        {
            ++frecuency[responses[answer]];
            printList(frecuency);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"      responses[{answer}] = {responses[answer]}\n");
        }

    }
    Console.WriteLine($"{"Rating"}{"Frecuency",10}");
    
    for (var rating = 1; rating < frecuency.Length; ++rating)
    {
        Console.WriteLine($"{rating,6}{frecuency[rating],10}");
    }
}

// StudentPol();


int[] Multiplication(int number)
{
    int[] result = new int[10];
    for (int i = 1; i <= 10; i++)
    {
        result[i-1] = number * i;
    }
    return result;
}

printList(Multiplication(2));