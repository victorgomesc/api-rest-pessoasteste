using Moq;
using Xunit;
using PessoasApi.Services;
using PessoasApi.Repositories;
using PessoasApi.Models;
using PessoasApi.Dtos.v2;

namespace PessoasApi.Tests.Services
{
    public class PessoaServiceV2Tests
    {
        private readonly Mock<IPessoaRepository> _mockRepo;
        private readonly PessoaService _service;

        public PessoaServiceV2Tests()
        {
            _mockRepo = new Mock<IPessoaRepository>();
            _service = new PessoaService(_mockRepo.Object);
        }

        [Fact]
        public async Task ObterTodosV2Async_DeveRetornarLista()
        {
            _mockRepo.Setup(r => r.ObterTodosAsync()).ReturnsAsync(new List<Pessoa>
            {
                new Pessoa { Id = 1, Nome = "Victor", Cpf = "123", Endereco = "Rua Teste" }
            });

            var result = await _service.ObterTodosV2Async();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Victor", result.First().Nome);
        }

        [Fact]
        public async Task CriarV2Async_DeveRetornarPessoaCriada()
        {
            var dto = new PessoaCreateDtoV2
            {
                Nome = "Victor",
                Cpf = "123",
                Email = "victor@test.com",
                Endereco = "Rua Teste"
            };

            var pessoa = new Pessoa { Id = 1, Nome = dto.Nome, Cpf = dto.Cpf, Email = dto.Email, Endereco = dto.Endereco };

            _mockRepo.Setup(r => r.CriarAsync(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);

            var result = await _service.CriarV2Async(dto);

            Assert.NotNull(result);
            Assert.Equal("Victor", result.Nome);
        }

        [Fact]
        public async Task AtualizarV2Async_QuandoNaoExistir_DeveRetornarNull()
        {
            _mockRepo.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync((Pessoa?)null);

            var result = await _service.AtualizarV2Async(1, new PessoaUpdateDtoV2());

            Assert.Null(result);
        }

        [Fact]
        public async Task DeletarAsync_QuandoExistir_DeveRetornarTrue()
        {
            var pessoa = new Pessoa { Id = 1, Nome = "Victor" };

            _mockRepo.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(pessoa);
            _mockRepo.Setup(r => r.DeletarAsync(1)).ReturnsAsync(true); // ✅ corrigido

            var result = await _service.DeletarAsync(1);

            Assert.True(result);
        }
    }
}
