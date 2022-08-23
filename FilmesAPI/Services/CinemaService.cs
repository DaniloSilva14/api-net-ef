using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class CinemaService : ICinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        const bool SUCCESS = true;
        const bool FAIL = false;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionarCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperarCinemas(string? nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);

            if (readDto == null || readDto.Count == 0)
            {
                return null;
            }

            return readDto.ToList();
        }

        public ReadCinemaDto RecuperarCinemaPorId(int id)
        {
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                cinemaDto.HoraDaConsulta = DateTime.Now;

                return cinemaDto;
            }

            return null;
        }

        public bool AtualizarCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return FAIL;
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return SUCCESS;
        }

        public bool DeletarCinema(int id)
        {
            Cinema? cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return FAIL;
            }

            _context.Remove(cinema);
            _context.SaveChanges();

            return SUCCESS;
        }
    }
}
