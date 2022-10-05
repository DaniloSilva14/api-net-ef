using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class SessaoService : ISessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        const bool SUCCESS = true;
        const bool FAIL = false;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<Sessao> RecuperarSessoes()
        {
            return _context.Sessoes.ToList();
        }

        public ReadSessaoDto RecuperarSessaoPorId(int id)
        {
            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                sessaoDto.HoraDaConsulta = DateTime.Now;

                return sessaoDto;
            }

            return null;
        }

        // TODO ATUALIZAR Sessao

        public bool DeletarSessao(int id)
        {
            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return FAIL;
            }

            _context.Remove(sessao);
            _context.SaveChanges();

            return SUCCESS;
        }        
    }
}
