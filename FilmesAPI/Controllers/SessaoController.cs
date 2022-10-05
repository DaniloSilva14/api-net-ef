using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private ISessaoService _sessaoService;

        public SessaoController(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            var result = _sessaoService.AdicionarSessao(sessaoDto);

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult AdicionarSessao()
        {
            var result = _sessaoService.RecuperarSessoes();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            var result = _sessaoService.RecuperarSessaoPorId(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        //[HttpPut("{id}")]
        //public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        //{
        //    Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

        //    if (sessao == null)
        //    {
        //        return NotFound();
        //    }

        //    _mapper.Map(sessaoDto, sessao);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            var result = _sessaoService.DeletarSessao(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
