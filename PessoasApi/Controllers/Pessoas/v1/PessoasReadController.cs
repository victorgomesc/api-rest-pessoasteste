using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.v1;
using PessoasApi.Services;

namespace PessoasApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/pessoas")]
    [ApiVersion("1.0")]
    public class PessoasReadV1Controller(IPessoaService service) : ControllerBase
    {
        private readonly IPessoaService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaResponseDtoV1>>> ObterTodos()
        {
            var pessoas = await _service.ObterTodosV1Async();
            return Ok(pessoas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaResponseDtoV1>> ObterPorId(int id)
        {
            var pessoa = await _service.ObterPorIdV1Async(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpGet("nome")]
        public async Task<ActionResult<IEnumerable<PessoaResponseDtoV1>>> ObterPorNome([FromQuery] string nome)
        {
            var pessoas = await _service.ObterPorNomeV1Async(nome);
            return Ok(pessoas);
        }

        [HttpGet("cpf")]
        public async Task<ActionResult<PessoaResponseDtoV1>> ObterPorCpf([FromQuery] string cpf)
        {
            var pessoa = await _service.ObterPorCpfV1Async(cpf);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }
    }
}
