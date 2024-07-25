using System.ComponentModel.DataAnnotations;

namespace BandList.Models.ViewModels
{
	public class SongViewModel
	{
		[Required]
		[Display(Name="Titulo")]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Duracion")]
		public TimeOnly? Duration { get; set; }

		[Required]
		[Display(Name ="Album")]
		public int? AlbumId { get; set; }

		[Required]
		[Display(Name="Artist")]
		public int? ArtistId { get; set; }

		[Required]
		public int SongId { get; set; }
	}
}
