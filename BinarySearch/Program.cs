/*
int BinarySearch(int[] lyst, int search)
{
    int low = 0;
    int high = lyst.Length - 1;

    while (high >= low)
    {
        int mid = (low + high) / 2;
        if (search < lyst[mid])
        {
            high = mid - 1;
        } else if (search == lyst[mid])
        {
            return mid;
        }
        else
        {
            low = mid + 1;
        }
    }
    return -low - 1;
}
*/

int busquedabinaria(int[] lista, int buscado)
{
    int primero = 0;
    int ultimo = lista.Length - 1;

    while (primero <= ultimo)
    {
        int medio = (primero + ultimo) / 2;
        if (lista[medio] == buscado)
        {
            return medio;
        } else if (lista[medio] < buscado)
        {
            primero = medio +1;
        }
        else
        {
            ultimo = medio - 1;
        }
    }
    return -1;
}


int[] myList = [2, 4, 6, 8, 10, 12];
//int res = BinarySearch(myList, 2);
int res = busquedabinaria(myList, 10);
Console.WriteLine(">"+ res);