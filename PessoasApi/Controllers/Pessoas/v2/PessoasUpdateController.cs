using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.v2;
using PessoasApi.Services;

namespace PessoasApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/pessoas")]
    [ApiVersion("2.0")]
    public class PessoasUpdateV2Controller : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasUpdateV2Controller(IPessoaService service)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PessoaUpdateDtoV2 dto)
        {
            if (string.IsNullOrEmpty(dto.Endereco))
                return BadRequest("Endereço é obrigatório na versão 2.");

            var pessoa = await _service.AtualizarV2Async(id, dto);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }
    }
}
