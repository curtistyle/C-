int count;

for (count = 0; count < 10; count++)
{
    if (count == 5)
    {
        break;
    }
    Console.Write($"{count} ");
}

Console.WriteLine($"\nBroke uout of loop at {count}");    

Console.ReadKey();
Console.Clear();

for ( count = 0; count <= 10; count++)
{
    if ( count == 5) 
    { 
        continue;
    }
    Console.Write($"{count} ");
}
Console.WriteLine($"\nUsed continue to skip displaying 5");