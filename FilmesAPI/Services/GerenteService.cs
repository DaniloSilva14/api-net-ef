using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class GerenteService : IGerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        const bool SUCCESS = true;
        const bool FAIL = false;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<Gerente> RecuperarGerentes()
        {
            return _context.Gerentes.ToList();
        }

        public ReadGerenteDto RecuperarGerentePorId(int id)
        {
            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                gerenteDto.HoraDaConsulta = DateTime.Now;

                return gerenteDto;
            }

            return null;
        }

        // TODO ATUALIZAR GERENTE

        public bool DeletarGerente(int id)
        {
            Gerente? gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
            {
                return FAIL;
            }

            _context.Remove(gerente);
            _context.SaveChanges();

            return SUCCESS;
        }        
    }
}
