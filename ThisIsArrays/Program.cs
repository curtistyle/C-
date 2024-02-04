// Declaring and creating arrays

string[] dias = new string[7];

void printList(Array list)
{
    Console.Write("[ ");
    foreach (var item in list)
    {
        Console.Write(item + " ");    
    }
    Console.Write("]");
}


string[] colorList = { "Red", "Blue", "Green", "White", "Black" };

printList(colorList);




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

