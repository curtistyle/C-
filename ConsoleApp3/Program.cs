int[] CreateList(int size)
{
    int[] newList = new int[size];
    return newList;
}

void DisplayList(int[] lyst)
{
    for (int i = 0; i < lyst.Length; i++)
    {
        Console.Write(" " + lyst[i]);
    }
}

void DisplayListReverse(int[] lyst)
{
    Console.Write(" > List reverse: [");
    for (int i = lyst.Length - 1; i >= 0; i--)
    {
        Console.Write(" " + lyst[i]);
    }
    Console.WriteLine(" ]");
}

int MaxList(int[] lyst)
{
    int max = lyst[0];
    for(int i = 1;i < lyst.Length;i++)
    {
        if (lyst[i] > lyst[i - 1])
        {
            max = lyst[i];
        }
    }
    return max;
}

float AverageList(int[] lyst)
{
    float average = 0;
    for(int i = 0;i < lyst.Length;i++)
    {
        average += lyst[i];
    }
    return average / lyst.Length;
}

void LoadAllList(int[] lyst)
{
    for(int i = 0; i<lyst.Length;i++)
    {
        Console.Write($"Item \'{i + 1}\': ");
        lyst[i] = int.Parse(Console.ReadLine());
    }
}

void LoadUntillList(int[] lyst)
{
    int index = 0;
    
    Console.WriteLine("Add item? (s/n)");
    char opc = Console.ReadKey().KeyChar;

    while ((index < lyst.Length) && (opc == 's'))
    {
        Console.Write($"Item \'{index + 1}\': ");
        lyst[index] = int.Parse(Console.ReadLine());
        Console.WriteLine("Add item? (s/n)");
        opc = Console.ReadKey().KeyChar;
        index++;
    }
}

Console.Write("Enter a size of the list: ");
int size = int.Parse(Console.ReadLine());

int[] myList = CreateList(size);

LoadAllList(myList);
//LoadUntillList(myList);

Console.WriteLine("Max element of the List: " + MaxList(myList));
Console.WriteLine("Average: " + AverageList(myList));

DisplayListReverse(myList);