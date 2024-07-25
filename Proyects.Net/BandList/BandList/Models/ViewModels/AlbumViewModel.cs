using System.ComponentModel.DataAnnotations;

namespace BandList.Models.ViewModels
{
    // clase para formulario (viewmodel)
    public class AlbumViewModel
    {
        [Required]
        [Display(Name= "Title")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateOnly? ReleaseDate { get; set; }
    }
}
