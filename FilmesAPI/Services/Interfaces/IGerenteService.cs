using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Services.Interfaces
{
    public interface IGerenteService
    {
        public ReadGerenteDto AdicionarGerente(CreateGerenteDto gerenteDto);
        public List<Gerente> RecuperarGerentes();
        public ReadGerenteDto RecuperarGerentePorId(int id);
        //public bool AtualizarGerente(int id, UpdateGerenteDto gerenteDto);
        public bool DeletarGerente(int id);
    }
}
