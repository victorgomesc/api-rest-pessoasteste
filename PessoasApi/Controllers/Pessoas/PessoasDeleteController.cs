using Microsoft.AspNetCore.Mvc;
using PessoasApi.Services;

namespace PessoasApi.Controllers.Pessoas
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoasDeleteController(IPessoaService service) : ControllerBase
    {
        private readonly IPessoaService _service = service;

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                await _service.DeletarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
