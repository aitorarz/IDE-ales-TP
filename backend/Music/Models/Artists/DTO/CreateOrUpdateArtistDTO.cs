using System.ComponentModel.DataAnnotations;

namespace Music.Models.Artist.DTO
{
    public class CreateOrUpdateArtistDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "El nombre no puede ser menor a un caracter")]
        public string Name { get; set; } = null!;
    }
}
