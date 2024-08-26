
NumRandom numero;
int random;

Random random1 = new Random();
random = random1.Next(1, 10);
numero = new NumRandom();

numero.CambiarNumero += CambiarNumero;
numero.CambiarNumero += Success;
numero.CambiarNumero += Fail;

while(random != numero.Number)
{
    Console.WriteLine("Ingresa un numero del 1 al 10");
    numero.Number = int.Parse(Console.ReadLine());  
    numero.Count++;
    if(numero.Count == 3)
    {
        break;
    }
}
void CambiarNumero(object source, int datos)
{
    numero = (NumRandom)source;
    Console.WriteLine($"El numero ha cambiado a {numero.Number}");
};

void Success(object source, int datos)
{
    numero = (NumRandom)source;
    if (numero.Number == random && numero.Count <= 3)
    {
        Console.WriteLine($"Felicidades el numero aleatorio es {numero.Number}");
    }

};

void Fail(object source, int datos)
{
    numero = (NumRandom)source;
    if (numero.Number != random && numero.Count == 3)
    {
        Console.WriteLine($"Lo siento has fallado el numero aleatorio era {random}");
    }
};


public delegate void ManejadorEventos<TEvent>(object source, TEvent datos);

class NumRandom
{
    public int Number { get; set; }
    private int _count { get; set; }

    public int Count
    {
        get => _count;
        
        set 
        {
            if (_count != value)
            {
                _count = value;

                //if(CambiarNumero !=  null)
                //{
                //    CambiarNumero(this, this._count);
                //}  esto es lo mismo que: CambiarNumero?.Invoke(this, this._count);
                CambiarNumero?.Invoke(this, this._count);
            }
        }
    }
    public event ManejadorEventos<int> CambiarNumero;

}

