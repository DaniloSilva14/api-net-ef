using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas()
        {
            return Ok(_context.Cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                cinemaDto.HoraDaConsulta = DateTime.Now;

                return Ok(cinemaDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return NotFound();
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return NotFound();
            }

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
