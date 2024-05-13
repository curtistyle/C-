using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE4
{
	class Program
	{
		static void Main(string[] args)
		{
			Lista lista = new Lista();

			lista.SetElemento("Carlos");
		}
	}

	class Lista
	{
		public List<string> elementos;

		public Lista(List<string> elementos)
		{
			this.elementos = elementos ?? throw new ArgumentNullException(nameof(elementos));
		}

		public Lista()
		{
			
		}

		public void SetElemento(string elemento)
		{

			elementos.Add(elemento);
		}
	}
}
