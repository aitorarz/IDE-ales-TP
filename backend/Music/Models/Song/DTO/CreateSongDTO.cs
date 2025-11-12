using System.ComponentModel.DataAnnotations;

namespace Music.Models.Song.DTO
{
    public class CreateSongDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "El titulo debe tener mínimamente dos caracteres de largo")]
        public string Title { get; set; } = null!;
        public List<int>? AlbumIds { get; set; } = null!;
        [Required]
        public List<int> ArtistIds { get; set; } = new List<int>();
        [Required]
        public List<int> GenresIds { get; set; } = new List<int>();
    }
}
