using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppDict.Resource;


namespace AppDict
{
	public class Word
	{
		private string lema;
		private string significado;
		private string catGramatical;
		private string genero;
		private string numero;
		private object conjugaciones;
		public List<string> sinonimos;

		public Word()
		{
			Lema = string.Empty;
			significado = string.Empty;
			catGramatical = string.Empty;
			genero = string.Empty;
			numero = string.Empty;
			sinonimos = new List<string>();
		}

		public Word(string lema, string significado, string catGramatical, string genero, string numero, List<string> sinonimos)
		{
			Lema = lema;
			Significado = significado;
			CatGrametical = catGramatical;
			Genero = genero;
			Numero = numero;
			Sinonimos = sinonimos;
		}

		public string Lema
		{
			get { return lema; }

			set
			{
				if (value.Length > 120)
				{
					throw new ArgumentOutOfRangeException($"The size of {nameof(lema)} must be less than 120 characters");
				}
				else
				{
					lema = value;
				}
			}
		}

		public string Significado
		{
			get { return significado; }

			set
			{
				if (value.Length > 120)
				{
					throw new ArgumentOutOfRangeException($"The size of {nameof(significado)} you set must be less than 120 character.");
				}
				else
				{
					significado = value;
				}
			}
		}	

		public string CatGrametical
		{
			get { return catGramatical; }

			set
			{
				bool isComplete = false;
				foreach ( string item in Enum.GetNames(typeof(CategoriaGramatical)) )
				{
					if (value == item)
					{
						isComplete = true;
						catGramatical = value;
					}
				}
				if (!isComplete)
				{
					throw new ArgumentException($"The value that you set must belong to the \'Categoria Gramatical\'");
				}
			}
		}

		public string Genero
		{
			get { return genero; }

			set
			{
				bool isComplete = false;
                foreach ( string item in Enum.GetNames(typeof(Genero)) )
                {
                    if (value == item)
					{
						isComplete = true;
						genero = value;
					}
                }
				if (!isComplete)
				{
					throw new ArgumentException($"The value that you set must belong to the \'Genero\'");
				}
            }
		}

		public string Numero
		{
			get { return numero; }

			set
			{
				bool isComplete = false;
                foreach (string item in Enum.GetNames(typeof(Numero)))
                {
					if(value == item)
					{
						isComplete = true;
						numero = value;
					}                    
                }
				if (!isComplete)
				{
					throw new ArgumentException($"The value that you set must belong to the \'Numero\'.");
				}
            }
		}

		public List<string> Sinonimos
		{
			get { return sinonimos; }
			set
			{
				if (value.GetType() == typeof(List<string>))
				{
					sinonimos = value;
				}
				else
				{
					throw new ArgumentException($"{nameof(value)} must be of the {typeof(List<string>)} type.");
				}
			}
		}

		public void AddSinonimo(string value)
		{
			Sinonimos?.Add(value.Trim());
		}

		public override string ToString()
		{
			return nameof(Word) + $"({lema}, {significado}, {catGramatical}, {genero}, {numero})";
		}

	}
}
