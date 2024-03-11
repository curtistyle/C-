using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PracticeLinq1
{


    public class Program
    {
        static void Main(string[] args)
        {
            var listOfPerson2 = new List<Person>
            {
                new Person("Curtis", "Concepcion del Uruguay", 23),
                new Person("Marcos", "Urdinarrain", 23),
                new Person("Agustin", "Gualeguay", 30),
                new Person("Nicolas", "Urdinarrain", 22),
                new Person("Tomas", "Concepcion del Uruguay", 24),
                new Person("Gabriel", "Lucas Gonzales", 23)
            };

            var listOfPerson = new[] { 
                new Person(null, "Concepcion del Uruguay", 23),
                new Person("Marcos", "Urdinarrain", 23),
                new Person("Agustin", "Gualeguay", 30),
                new Person("Nicolas", "Urdinarrain", 22),
                new Person("Tomas", "Concepcion del Uruguay", 24),
                new Person("Gabriel", "Lucas Gonzales", 23)
            };



            listOfPerson2.Where(value => value.Country == "Concepcion del Uruguay")
            .Display();

            Extension.Display<Person>();
/*
            IEnumerable<Person> filterCity =
            listOfPerson2.Where(value => value.Country == "Concepcion del Uruguay")
            .Display();
*/



            //filterCity.Display();




        }
        
    }

    public class Person
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public Person(string fullName, string country, int age)
        {
            FullName = fullName ?? string.Empty;
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Age = age;
        } 

        public override string ToString() =>
            $"{"GetType().Name"}( {FullName}, {Country}, {Age} )";

    }

    static class Extension
    {
        public static void Display<T>(this IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }

        }

        /// <summary>
        /// asdasda 
        /// 
        /// </summary>
        /// <typeparam name="T"> Person </typeparam>
        public static void Display<T>()
        {
            Console.WriteLine(typeof(T).FullName);
        }

        /*
                public static IEnumerable<T> Display<T>(this IEnumerable<T> lyst)
                {
                    foreach (T item in lyst)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    return lyst;
                }*/

        /* public static void Display(this Person p)
         {
             Console.WriteLine(p.ToString());

         }*/


    }
}
