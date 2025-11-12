using Microsoft.AspNetCore.Mvc;
using Music.Services;
using Music.Utils;
using Music.Models.Artist;
using Music.Models.Artist.DTO;

namespace Music.Controllers
{
    [Route("api/artistas")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistServices _artistServices;

        public ArtistController(ArtistServices artistServices)
        {
            _artistServices = artistServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Artist>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<List<Artist>>> GetAll()
        {
            try
            {
                var artists = await _artistServices.GetAll();
                return Ok(artists);
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
        [ProducesResponseType(typeof(Artist), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Artist>> GetOneById(int id)
        {
            try
            {
                var artist = await _artistServices.GetOneById(id);
                return Ok(artist);
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
        [ProducesResponseType(typeof(Artist), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Artist>> CreateOne([FromBody] CreateOrUpdateArtistDTO createDTO)
        {
            try
            {
                var artist = await _artistServices.CreateOne(createDTO);
                return Created("Genre created", artist);
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
                await _artistServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Artista con ID = {id} eliminado"));
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
        [ProducesResponseType(typeof(Artist), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Artist>> UpdateOneById(int id, [FromBody] CreateOrUpdateArtistDTO updateDto)
        {
            try
            {
                var artist = await _artistServices.UpdateOneById(id, updateDto);
                return Ok(artist);
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
