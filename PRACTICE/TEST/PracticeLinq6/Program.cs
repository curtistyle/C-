using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLinq6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Person> list = new List<Person>()
			{
				new Person("Curtis", 12),
				new Person("Pablo", 22),
				new Person("Juan", 33)
			};

			string conc = "[" + list
				.Select(x => x.Name)
				.Aggregate((anterior, actual) => anterior + ", " + actual)
				+ "]";

			Console.WriteLine(conc);


		}
	}

	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
			Age = age;
        }

		public override string ToString()
		{
			return $"Person({Name},{Age})";
		}
    }
}
