using Music.Models.Artist;
using Music.Models.Song;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Models.Album
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public Artist.Artist Artist { get; set; } = null!;
        public ICollection<Song.Song> Songs { get; set; } = new List<Song.Song>();
    }
}
