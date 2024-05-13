using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AppDict
{
	public class MyFile
	{
		public object content;
		public string path;
		
		MyFile(object content, string name) 
		{
			this.path = AppDomain.CurrentDomain.BaseDirectory +"/" +name;
			this.content = content;
		}

		public void Read()
		{
			var aux = File.ReadAllText(path);
		}
	}
}
