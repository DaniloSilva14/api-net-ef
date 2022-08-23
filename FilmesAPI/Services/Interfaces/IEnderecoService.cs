using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Services.Interfaces
{
    public interface IEnderecoService
    {
        public ReadEnderecoDto AdicionarEndereco(CreateEnderecoDto enderecoDto);
        public IEnumerable<Endereco> RecuperarEnderecos();
        public ReadEnderecoDto RecuperarEnderecoPorId(int id);
        public bool AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto);
        public bool DeletarEndereco(int id);
    }
}
