IEnumerable<int> ObtenerArchivo()
{
    for (int archivo = 1; archivo <= 10; archivo++)
    {
        Console.WriteLine("Voy a la base de datos y obtengo el archivo pesado #" + archivo);
        yield return archivo;
        Console.WriteLine("Memoria Liberada");
    }
}

foreach(var archivo in ObtenerArchivo())
{
    Console.WriteLine("Se sube por ftp el archivo #" + archivo);
}

