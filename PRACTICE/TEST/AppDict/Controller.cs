using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppDict
{
	public class Controller
	{
		Dictionary dictionary = new Dictionary(new List<Word>
		{
			new Word("Car", "Carro", "Sustantivo", "Masculino", "Singular", new List<string> { "Carro", "Vehiculo", "Auto"}),
			new Word("Boat", "Bote", "Sustantivo", "Femenino", "Singular", new List<string> {"Barco", "Lancha"}),
			new Word("Search", "Busquesa", "Sustantivo", "None", "Singular", new List<string> {"Registro", "Inspeccion", "Consulta"}),
			new Word("Search", "Buscar", "Verbo", "None", "None", new List<string> {"Registrar", "Examinar", "Cachear"}),
			new Word("House", "Casa", "Sustantivo", "Femenino", "Plural", new List<string> {"Vivienda", "Hogar", "Choza"}),
			new Word("Search", "Buscar", "Verbo", "None", "None", new List<string> {"Registrar", "Examinar"})
		});


		public Controller()
		{

		}

		public void AgregarPalabra()
		{
			Word word = new Word();
		
			// set Lema
			Console.Write("Ingrese el Lema: ");
			word.Lema = Console.ReadLine();

			// set Significado
			Console.Write("Ingrese el Significado: ");
			word.Significado = Console.ReadLine();

			// set Categoria Gramtical
			Console.WriteLine("Seleccione la Categoria Gramatical: ");
			string[] listCategoriaGramatical = Enum.GetNames(typeof(Resource.CategoriaGramatical));

			foreach (string item in listCategoriaGramatical)
			{
				int index = Array.IndexOf(listCategoriaGramatical, item);
				Console.WriteLine($"  {index + 1} ....... {item}");
			}

			string key = KeyPress().ToString();
			word.CatGrametical = listCategoriaGramatical[int.Parse(key) - 1];

			// set Numero
			Console.WriteLine("\nSeleccione el Numero: ");
			string[] listNumero = Enum.GetNames(typeof(Resource.Numero));

			foreach (var item in listNumero)
			{
				int index = Array.IndexOf(listNumero, item);
				Console.WriteLine($"  {index + 1} ...... {item}");
			}

			key = KeyPress().ToString();
			word.Numero = listNumero[int.Parse(key) - 1];

			// set Genero
			Console.WriteLine("\nSeleccione el Genero: ");
			string[] listaGenero = Enum.GetNames(typeof(Resource.Genero));

			foreach (var item in listaGenero)
			{
				int index = Array.IndexOf(listaGenero, item);
				Console.WriteLine($"   {index + 1} ...... {item}");
			}

			key = KeyPress().ToString();
			word.Genero = listaGenero[int.Parse(key) - 1];

			// set Sinonimos
			Console.Write("\nIngrese Sinonimos (separalos por ',' si quieres agregar mas de uno): ");
			string sinonimos = Console.ReadLine();
			List<string> listSinonimos = sinonimos.Split(',').ToList();
			foreach (var item in listSinonimos)
			{
				word.AddSinonimo(item);
			}

			dictionary.AddWord(word);
		}

		public void BuscarLema()
		{
			Console.Write("Ingrese el lema de la palabra que desea buscar: ");
			var res = dictionary.SearchLema(Console.ReadLine());

			res.ForEach(x => Console.WriteLine(x));
		}

		public void BorrarPalabra()
		{
			Console.Write("Ingrese el lema de la palabra que desea borrar: ");
			var res = dictionary.SearchLema(Console.ReadLine());
			res.ForEach(x => Console.WriteLine(x));

			Console.WriteLine();
/*			dictionary.Words.ForEach(value => Console.WriteLine(value.GetHashCode()));
			Console.WriteLine();*/

			Console.WriteLine($"{"Lema",10} {"Cat Gramatical",15} {"Indice",10}");
			for (int i = 0; i < res.Count; i++) 
			{
				Console.WriteLine($"{res[i].Lema,10} {res[i].CatGrametical,15} {i,10}");
			}
			Console.Write("Ingrese el indice de la palabra que deseas borrar: ");
			int pos = int.Parse(Console.ReadLine());

			if (pos > 0 & pos < res.Count) 
			{ 
				dictionary.RemoveWord(res[pos]);
			}

			dictionary.Words.ForEach(value => Console.WriteLine(value));
			Console.ReadLine();
		}

		public void ModificarPalabra()
		{
			Console.Write("Ingrese el lema de la palabra que desea modificar: ");
			var res = dictionary.SearchLema(Console.ReadLine());
			res.ForEach(x => Console.WriteLine(x));

			Console.WriteLine($"{"Lema",10} {"Cat Gramatical",15} {"Indice",10}");
			for (int i = 0; i < res.Count; i++)
			{
				Console.WriteLine($"{res[i].Lema,10} {res[i].CatGrametical,15} {i,10}");
			}

			Console.Write("Ingrese el indice de la palabra que deseas borrar: ");
			int pos = int.Parse(Console.ReadLine());

			if (pos > 0 & pos < res.Count)
			{
				Word nuevaPalabra = res[pos];

				Console.WriteLine($"{res[pos].Lema}, nuevo Lema: ");
				nuevaPalabra.Lema = Console.ReadLine();
				
				Console.WriteLine($"{res[pos].Significado}, nuevo Significado: ");
				nuevaPalabra.Lema = Console.ReadLine();

				Console.WriteLine($"{res[pos].CatGrametical}, nueva Cat. Gramatical: ");
				nuevaPalabra.CatGrametical = Console.ReadLine();

				if ( nuevaPalabra.CatGrametical == "Sustantivo")
				{
					Console.WriteLine($"{res[pos].Numero}, nuevo Numero: ");
					nuevaPalabra.Numero = Console.ReadLine();

					Console.WriteLine($"´{res[pos].Genero}, nuevo Genero: ");
					nuevaPalabra.Genero = Console.ReadLine();
				}
				else
				{
					nuevaPalabra.Numero = "None";
					nuevaPalabra.Genero= "None";
				}

				dictionary.changeWord(res[pos], nuevaPalabra);
			}

			dictionary.Words.ForEach(value => Console.WriteLine(value));
			Console.ReadLine();
		}

		public static char KeyPress()
		{
			ConsoleKeyInfo key = Console.ReadKey();
			return key.KeyChar;
		}

	}


}
