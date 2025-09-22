using FluentAssertions;
using Microsoft.Extensions.Configuration;
using PessoasApi.Models;
using PessoasApi.Services;
using Xunit;

namespace PessoasApi.Tests.Services
{
    public class TokenServiceTests
    {
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Key", new string('a', 64)}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            _tokenService = new TokenService(configuration);
        }

        [Fact]
        public void Generate_DeveRetornarTokenValido()
        {
            var user = new Users
            {
                Id = 1,
                Username = "victor",
                Email = "victor@test.com"
            };

            var token = _tokenService.Generate(user);

            token.Should().NotBeNullOrEmpty();
            token.Should().Contain(".");
        }
    }
}
