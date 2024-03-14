using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentsOfDB.Models
{
    public class Cerveza
    {
        public string Nombre {  get; set; }
        public string Marca {  get; set; }
        public int Alchool { get; set; }
        public int Cantidad { get; set; }

        public Cerveza() { }

        public Cerveza(string nombre, string marca, int alchool, int cantidad)
        {
            Nombre = nombre;
            Marca = marca;
            Alchool = alchool;
            Cantidad = cantidad;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{nameof(Cerveza)}( {Nombre}, {Marca}, {Alchool}, {Cantidad} )";
        }
    }
}
