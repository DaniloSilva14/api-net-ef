using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Filme
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O campo Genero não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no min 1 minuto e no max 600")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
