using Music.Config;
using Music.Models.Artist;

namespace Music.Repositories
{
    public interface IArtistRepository : IRepository<Artist> { }
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly ApplicationDbContext _db;

        public ArtistRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
