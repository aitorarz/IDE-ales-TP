using Music.Models.Album;
using Music.Models.Artist;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Models.Song
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<Artist.Artist> Artist { get; set; } = new List<Artist.Artist>();
        public ICollection<Genre.Genre> Genres { get; set; } = new List<Genre.Genre>();
        public ICollection<Album.Album> Album { get; set; } = new List<Album.Album>();
    }
}
