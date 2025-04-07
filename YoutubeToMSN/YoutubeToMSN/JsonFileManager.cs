using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace YoutubeToMSN
{
	public class JsonFileManager
	{
		private readonly string _filePath;

		public JsonFileManager(string filePath)
		{
			_filePath = filePath;
		}

		public void SaveSongInfo(SongInfo songInfo)
		{
			var json = JsonConvert.SerializeObject(songInfo, Formatting.Indented);
			File.WriteAllText(_filePath, json);
		}
	}
}
