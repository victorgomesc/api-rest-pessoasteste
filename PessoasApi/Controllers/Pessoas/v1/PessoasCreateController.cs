using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.v1;
using PessoasApi.Services;

namespace PessoasApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/pessoas")]
    [ApiVersion("1.0")]
    public class PessoasCreateV1Controller : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasCreateV1Controller(IPessoaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PessoaCreateDtoV1 dto)
        {
            var pessoa = await _service.CriarV1Async(dto);
            return CreatedAtAction(nameof(Criar), new { id = pessoa.Id }, pessoa);
        }
    }
}
