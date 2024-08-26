
Action Execute(int n)
{
    bool sentinella = false;
    int index = 0;
    Console.WriteLine("Inicializacion Completada");
    return () =>
    {
        if (index<n)
        {
            Console.WriteLine("Se inicio la Encapsulacion");
        }
        else
        {
            Console.WriteLine("Se termino la Encapsulacion");
        }
        index++;
    };
}
Action miFuncion = Execute(3);

miFuncion();
miFuncion();
miFuncion();
miFuncion();
miFuncion();
