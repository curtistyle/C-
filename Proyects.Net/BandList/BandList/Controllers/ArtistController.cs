using BandList.Models;
using BandList.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BandList.Controllers
{
	public class ArtistController : Controller
	{
		// base de datos
		private readonly BandListContext _context;

		public ArtistController(BandListContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Artists.ToListAsync());
		}

		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ArtistViewModel model)
		{
			if (ModelState.IsValid)
			{
				var artist = new Artist()
				{
					Name = model.Name,
					Genre = model.Genre
				};
				_context.Add(artist);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}
	}
}
