using System.ComponentModel.DataAnnotations;
using Model = FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Model.Cinema Cinema { get; set; }
        public Model.Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
