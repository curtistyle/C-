using System.Collections;
using System.ComponentModel.Design;


/*int[] Reverse(int[] lyst)
{
    int[] lystAux = new int[lyst.Length];

    for (int i = 0; i < lyst.Length; i++)
    {
        lystAux[lyst.Length - i - 1] = lyst[i];
    }

    return lystAux;
}

var res = Reverse(lyst1);

for (int i = 0; i < res.Length; i++)
{
    Console.Write(res[i]);
}*/


/*
int[] lyst1 = { 1, 2, 3, 4, 5 };

int[] Invertir(int[] lyst, int size)
{
    if (size == lyst.Length - 1)
    {
        return lyst;
    }
    else
    {
        return Invertir([lyst[lyst.Length - 1]], size + 1);
    }
}

var res = Invertir(lyst1, 0);

for (int i = 0; i < lyst1.Length; i++)
{
    Console.Write(" ", lyst1[i]);
}
*/


/*int[] Recorrer(int[] list, int pos = 0)
{
    if (pos == list.Length)
    {
        return lyst;
    }
    else
    {
        list[pos] += 2;
        return Recorrer(list, pos + 1);
    }
}

int[] newList = Recorrer(lyst);*/


int[] Invertir(int[] lyst, int pos = 0)
{
    if (pos == lyst.Length / 2)
    {
            return lyst;
    }
    else
    {
        int aux = lyst[pos];
        lyst[pos] = lyst[lyst.Length - pos -1];
        lyst[lyst.Length - pos - 1] = aux;
        return Invertir(lyst, pos + 1);
    }
}

int Sumar(int[] lyst, int pos = 0)
{
    if (pos == lyst.Length) 
    {
        return 0;
    }
    else
    {
        return lyst[pos] + Sumar(lyst, pos + 1);
    }
}




/*static void InvertirArrayRecursivo(int[] arr, int inicio, int fin)
{
    if (inicio < fin)
    {
        // Intercambiar los elementos en las posiciones inicio y fin
        int temp = arr[inicio];
        arr[inicio] = arr[fin];
        arr[fin] = temp;

        // Llamada recursiva con las posiciones ajustadas
        InvertirArrayRecursivo(arr, inicio + 1, fin - 1);
    }
}*/


int[] asd = { 10, 20, 30, 40, 50 };

var newlyst = Invertir(asd);
Console.WriteLine();

for (int i = 0; i < newlyst.Length; i++)
{
    Console.Write(newlyst[i]);
}

