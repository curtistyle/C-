using System.ComponentModel.DataAnnotations;

namespace BandList.Models.ViewModels
{
	public class ArtistViewModel
	{
		[Required]
		[Display(Name="Artist")]
		public string? Name { get; set; }

		[Required]
		[Display(Name="Genero")]
		public string? Genre { get; set; }
	}
}
