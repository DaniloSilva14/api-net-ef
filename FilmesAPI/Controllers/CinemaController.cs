using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema(CreateCinemaDto cinemaDto)
        {
            var result = _cinemaService.AdicionarCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string? nomeDoFilme)
        {
            var result = _cinemaService.RecuperarCinemas(nomeDoFilme);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            var result = _cinemaService.RecuperarCinemaPorId(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var result = _cinemaService.AtualizarCinema(id, cinemaDto);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            var result = _cinemaService.DeletarCinema(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
