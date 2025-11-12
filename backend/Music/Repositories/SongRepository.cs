using Music.Config;
using Music.Models.Genre;
using Music.Models.Song;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Music.Repositories
{
    public interface ISongRepository : IRepository<Song> { }
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private readonly ApplicationDbContext _db;

        public SongRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        new async public Task<Song> GetOneAsync(Expression<Func<Song, bool>>? filter = null)
        {
            IQueryable<Song> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter).Include(s => s.Genres).Include(s => s.Artist);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
