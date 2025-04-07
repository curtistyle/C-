using System.Collections.Generic;

namespace Operaciones
{
    public class Conjunto
    {
        public char Nombre;
        public List<int> Elementos;

        public Conjunto(char nombre)
        {
            Nombre = char.ToUpper(nombre);
            Elementos = new List<int>();
        }

        public Conjunto(char nombre, List<int> elementos) : this(nombre)
        {
            Elementos = elementos;
        }

        public void AgregarElemento(int elemento)
        {
            Elementos.Add(elemento);
        }

        public string Representar()
        {
            return $"{this.Nombre}=" + "{" + string.Join(",", Elementos) + "}";
        }

    }
}
