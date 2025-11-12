using AutoMapper;
using Music.Models.Genre;
using Music.Models.Genre.DTO;
using Music.Repositories;
using Music.Utils;
using System.Net;

namespace Music.Services
{
    public class GenreServices
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _repo;
        public GenreServices(IMapper mapper, IGenreRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        async private Task<Genre> GetOneByIdOrException(int id)
        {
            var genre = await _repo.GetOneAsync(g => g.Id == id);
            if (genre == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay género musical con id = {id}");
            }
            return genre;
        }

        async public Task<List<Genre>> GetAll()
        {
            var genres = await _repo.GetAllAsync();
            return genres.ToList();
        }

        async public Task<Genre> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<Genre> CreateOne(CreateOrUpdateGenreDTO createDTO)
        {
            var genre = _mapper.Map<Genre>(createDTO);

            await _repo.CreateOneAsync(genre);

            return genre;
        }

        async public Task<Genre> UpdateOneById(int id, CreateOrUpdateGenreDTO updateDTO)
        {
            var genre = await GetOneByIdOrException(id);

            var genreMapped = _mapper.Map(updateDTO, genre);

            await _repo.UpdateOneAsync(genreMapped);

            return genreMapped;
        }

        async public Task DeleteOneById(int id)
        {
            var genre = await GetOneByIdOrException(id);
            await _repo.DeleteOneAsync(genre);
        }

        async public Task<List<Genre>> GetManyByIds(List<int> Ids)
        {
            if (Ids.Count <= 0 || Ids == null)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista de Ids esta vacia"
                );
            }

            var genres = await _repo.GetAllAsync(x => Ids.Contains(x.Id));

            if (genres.ToList().Count() == 0)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista esta vacia"
                );
            }

            return genres.ToList();
        }
    }
}
