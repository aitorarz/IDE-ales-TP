using Microsoft.EntityFrameworkCore;
using Music.Models.Album;
using Music.Models.Artist;
using Music.Models.Genre;
using Music.Models.Song;
using System.Data;

namespace Music.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Song>()
                .HasMany(s => s.Genres)
                .WithMany()
                .UsingEntity(j => j.ToTable("SongGenres"));

            modelBuilder.Entity<Song>()
                .HasMany(s => s.Artist)
                .WithMany()
                .UsingEntity(j => j.ToTable("SongArtists"));

            modelBuilder.Entity<Song>()
                .HasMany(s => s.Album)
                .WithMany(a => a.Songs)
                .UsingEntity(j => j.ToTable("SongAlbums"));



            //modelBuilder.Entity<Song>()
            //    .HasMany(s => s.Genres)
            //    .WithMany()
            //    .UsingEntity<SongGenres>(
            //        l => l.HasOne<Genre>().WithMany().HasForeignKey(x => x.GenreId),
            //        r => r.HasOne<Song>().WithMany().HasForeignKey(x => x.SongId)
            //    );

            //modelBuilder.Entity<Song>()
            //    .HasMany(x => x.Artist)
            //    .WithMany()
            //    .UsingEntity<SongArtists>(
            //        l => l.HasOne<Artist>().WithMany().HasForeignKey(x => x.ArtistId),
            //        r => r.HasOne<Song>().WithMany().HasForeignKey(x => x.SongId)
            //    );
        }
    }
}
