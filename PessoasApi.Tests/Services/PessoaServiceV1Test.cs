using Moq;
using Xunit;
using PessoasApi.Services;
using PessoasApi.Repositories;
using PessoasApi.Models;
using PessoasApi.Dtos.v1;

namespace PessoasApi.Tests.Services
{
    public class PessoaServiceV1Tests
    {
        private readonly Mock<IPessoaRepository> _mockRepo;
        private readonly PessoaService _service;

        public PessoaServiceV1Tests()
        {
            _mockRepo = new Mock<IPessoaRepository>();
            _service = new PessoaService(_mockRepo.Object);
        }

        [Fact]
        public async Task ObterTodosV1Async_DeveRetornarLista()
        {
            _mockRepo.Setup(r => r.ObterTodosAsync()).ReturnsAsync(new List<Pessoa>
            {
                new Pessoa { Id = 1, Nome = "Victor", Cpf = "123" }
            });

            var result = await _service.ObterTodosV1Async();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Victor", result.First().Nome);
        }

        [Fact]
        public async Task CriarV1Async_DeveRetornarPessoaCriada()
        {
            var dto = new PessoaCreateDtoV1
            {
                Nome = "Victor",
                Cpf = "123",
                Email = "victor@test.com"
            };

            var pessoa = new Pessoa { Id = 1, Nome = dto.Nome, Cpf = dto.Cpf, Email = dto.Email };

            _mockRepo.Setup(r => r.CriarAsync(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);

            var result = await _service.CriarV1Async(dto);

            Assert.NotNull(result);
            Assert.Equal("Victor", result.Nome);
        }

        [Fact]
        public async Task AtualizarV1Async_QuandoNaoExistir_DeveRetornarNull()
        {
            _mockRepo.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync((Pessoa?)null);

            var result = await _service.AtualizarV1Async(1, new PessoaUpdateDtoV1());

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
