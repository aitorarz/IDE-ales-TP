using Microsoft.AspNetCore.Mvc;
using Music.Models.Artist.DTO;
using Music.Models.Artist;
using Music.Services;
using Music.Utils;
using Music.Models.Album;
using Music.Models.Album.DTO;

namespace Music.Controllers
{
    [Route("api/albumes")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumServices _albumServices;

        public AlbumController(AlbumServices albumServices)
        {
            _albumServices = albumServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Album>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<List<Album>>> GetAll()
        {
            try
            {
                var albums = await _albumServices.GetAll();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Album), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Album>> GetOneById(int id)
        {
            try
            {
                var album = await _albumServices.GetOneById(id);
                return Ok(album);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpPost("crear")]
        [ProducesResponseType(typeof(Album), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Album>> CreateOne([FromBody] CreateAlbumDTO createDTO)
        {
            try
            {
                var album = await _albumServices.CreateOne(createDTO);
                return Created("Album created", album);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult> DeleteOneById(int id)
        {
            try
            {
                await _albumServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Album con ID = {id} eliminado"));
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpPut("actualizar/{id}")]
        [ProducesResponseType(typeof(Album), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Album>> UpdateOneById(int id, [FromBody] UpdateAlbumDTO updateDto)
        {
            try
            {
                var album = await _albumServices.UpdateOneById(id, updateDto);
                return Ok(album);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }
    }
}
