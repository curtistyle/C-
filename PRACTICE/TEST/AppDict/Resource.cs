using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDict
{
	public class Resource
	{
		public enum CategoriaGramatical
		{
			Sustantivo,
			Adjetivo,
			Verbo,
			Pronombre,
			Adverbio,
			Preposicion,
			Conjuncion,
			Determinantes
		}

		public enum Numero
		{
			Singular,
			Plural,
			None
		}

		public enum Genero
		{
			Masculino,
			Femenino,
			None
		}

	}
}
