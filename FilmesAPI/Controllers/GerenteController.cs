using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            return Ok(_context.Gerentes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                gerenteDto.HoraDaConsulta = DateTime.Now;

                return Ok(gerenteDto);
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
            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
            {
                return NotFound();
            }

            _context.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
