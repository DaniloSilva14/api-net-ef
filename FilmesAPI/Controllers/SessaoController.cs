using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            return Ok(_context.Sessoes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                sessaoDto.HoraDaConsulta = DateTime.Now;

                return Ok(sessaoDto);
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
            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return NotFound();
            }

            _context.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
