/*Message<string> myMensaje = new Message<string>("Hello World!", "Carlos");
Console.WriteLine("Mensaje: " + myMensaje + ". User: " + myMensaje.User);
myMensaje = "Hello!";
Console.WriteLine(myMensaje.User);




class Message<T>
{
    public T? _value;
    public string? User { get; set; }

    public Message(T? value)
    {
        _value = value;
    }

    public Message(T? value, string user) : this(value)
    {
        User = user;
    }

    public static implicit operator Message<T>(T source)
    {
        return new Message<T>(source);
    }

    public static implicit operator Message<T>(T source)
    {
        return new Message<T>(source);
    }

    public static implicit operator T(Message<T>? source)
    {
        return source._value;
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}


*/
/*
int[] numeros = [1, 2, 3, 4, 5];
MiClase<int[]> asd = new MiClase<int[]>(numeros);

public class MiClase<T>
{
    private T valor;

    public MiClase(T myList)
    {
        valor = myList;
    }

    public void ImprimirElementos()
    {
        foreach (var item in valor)
        {
            Console.WriteLine(item);
        }
    }
}

*/
