using System.ComponentModel.DataAnnotations;

namespace Music.Models.Song.DTO
{
    public class UpdateSongDTO
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; } = null!;

    }
}
