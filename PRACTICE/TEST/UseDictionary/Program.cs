using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, dynamic> myDictionary = new Dictionary<string, dynamic>()
            {
                {"color", "rojo"},
                {"puertas", 3},
                {"marca", "chevrolet"},
                {"ruedas", 4 },
                {"tipo", "utilitario"}
            };

            Console.WriteLine("Diccionarios: \n");

            foreach (var item in myDictionary)
            {
                Console.WriteLine($"\'{item.Key}\' : \'{item.Value}\'");
            }

            // int[] list2 = new int[] {4, 5, 6, 7, 8, 9 };

            // List<int> list = new List<int>() { 2, 3, 4, 5};

            List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>{ { "artist", "The Offspring" }, { "album", "Americana" }, { "song", "Americana" } },
                new Dictionary<string, string>{ { "artist", "Green Day"}, { "album", "Dookie" }, { "song", "She" } },
                new Dictionary<string, string>{ { "artist", "Green Day"}, { "album", "Dookie" }, { "song", "Welcome to Paradise"} },
                new Dictionary<string, string>{ { "artist", "Nirvana"}, { "album", "Bleach" }, { "song", "About a Girl"} } 
            };

            Console.WriteLine("\n\nLista de Diccionarios: \n");

            foreach (var keyValue in keyValuePairs)
            {
                foreach (var pair in keyValue)
                {
                    Console.WriteLine($"\"{pair.Key}\" : \"{pair.Value}\"");
                }
                Console.WriteLine("");
            }

        }
    }
}
