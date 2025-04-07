using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YoutubeToMSN
{
	public class YouTubeMusicDetector
	{
		public SongInfo GetCurrentSong()
		{
			var chromeProcesses = Process.GetProcessesByName("chrome");
			foreach (var process in chromeProcesses)
			{
				if (process.MainWindowTitle.Contains("YouTube Music"))
				{
					var myprocess = process;

					var match = Regex.Match(process.MainWindowTitle, @"(.*) - (.*) - YouTube Music");
					if (match.Success)
					{
						return new SongInfo
						{
							Title = match.Groups[1].Value.Trim(),
							Artist = match.Groups[2].Value.Trim(),
							Album = "Unknown" // YouTube Music doesn't show album in the title
						};
					}
				}
			}
			return null;
		}
	}
}
