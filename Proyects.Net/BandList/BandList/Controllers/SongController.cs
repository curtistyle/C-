using BandList.Models;
using BandList.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BandList.Controllers
{
	public class SongController : Controller
	{
		// db context
		private readonly BandListContext _context;

		public SongController(BandListContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var song = _context
				.Songs
				.Include(item => item.Album)
				.ThenInclude(item => item.Artist);

			return View(await song.ToListAsync());
		}

		[Route("/Update/{id:int}")]
		public async Task<IActionResult> Update(int id, Song song)
		{
			/*			var song = new Song()
						{
							SongId = id,
							AlbumId = songView.AlbumId,
							Duration = songView.Duration,
							Title = songView.Title,
						};*/

			song.SongId = id;
			song.Display("TASK UPDATE");

/*			_context.Songs.Update(new Song()
			{
				Title = song.Title,
				AlbumId = song.AlbumId,
				SongId = song.SongId,
				Duration = song.Durations
			});*/

			_context.Songs.Update( song );

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		
		[Route("/Edit/{id:int}")]
		public async Task<IActionResult> Edit(int id)
		{
			Song song = await _context.Songs
				.Where(value => value.SongId == id)
				.Include(value => value.Album)
				//.ThenInclude(value => value.Artist)
				.SingleAsync();

/*			var songView = new SongViewModel()
			{
				Title = song.Title,
				Duration = song.Duration,
				SongId = song.SongId,
				AlbumId = song.AlbumId,
				ArtistId = song.Album.ArtistId
			};*/
			
			song.Display("TASK EDIT");

			ViewData["Artist"] = new SelectList(_context.Artists, "ArtistId", "Name");
			ViewData["Album"] = new SelectList(_context.Albums, "AlbumId", "Title");

			return View(song);
		}

		public async Task<JsonResult> OnGetAlbumModel(int artistId)
		{
			var albums = await _context.Albums
				.Where(value => value.ArtistId == artistId)
				.ToListAsync();

			return new JsonResult(albums);
		}

		[Route("/Remove/{id:int}")]
		public async Task<IActionResult> Remove(int id) 
		{
			var song = await _context.Songs
				.Where(value => value.SongId == id)
				.Include(value => value.Album)
				.FirstAsync();

			if (song == null)
			{
				TempData["AlertMessage"] = $"Song with ID '{id}' not found in database";
			}
			else
			{
				_context.Songs.Remove(song);
				TempData["AlertMessage"] = $"Song '{song.Title}' by '{song.Album.Title}' has been removed from the database";
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Create()
		{
			ViewData["Artist"] = new SelectList(_context.Artists, "ArtistId", "Name");
			ViewData["Album"] = new SelectList(_context.Albums, "AlbumId", "Title");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SongViewModel model)
		{
			Console.WriteLine($"Model State: {ModelState.IsValid}");
			Console.WriteLine($"Title: {model.Title}");
			Console.WriteLine($"Duration: {model.Duration}");
			Console.WriteLine($"AlbumId: {model.AlbumId}");
			Console.WriteLine($"ArtistId: {model.ArtistId}");

			if (ModelState.IsValid)
			{
				var song = new Song()
				{
					Title = model.Title,
					Duration = model.Duration,
					AlbumId = model.AlbumId,
				};
				_context.Songs.Add(song);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View();
		}
	}

	static class Expressions
	{
		public static void Display(this Song song, string message)
		{
			Console.WriteLine(
				$">>> {message} <<<<" +
				$"\n{nameof(song.SongId)}={song.SongId}" +
				$"\n{nameof(song.Title)}={song.Title}" +
				$"\n{nameof(song.Duration)}={song.Duration}" +
				$"\n{nameof(song.AlbumId)}={song.AlbumId}" +
				$"\n{nameof(song.Album)}={song.AlbumId}");
		}
	}
}
