using AutoMapper;
using Music.Models.Genre.DTO;
using Music.Models.Genre;
using Music.Repositories;
using Music.Utils;
using System.Net;
using Music.Models.Album;
using Music.Models.Album.DTO;

namespace Music.Services
{
    public class AlbumServices
    {
        private readonly IMapper _mapper;
        private readonly IAlbumRepository _repo;
        private readonly ArtistServices _artistServices;
        public AlbumServices(IMapper mapper, IAlbumRepository repo, ArtistServices artistServices)
        {
            _mapper = mapper;
            _repo = repo;
            _artistServices = artistServices;
        }

        async private Task<Album> GetOneByIdOrException(int id)
        {
            var album = await _repo.GetOneAsync(a => a.Id == id);
            if (album == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay album con id = {id}");
            }
            return album;
        }

        async public Task<List<Album>> GetAll()
        {
            var albums = await _repo.GetAllAsync();
            return albums.ToList();
        }

        async public Task<Album> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<Album> CreateOne(CreateAlbumDTO createDTO)
        {
            var artist = await _artistServices.GetOneById(createDTO.ArtistId);

            var album = _mapper.Map<Album>(createDTO);

            album.Artist = artist;

            await _repo.CreateOneAsync(album);

            return album;
        }

        async public Task<Album> UpdateOneById(int id, UpdateAlbumDTO updateDTO)
        {
            var album = await GetOneByIdOrException(id);

            var albumMapped = _mapper.Map(updateDTO, album);

            await _repo.UpdateOneAsync(albumMapped);

            return albumMapped;
        }

        async public Task DeleteOneById(int id)
        {
            var album = await GetOneByIdOrException(id);
            await _repo.DeleteOneAsync(album);
        }

        async public Task<List<Album>> GetManyByIds(List<int> Ids)
        {
            if (Ids.Count <= 0 || Ids == null)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista de Ids esta vacia"
                );
            }

            var albums = await _repo.GetAllAsync(x => Ids.Contains(x.Id));

            if (albums.ToList().Count() == 0)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista esta vacia"
                );
            }

            return albums.ToList();
        }
    }

}
