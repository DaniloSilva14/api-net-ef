using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private IGerenteService _gerenteService;

        public GerenteController(IGerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(CreateGerenteDto gerenteDto)
        {
            var result = _gerenteService.AdicionarGerente(gerenteDto);

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            var result = _gerenteService.RecuperarGerentes();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            var result = _gerenteService.RecuperarGerentePorId(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        //[HttpPut("{id}")]
        //public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        //{
        //    Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

        //    if (gerente == null)
        //    {
        //        return NotFound();
        //    }

        //    _mapper.Map(gerenteDto, gerente);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            var result = _gerenteService.DeletarGerente(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
