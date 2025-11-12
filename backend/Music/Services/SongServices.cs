using AutoMapper;
using Music.Models.Genre.DTO;
using Music.Models.Genre;
using Music.Repositories;
using Music.Utils;
using System.Net;
using Music.Models.Song;
using Music.Models.Song.DTO;

namespace Music.Services
{
    public class SongServices
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _repo;
        private readonly GenreServices _genreServices;
        private readonly ArtistServices _artistServices;
        private readonly AlbumServices _albumServices;

        public SongServices(
            IMapper mapper,
            ISongRepository repo,
            GenreServices genreServices,
            ArtistServices artistServices,
            AlbumServices albumServices
            )
        {
            _mapper = mapper;
            _repo = repo;
            _genreServices = genreServices;
            _artistServices = artistServices;
            _albumServices = albumServices;
        }

        async private Task<Song> GetOneByIdOrException(int id)
        {
            var song = await _repo.GetOneAsync(s => s.Id == id);
            if (song == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay cancion con id = {id}");
            }
            return song;
        }

        async public Task<List<Song>> GetAll()
        {
            var song = await _repo.GetAllAsync();
            return song.ToList();
        }

        async public Task<Song> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<Song> CreateOne(CreateSongDTO createDTO)
        {
            var song = _mapper.Map<Song>(createDTO);

            var genres = await _genreServices.GetManyByIds(createDTO.GenresIds);
            song.Genres = genres;

            var artists = await _artistServices.GetManyByIds(createDTO.ArtistIds);
            song.Artist = artists;

            if(createDTO.AlbumIds.Count > 0)
            {
                var album = await _albumServices.GetManyByIds(createDTO.AlbumIds);
                song.Album = album;
            }

            await _repo.CreateOneAsync(song);

            return song;
        }

        async public Task<Song> UpdateOneById(int id, UpdateSongDTO updateDTO)
        {
            var song = await GetOneByIdOrException(id);

            var songMapped = _mapper.Map(updateDTO, song);

            await _repo.UpdateOneAsync(songMapped);

            return songMapped;
        }

        async public Task DeleteOneById(int id)
        {
            var song = await GetOneByIdOrException(id);
            await _repo.DeleteOneAsync(song);
        }

        async public Task<List<Song>> GetManyByIds(List<int> Ids)
        {
            if (Ids.Count <= 0 || Ids == null)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista de Ids esta vacia"
                );
            }

            var songs = await _repo.GetAllAsync(x => Ids.Contains(x.Id));

            if (songs.ToList().Count() == 0)
            {
                throw new HttpResponseError(
                    HttpStatusCode.BadRequest,
                    "La lista esta vacia"
                );
            }

            return songs.ToList();
        }
    }
}
