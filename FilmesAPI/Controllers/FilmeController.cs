using FilmesAPI.Data.Dtos.Filme;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionarFilme(CreateFilmeDto filmeDto)
        {
            var result = _filmeService.AdicionarFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int classificacaoEtaria = 18)
        {
            var result = _filmeService.RecuperarFilmes(classificacaoEtaria);

            if(result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            var result = _filmeService.RecuperarFilmesPorId(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var result = _filmeService.AtualizarFilme(id, filmeDto);

            if(result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            var result = _filmeService.DeletarFilme(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
