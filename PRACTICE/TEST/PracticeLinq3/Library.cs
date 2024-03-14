using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLinq3
{
    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }

        public override string ToString() =>
            $"{nameof(Library)}( {Name} , { Books })";
    }
}
