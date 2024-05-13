using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDict
{
	public class Dictionary
	{
		private List<Word> words;


		public Dictionary() 
		{ 
			
		}

		public Dictionary(List<Word> words)
		{
			Words = words;
		}

		public List<Word> Words
		{
			get
			{
				return words;
			}
			set
			{
				if (value.GetType() == typeof(List<Word>)) 
				{
					words = value;

				}
				else
				{
					throw new ArgumentException($"The value you set must be of the {typeof(List<Word>)} type.");
				}
			}
		}

		public void AddWord(Word word)
		{
			words?.Add(word);
		}

		public void RemoveWord(Word obj) 
		{ 
			words.Remove(obj);
		}

		public void changeWord(Word oldWord,Word newValue) 
		{ 
			int pos = words.FindIndex(value => value.Equals(oldWord));
			words[pos] = newValue;
		}

		public List<Word> SearchLema(string lema)
		{
			return words.Where(value => value.Lema == lema)
				.Select(value => value).ToList();
		}


	}
}
