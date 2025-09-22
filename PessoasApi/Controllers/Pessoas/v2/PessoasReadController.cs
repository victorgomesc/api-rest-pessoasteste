using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.v2;
using PessoasApi.Services;

namespace PessoasApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/pessoas")]
    [ApiVersion("2.0")]
    public class PessoasReadV2Controller(IPessoaService service) : ControllerBase
    {
        private readonly IPessoaService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaResponseDtoV2>>> ObterTodos()
        {
            var pessoas = await _service.ObterTodosV2Async();
            return Ok(pessoas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaResponseDtoV2>> ObterPorId(int id)
        {
            var pessoa = await _service.ObterPorIdV2Async(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpGet("nome")]
        public async Task<ActionResult<IEnumerable<PessoaResponseDtoV2>>> ObterPorNome([FromQuery] string nome)
        {
            var pessoas = await _service.ObterPorNomeV2Async(nome);
            return Ok(pessoas);
        }

        [HttpGet("cpf")]
        public async Task<ActionResult<PessoaResponseDtoV2>> ObterPorCpf([FromQuery] string cpf)
        {
            var pessoa = await _service.ObterPorCpfV2Async(cpf);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }
    }
}
