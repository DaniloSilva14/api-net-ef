using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Filme;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        const bool SUCCESS = true;
        const bool FAIL = false;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionarFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperarFilmes(int classificacaoEtaria)
        {
            List<Filme> filmes = _context
                .Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
                .ToList();

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
            }

            return null;
        }

        public ReadFilmeDto RecuperarFilmesPorId(int id)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now;

                return filmeDto;
            }

            return null;
        }

        public bool AtualizarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return FAIL;
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return SUCCESS;
        }

        public bool DeletarFilme(int id)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return FAIL;
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return SUCCESS;
        }
    }
}
