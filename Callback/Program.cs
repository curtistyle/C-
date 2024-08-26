// main
Operaciones operaciones = new Operaciones();

// definimos el callback usando una expresion lamda
CallkackDelegate miCallback = mensaje => Console.WriteLine(mensaje);

// llamamos al metodo que realiza la operacion larga y le pasamos el callback
operaciones.LargaOperacion(miCallback);




public class Operaciones
{
    public void LargaOperacion(CallkackDelegate callkack)
    {
        Console.WriteLine("Ejecutando una operacion larga...");

        // Simulación de una operacion larga
        System.Threading.Thread.Sleep(2000);

        // Despues de la operación, se invoka el callback
        callkack("Operacion Completa");

    }
}

public delegate void CallkackDelegate(string mensaje);