using Operaciones;

Conjunto conjunto = new Conjunto('A');

Console.WriteLine(conjunto.Representar());

conjunto.AgregarElemento(2);

Console.WriteLine(conjunto.Representar());

int[] a = [1, 2, 3];

int[] b = [4, 5, 6];

int tamanio = a.Length * b.Length;

List<Tuple<int,int>> resultado = new List<Tuple<int,int>>();

for (int i = 0; i < a.Length; i++)
{
    for (int j = 0; j < b.Length; j++)
    {
        resultado.Add(new Tuple<int, int>(a[i], b[j]));
    }
}








