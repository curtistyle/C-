using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisIsJSON
{
    internal class Program
    {

        static void Main(string[] args)
        {

/*            var listPersons = new[]
            {
                new Person("Curtis", 10),
                new Person("Cristina", 12),
                new Person("Santiago", 13),
                new Person("Mula", 22)
            };


            listPersons.Display();
        */
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
                value
            }
        }



    }

    static class Extensions
    {
        public static void Display(this Person[] list) 
        { 
            foreach (var person in list)
            {
                Console.WriteLine($"{person.Name}, {person.Id} ");
            }
        }
        private static string UpperFirst(this string city)
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
