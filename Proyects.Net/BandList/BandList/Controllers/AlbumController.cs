using BandList.Models;
using BandList.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace BandList.Controllers
{
    public class AlbumController : Controller
    {
        private readonly BandListContext _context;

        public AlbumController(BandListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var albums = _context.Albums.Include(item => item.Artist);

            return View(await albums.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Artist"] = new SelectList(_context.Artists, "ArtistId", "Name");
            
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumViewModel model)
        {

            
            if (ModelState.IsValid)
            {
                var album = new Album()
                {
                    Title = model.Title,
                    ArtistId = model.ArtistId,
                    ReleaseDate = model.ReleaseDate,
                };

                _context.Albums.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Albums"] = new SelectList(_context.Artists, "ArtistId", "Name", model.ArtistId);
            return View(model);
        }
    }
}
