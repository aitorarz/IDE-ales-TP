using System.ComponentModel.DataAnnotations;

namespace Music.Models.Genre.DTO
{
    public class CreateOrUpdateGenreDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "El nombre no puede ser menor a un caracter")]
        public string Name { get; set; } = null!;
    }
}
