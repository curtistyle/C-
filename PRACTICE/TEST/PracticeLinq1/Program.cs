using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PracticeLinq1
{


    public class Program
    {
        private const double V = 0.5;

        static void Main(string[] args)
        {
            var listOfPerson2 = new List<Person>
            {
                new Person("Curtis", "Concepcion del Uruguay", 23, 1000),
                new Person("Marcos", "Urdinarrain", 23, 1000),
                new Person("Agustin", "Gualeguay", 30, 1000),
                new Person("Nicolas", "Urdinarrain", 22, 1000),
                new Person("Tomas", "Concepcion del Uruguay", 24, 1000),
                new Person("Gabriel", "Lucas Gonzales", 23, 1000)
            };

            var listOfPerson = new[] { 
                new Person("Curtis", "Concepcion del Uruguay", 23, 1000),
                new Person("Marcos", "Urdinarrain", 23, 1000),
                new Person("Agustin", "Gualeguay", 18, 1000),
                new Person("Nicolas", "Urdinarrain", 17, 1000),
                new Person("Tomas", "Concepcion del Uruguay", 24, 1000),
                new Person("Gabriel", "Lucas Gonzales", 23, 1000),
                new Person("Martin", "Urdinarrain", 17, 1000),
                new Person("Brian", "Gualeguay", 23, 1000),
                new Person("John", "Concepcion del Uruguay", 23, 1000)
            };


            
                
                

            

/*            listOfPerson2.Where(value => value.Country == "Concepcion del Uruguay")
                .Display();

            Console.WriteLine();

            var ll =
            listOfPerson.Where(value => value.Age > 19)
                .Select(value => value)
                .Aumento("Salary", 0.5F);
                
            ll.Display();

            Console.WriteLine();*/

            

            //Extension.Display<Person>();
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
        public double Salary { get; set; }

        public Person(string fullName, string country, int age, double salary)
        {
            FullName = fullName ?? string.Empty;
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Salary = salary;
            Age = age;
        }

        public Person IncreseSalary(float porcent)
        {
            Salary *= porcent;
            return this;
        }

        public Person GetPerson()
        {
            return this;
        }

        public override string ToString() =>
            $"{"GetType().Name"}( {FullName}, {Country}, {Age}, {Salary} )";

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


        public static IEnumerable<T> Aumento<T>(this IEnumerable<T> list, string propertyName, float value)
        {
            foreach (var item in list)
            {
                var prop = item.GetType().GetProperty(propertyName);
                prop.SetValue(item, value);
            }

            return list;
        }
/*
        /// <summary>
        /// asdasda 
        /// 
        /// </summary>
        /// <typeparam name="T"> Person </typeparam>
        public static void Display<T>()
        {
            Console.WriteLine(typeof(T).FullName);
        }
*/
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
