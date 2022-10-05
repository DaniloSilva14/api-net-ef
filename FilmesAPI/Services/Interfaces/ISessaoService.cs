using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Services.Interfaces
{
    public interface ISessaoService
    {
        public ReadSessaoDto AdicionarSessao(CreateSessaoDto sessaoDto);
        public List<Sessao> RecuperarSessoes();
        public ReadSessaoDto RecuperarSessaoPorId(int id);
        //public bool AtualizarSessao(int id, UpdateSessaoDto sessaoDto);
        public bool DeletarSessao(int id);
    }
}
