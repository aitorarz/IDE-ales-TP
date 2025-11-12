using Microsoft.AspNetCore.Mvc;
using Music.Models.Genre;
using Music.Models.Genre.DTO;
using Music.Services;
using Music.Utils;

namespace Music.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreServices _genreServices;

        public GenreController(GenreServices genreServices)
        {
            _genreServices = genreServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<List<Genre>>> GetAll()
        {
            try
            {
                var genres = await _genreServices.GetAll();
                return Ok(genres);
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
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Genre>> GetOneById(int id)
        {
            try
            {
                var genre = await _genreServices.GetOneById(id);
                return Ok(genre);
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
        [ProducesResponseType(typeof(Genre), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Genre>> CreateOne([FromBody] CreateOrUpdateGenreDTO createDTO)
        {
            try
            {
                var genre = await _genreServices.CreateOne(createDTO);
                return Created("Genre created", genre);
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
                await _genreServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Genero con ID = {id} eliminado"));
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
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Genre>> UpdateOneById(int id, [FromBody] CreateOrUpdateGenreDTO updateDto)
        {
            try
            {
                var genre = await _genreServices.UpdateOneById(id, updateDto);
                return Ok(genre);
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
