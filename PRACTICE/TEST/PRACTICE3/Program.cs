/*Crea un método que obtenga la suma de los números naturales desde 1 hasta N. 
 * Se debe pasar como parámetro el número N*/

int SumatoriaN(int N)
{
    if (N < 1)
    {
        return 0;
    }
    else
    {
        return N + SumatoriaN(N - 1);
    }
}

Console.WriteLine(" 1 Sumatoria: " + SumatoriaN(4));

/*Crea un método que imprima los dígitos desde 1 hasta N. 
    Se debe pasar como parámetro el número N*/

void ContadorN(int N)
{
    if (N > 0)
    {
        ContadorN(N - 1);
        Console.Write(N + ", ");
    }

}

Console.WriteLine("Contador de 1 hasta N");
ContadorN(5);

/*Crea un método que imprima los dígitos desde N hasta 1. 
    Se debe pasar como parámetro el número N*/

void Contador2(int N)
{
    if (N > 0)
    {
        Console.Write(N + ", ");
        Contador2(N - 1);
    }

}

Console.WriteLine("\nContador de N hasta 1");
Contador2(5);

/*Crea un método que obtenga la cantidad de dígitos de un número N. 
 * Se debe pasar como parámetro el número N */

int Contador(int N)
{
    if (N <=  0)
    {
        return 0;
    }
    else
    {
        return 1 + Contador(N / 10);
    }
}

Console.WriteLine("");
Console.WriteLine(Contador(2000));


/*Crear un método que obtenga el resultado de elevar un número a otro. 
    Ambos números se deben pasar como parámetros*/

int Elevar(int X, int Y)
{
    if (Y == 0)
    {
        return 1;
    }   
    else
    {
        return X * Elevar(X, Y - 1);
    }
}   

Console.WriteLine("Eleva un numero x a un numero y");
Console.WriteLine(Elevar(1, 1));

/*
 Crea un método que dado un número, lo imprima invertido por pantalla
 */

void InvertirN(int N)
{
    if ( N > 0)
    {
        Console.Write(N % 10);
        InvertirN(N/10);
    }

}
Console.WriteLine("Invertir numero: ");
InvertirN(12);

/*
 Crea un método que imprima por pantalla un 
Rectángulo a partir de los valores de la base y la altura
 */

void ImprimirLinea(int N)
{
    if (N > 0)
    {
        ImprimirLinea(N-1);
        Console.Write("x");
    }
}

void ImprimirRectangulo(int X, int Y)
{
    if ((Y > 0) & (X > 0))
    {
        ImprimirLinea(X);
        Console.WriteLine();
        ImprimirRectangulo(X, Y - 1);
    }

}
Console.WriteLine("\n\n");
ImprimirRectangulo(4, 2);

/*
 Crea un método que imprima por pantalla un 
Triángulo rectángulo a partir del valor de la altura del triángulo
 */

void MostrarLineaTriangulo(int N)
{
    if (N > 0)
    {
        Console.Write("* ");
        MostrarLineaTriangulo(N - 1);
    }
    else
    {
        Console.WriteLine();
    }
}

void MostrarTriangulo(int N)
{
    if (N > 0)
    {
        MostrarTriangulo(N - 1);
        MostrarLineaTriangulo(N - 1);
    }
}

Console.WriteLine();
MostrarTriangulo(5);

