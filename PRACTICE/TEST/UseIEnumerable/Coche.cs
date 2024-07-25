using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseIEnumerable
{
	public class Coche
	{
		public string? Marca { get; set; }
		public int NumeroRuedas { get; set;}
		public int NumeroPuertas { get; set; }
		public int Modelo { get; set; }
		
		public Coche(string? marca, int numeroRuedas, int numeroPuertas, int modelo)
		{
			Marca = marca;
			NumeroRuedas = numeroRuedas;
			NumeroPuertas = numeroPuertas;
			Modelo = modelo;
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
			return base.ToString();
		}
	}
}
