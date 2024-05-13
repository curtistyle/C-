using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDict
{
	public class Program
	{
		
		static void Main(string[] args)
		{
			/*			Dictionary dict = new Dictionary();

						dict.Words = new List<Word> 
						{	new Word("Car","Carro", "Sustantivo", "Masculino", "Singular", new List<string> {"Vehiculo", "Automovil"}), 
							new Word("Boat", "Barco", "Sustantivo", "Masculino", "Singular", new List<string> {"Bote", "Lancha", "Buque"}),
							new Word("House", "Casa", "Sustantivo", "Femenino", "Singular", new List<string> {"Hogar", "Vivienda", "Domicilio"})
						};

						foreach (var item in dict.Words)
						{
							Console.WriteLine(item.ToString());
						}*/

			Controller controller = new Controller();

			while (true)
			{
				char[] options = { '1', '2', '3', '4' };
				
				MenuPrincipal();
				char key = KeyPress();
				
				if (options.Any(value => value == key))
				{
					if (key == '1')
					{
						Console.Clear();

						controller.AgregarPalabra();

						Console.Beep();
					}
					else if (key == '2')
					{
						Console.Clear();

						controller.BuscarLema();

						Console.Beep();
					}
					else if(key == '3')
					{
						Console.Clear();

						controller.BorrarPalabra();

						Console.Beep();
					}
					else if (key == '4')
					{
						Console.Clear();

						controller.BorrarPalabra();

						Console.Beep();
					}
				}
			}

        }

		static public void MenuPrincipal()
		{
			Console.WriteLine();
			Console.WriteLine("   ^_^         Diccionario Ingles > Español       ^_^    ");
			Console.WriteLine("\n");
			Console.WriteLine("---------------------- Menu Principal -------------------");
			Console.WriteLine("\n");
			Console.WriteLine("■ Agregar una palabra ................................. 1");
			Console.WriteLine("■ Buscar una palabra .................................. 2");
			Console.WriteLine("■ Borra una palabra ................................... 3");
			Console.WriteLine("■ Modificar una palabra ............................... 4");
			Console.WriteLine("\n");
			Console.WriteLine("----------------------------------------------------------");
		}

		public static char KeyPress()
		{
			ConsoleKeyInfo key = Console.ReadKey();
			return key.KeyChar;
		}
	}
}
