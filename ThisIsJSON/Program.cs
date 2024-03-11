using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.IO;
using System.Text.Json.Serialization.Metadata;

namespace ThisIsJSON
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var listPersons = new[]
            {
                new Person("Curtis", 26, "Concepcion del Uruguay"),
                new Person("Cristina", 27, "Urdinarrain"),
                new Person("Santiago", 26, "Urdinarrain"),
                new Person("Mula", 30, "Urdinarrain"),
                new Person("Tomas", 25, "Concepcion del Urruguay"),
                new Person("Gabriel", 27, "Lucas Gonzales"),
            };



            // # serializacion
            //string miJson = JsonSerializer.Serialize(listPersons);
            //File.WriteAllText("myJSON.json", miJson);

            // de-serializacion 🤔
            string myFILE = File.ReadAllText("myJSON.json");
            
            //var list = JsonSerializer.Deserialize<List<Person>>(myFILE);

            var list = (List<Person>)JsonSerializer.Deserialize(myFILE, typeof(List<Person>));
;

           /* foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }*/
            Console.WriteLine();
            Console.ReadLine();

        }
    }

    public class Person
    {
        public string Name { get; }
        private int age;
        private string country;

        public Person(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Age)} must be >= 0");
                }

                age = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public override string ToString()
        {
            return $"Person ({Name}, {Age}, {Country})";
        }



    }

    static class Extensions
    {
        public static void Display(this Person[] list) 
        { 
            foreach (var person in list)
            {
                Console.WriteLine($"{person.Name}, {person.Country} ");
            }
        }

        public static string Display(this string word)
        {
            Console.WriteLine(word);
            return word;
        }

        public static string UpperFirstWord(this string city)
        {
            // manchester city
            var citySplit = city.Split(' ');
            // [manchester, city]
            foreach (String word in citySplit)
            {
                word[0].ToString().ToUpper();
            }

            return citySplit.ToString();
        }
    }
}
