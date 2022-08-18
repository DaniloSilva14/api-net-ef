using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Gerente
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        //public int EnderecoId { get; set; }
    }
}
