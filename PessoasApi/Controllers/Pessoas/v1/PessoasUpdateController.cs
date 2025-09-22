using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.v1;
using PessoasApi.Services;

namespace PessoasApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/pessoas")]
    [ApiVersion("1.0")]
    public class PessoasUpdateV1Controller(IPessoaService service) : ControllerBase
    {
        private readonly IPessoaService _service = service;

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PessoaUpdateDtoV1 dto)
        {
            var pessoa = await _service.AtualizarV1Async(id, dto);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }
    }
}
