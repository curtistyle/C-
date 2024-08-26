Operaciones operaciones = new Operaciones();

// definimos el callback
Action<string> miCallback = (mensaje) => Console.WriteLine(mensaje); 

// llamamos al metodo asíncrono y pasamos el callback
await operaciones.LargaOperacionAsync(miCallback);

public class Operaciones
{
    public async Task LargaOperacionAsync(Action<string> callback)
    {
        Console.WriteLine("Ejecutando una larga operacion asincrona");

        // Simulando una operacion larga
        await Task.Delay(2000);

        // Después de la operación, invocamos el callback
        callback("Operacion completada (async)");
    }
}