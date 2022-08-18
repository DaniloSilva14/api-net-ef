using System.ComponentModel.DataAnnotations;
using Model = FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        public Model.Endereco Endereco { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
