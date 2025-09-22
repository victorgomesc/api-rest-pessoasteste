using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.v2;
using PessoasApi.Services;

namespace PessoasApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/pessoas")]
    [ApiVersion("2.0")]
    public class PessoasCreateV2Controller(IPessoaService service) : ControllerBase
    {
        private readonly IPessoaService _service = service;

        [HttpPost]
        public async Task<IActionResult> Criar(PessoaCreateDtoV2 dto)
        {
            if (string.IsNullOrEmpty(dto.Endereco))
                return BadRequest("Endereço é obrigatório na versão 2.");

            var pessoa = await _service.CriarV2Async(dto);
            return CreatedAtAction(nameof(Criar), new { id = pessoa.Id }, pessoa);
        }
    }
}
