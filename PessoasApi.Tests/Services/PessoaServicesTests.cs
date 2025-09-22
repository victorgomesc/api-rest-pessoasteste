using Xunit;
using PessoasApi.Services;
using PessoasApi.Repositories;
using PessoasApi.Data;
using Microsoft.EntityFrameworkCore;
using PessoasApi.Dtos.v1;

namespace PessoasApi.Tests.Services
{
    public class PessoaServiceTests
    {
        private readonly PessoaService _service;
        private readonly AppDbContext _context;

        public PessoaServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new AppDbContext(options);

            // ✅ cria repositório com o contexto
            var repo = new PessoaRepository(_context);

            // ✅ passa o repositório para o serviço
            _service = new PessoaService(repo);
        }

        [Fact]
        public async Task CriarV1Async_DeveAdicionarPessoa()
        {
            var dto = new PessoaCreateDtoV1
            {
                Nome = "Teste",
                Sexo = "Masculino",
                Email = "teste@example.com",
                DataNascimento = DateTime.Parse("1990-01-01"),
                Cpf = "12345678901",
                Nacionalidade = "Brasileira",
                Naturalidade = "Fortaleza"
            };

            var result = await _service.CriarV1Async(dto);

            Assert.NotNull(result);
            Assert.Equal("Teste", result.Nome);
        }
    }
}
