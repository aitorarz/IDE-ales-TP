using System.ComponentModel.DataAnnotations;

namespace Music.Models.Album.DTO
{
    public class UpdateAlbumDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "El titulo debe tener mínimamente dos caracteres de largo")]
        public string Title { get; set; } = null!;
    }
}
