using FilmesAPI.Data.Dtos.Cinema;

namespace FilmesAPI.Services.Interfaces
{
    public interface ICinemaService
    {
        public ReadCinemaDto AdicionarCinema(CreateCinemaDto cinemaDto);
        public List<ReadCinemaDto> RecuperarCinemas(string? nomeDoFilme);
        public ReadCinemaDto RecuperarCinemaPorId(int id);
        public bool AtualizarCinema(int id, UpdateCinemaDto cinemaDto);
        public bool DeletarCinema(int id);
    }
}
