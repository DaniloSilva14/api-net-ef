using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class EnderecoService : IEnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        const bool SUCCESS = true;
        const bool FAIL = false;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public IEnumerable<Endereco> RecuperarEnderecos()
        {          
            return _context.Enderecos.ToList();
        }

        public ReadEnderecoDto RecuperarEnderecoPorId(int id)
        {
            Endereco? endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                enderecoDto.HoraDaConsulta = DateTime.Now;

                return enderecoDto;
            }

            return null;
        }

        public bool AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco? endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
            {
                return FAIL;
            }

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return SUCCESS;
        }

        public bool DeletarEndereco(int id)
        {
            Endereco? endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
            {
                return FAIL;
            }

            _context.Remove(endereco);
            _context.SaveChanges();

            return SUCCESS;
        }
    }
}
