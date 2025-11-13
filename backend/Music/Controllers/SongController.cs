using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.Enums;
using Music.Models.Genre;
using Music.Models.Genre.DTO;
using Music.Models.Song;
using Music.Models.Song.DTO;
using Music.Services;
using Music.Utils;

namespace Music.Controllers
{
        [Route("api/canciones")]
        [ApiController]
        public class SongController : ControllerBase
        {
            private readonly SongServices _songServices;

            public SongController(SongServices songServices)
            {
                _songServices = songServices;
            }

            [HttpGet]
            [ProducesResponseType(typeof(List<Song>), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
            async public Task<ActionResult<List<Song>>> GetAll()
            {
                try
                {
                    var songs = await _songServices.GetAll();
                    return Ok(songs);
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
            [ProducesResponseType(typeof(Song), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
            async public Task<ActionResult<Song>> GetOneById(int id)
            {
                try
                {
                    var song = await _songServices.GetOneById(id);
                    return Ok(song);
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
            [Authorize(Roles = $"{ROLE.MOD}, {ROLE.ADMIN}")]
            [ProducesResponseType(typeof(Song), StatusCodes.Status201Created)]
            [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
            async public Task<ActionResult<Song>> CreateOne([FromBody] CreateSongDTO createDTO)
            {
                try
                {
                    var song = await _songServices.CreateOne(createDTO);
                    return Created("Genre created", song);
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
            [Authorize(Roles = $"{ROLE.MOD}, {ROLE.ADMIN}")]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
            async public Task<ActionResult> DeleteOneById(int id)
            {
                try
                {
                    await _songServices.DeleteOneById(id);
                    return Ok(new HttpMessage($"Cancion con ID = {id} eliminado"));
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
            [Authorize(Roles = $"{ROLE.MOD}, {ROLE.ADMIN}")]
            [ProducesResponseType(typeof(Song), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
            async public Task<ActionResult<Song>> UpdateOneById(int id, [FromBody] UpdateSongDTO updateDto)
            {
                try
                {
                    var song = await _songServices.UpdateOneById(id, updateDto);
                    return Ok(song);
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
