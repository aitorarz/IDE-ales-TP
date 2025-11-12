using Music.Config;
using Music.Models.Genre;
using System.Data;
using Music.Repositories;

namespace Music.Repositories
{
    public interface IGenreRepository : IRepository<Genre> { }
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _db;

        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
