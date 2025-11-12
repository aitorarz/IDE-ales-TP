using AutoMapper;
using Music.Repositories;
using Music.Utils;
using System.Net;
using Music.Models.Artist;
using Music.Models.Artist.DTO;
using Music.Models.Genre;

namespace Music.Services
{
    public class ArtistServices
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _repo;

        public ArtistServices(IMapper mapper, IArtistRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        async private Task<Artist> GetOneByIdOrException(int id)
        {
            var artist = await _repo.GetOneAsync(a => a.Id == id);
            if (artist == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay artista con id = {id}");
            }
            return artist;
        }

        async public Task<List<Artist>> GetAll()
        {
            var artists = await _repo.GetAllAsync();
            return artists.ToList();
        }

        async public Task<Artist> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<Artist> CreateOne(CreateOrUpdateArtistDTO createDTO)
        {
            var artist = _mapper.Map<Artist>(createDTO);

            await _repo.CreateOneAsync(artist);

            return artist;
        }

        async public Task<Artist> UpdateOneById(int id, CreateOrUpdateArtistDTO updateDTO)
        {
            var artist = await GetOneByIdOrException(id);

            var artistMapped = _mapper.Map(updateDTO, artist);

            await _repo.UpdateOneAsync(artistMapped);

            return artistMapped;
        }

        async public Task DeleteOneById(int id)
        {
            var artist = await GetOneByIdOrException(id);
            await _repo.DeleteOneAsync(artist);
        }

        async public Task<List<Artist>> GetManyByIds(List<int> Ids)
        {
            if (Ids.Count <= 0 || Ids == null)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista de Ids esta vacia"
                );
            }

            var artists = await _repo.GetAllAsync(x => Ids.Contains(x.Id));

            if (artists.ToList().Count() == 0)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista esta vacia"
                );
            }

            return artists.ToList();
        }
    }
}
