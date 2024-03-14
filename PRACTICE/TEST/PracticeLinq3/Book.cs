using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLinq3
{
    public class Book
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        private int year;

        public Book(string title, string genre, string author, int year)
        {
            Title = title;
            Genre = genre;
            Author = author;
            Year = year;
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Year), value, $"{nameof(Year)} must be > 0");
                }

                year = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{nameof(Book)}( {Title}, {Genre}, {Author}, {Year} )";
        }
    }
}
