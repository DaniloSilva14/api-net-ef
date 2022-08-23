using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            var result = _enderecoService.AdicionarEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            var result = _enderecoService.RecuperarEnderecos();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            var result = _enderecoService.RecuperarEnderecoPorId(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var result = _enderecoService.AtualizarEndereco(id, enderecoDto);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            var result = _enderecoService.DeletarEndereco(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
