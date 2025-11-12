using System.ComponentModel.DataAnnotations;

namespace Music.Models.Album.DTO
{
    public class CreateAlbumDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "El titulo debe tener mínimamente dos caracteres de largo")]
        public string Title { get; set; } = null!;
        [Required]
        public int ArtistId { get; set; }
    }
}
