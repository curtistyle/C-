using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeToMSN
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("YoutubeMusicToMSN started. Press Ctrl+C to exit.");

			var detector = new YouTubeMusicDetector();
			var fileManager = new JsonFileManager("current_song.json");

			while (true)
			{
				var songInfo = detector.GetCurrentSong();
				if (songInfo != null)
				{
					fileManager.SaveSongInfo(songInfo);
					Console.WriteLine($"Updated: {songInfo.Title} - {songInfo.Artist}");
				}
				Thread.Sleep(5000); // Check every 5 seconds
			}
		}
	}
}
