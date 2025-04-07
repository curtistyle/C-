

// Eliminar de una cola de caracteres todas las vocales que aparecen.
static void Exercise01()
{
	var cola = new DataStructure.Queue<string>();

	string[] caracteres = ["q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "ñ", "z", "x", "c", "v", "b", "n", "m"];

	foreach (string caracter in caracteres)
	{
		cola.Arrive(caracter);
	}

	cola.Barrido();

	string[] vocales = ["a", "e", "i", "o", "u"];

	for (int i = 0; i < cola.Size; i++)
	{
		if (vocales.Any(value => value == cola.OnFront()))
		{
			var delete = cola.Attention();
			Console.WriteLine("Attention: " + delete);
		}
		else
		{
			cola.MoveToEnd();
		}
	}

	cola.Barrido();
}

// 2. Utilizando operaciones de cola y pila, invertir el contenido de una cola.
static void Exercise02()
{
	
}

Exercise01();
Exercise02();