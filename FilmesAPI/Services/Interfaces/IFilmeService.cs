using FilmesAPI.Data.Dtos.Filme;

namespace FilmesAPI.Services.Interfaces
{
    public interface IFilmeService
    {
        public ReadFilmeDto AdicionarFilme(CreateFilmeDto filmeDto);
        public List<ReadFilmeDto> RecuperarFilmes(int classificacaoEtaria);
        public ReadFilmeDto RecuperarFilmesPorId(int id);
        public bool AtualizarFilme(int id, UpdateFilmeDto filmeDto);
        public bool DeletarFilme(int id);
    }
}
