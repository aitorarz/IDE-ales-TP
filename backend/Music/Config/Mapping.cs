using AutoMapper;
using Music.Models.Album.DTO;
using Music.Models.Artist;
using Music.Models.Artist.DTO;
using Music.Models.Genre;
using Music.Models.Genre.DTO;
using Music.Models.Song;
using Music.Models.Song.DTO;

namespace Music.Config
{
    public class Mapping : Profile
    {
        public Mapping() {
            // Defaults
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);

            //Entities
            CreateMap<CreateOrUpdateGenreDTO, Genre>();

            CreateMap<CreateOrUpdateArtistDTO, Artist>();

            CreateMap<CreateSongDTO, Song>();
            CreateMap<UpdateSongDTO, Song>();

            CreateMap<CreateAlbumDTO, Song>();
            CreateMap<UpdateAlbumDTO, Song>();
        }
    }
}
