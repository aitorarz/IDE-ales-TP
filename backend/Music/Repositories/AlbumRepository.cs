using Microsoft.EntityFrameworkCore;
using Music.Config;
using Music.Models.Album;
using Music.Models.Song;
using System.Linq.Expressions;
using System.Linq;

namespace Music.Repositories
{
    public interface IAlbumRepository : IRepository<Album> { }
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _db;
        public AlbumRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        new async public Task<Album> GetOneAsync(Expression<Func<Album, bool>>? filter = null)
        {
            IQueryable<Album> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter).Include(s => s.Songs);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
