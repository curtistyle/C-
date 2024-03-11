int search(string[] lyst, string target, int index = 0)
{
    if (index == lyst.Length)
    {
        return -1;
    }
    else if (target == lyst[index])
    {
        return index;
    }
    else
    {
        return search(lyst, target, index + 1);
    }
}

string[] listOfNames = { "Curtis", "Agustin", "Cristian", "Emanuel" };

Console.WriteLine( search(listOfNames, "Cristian", 0) );



