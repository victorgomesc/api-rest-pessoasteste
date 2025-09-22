using Moq;
using Xunit;
using PessoasApi.Models;
using PessoasApi.Repositories;
using PessoasApi.Services;
using System.Threading.Tasks;

namespace PessoasApi.Tests.Services
{
    public class UsersServicesTests
    {
        private readonly Mock<IUsersRepository> _repoMock;
        private readonly UsersService _service;

        public UsersServicesTests()
        {
            _repoMock = new Mock<IUsersRepository>();
            _service = new UsersService(_repoMock.Object);
        }

        [Fact]
        public async Task RegisterAsync_DeveCriarUsuario()
        {
            // Arrange
            var novoUser = new Users
            {
                Username = "victor",
                Email = "victor@test.com",
                Password = "1234"
            };

            _repoMock.Setup(r => r.CreateAsync(It.IsAny<Users>()))
                     .ReturnsAsync(novoUser);

            // Act
            var result = await _service.RegisterAsync(novoUser.Username, novoUser.Email, novoUser.Password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("victor", result.Username);
            Assert.Equal("victor@test.com", result.Email);
        }

        [Fact]
        public async Task LoginAsync_DeveRetornarUsuario_QuandoCredenciaisValidas()
        {
            // Arrange
            var user = new Users
            {
                Username = "victor",
                Email = "victor@test.com",
                Password = "1234"
            };

            _repoMock.Setup(r => r.GetByUsernameAsync("victor"))
                     .ReturnsAsync(user);

            // Act
            var result = await _service.LoginAsync("victor", "1234");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("victor@test.com", result.Email);
        }

        [Fact]
        public async Task LoginAsync_DeveRetornarNull_QuandoSenhaIncorreta()
        {
            // Arrange
            var user = new Users
            {
                Username = "victor",
                Email = "victor@test.com",
                Password = "1234"
            };

            _repoMock.Setup(r => r.GetByUsernameAsync("victor"))
                     .ReturnsAsync(user);

            // Act
            var result = await _service.LoginAsync("victor", "senhaErrada");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task LoginAsync_DeveRetornarNull_QuandoUsuarioNaoExiste()
        {
            // Arrange
            _repoMock.Setup(r => r.GetByUsernameAsync("inexistente"))
                     .ReturnsAsync((Users?)null);

            // Act
            var result = await _service.LoginAsync("inexistente", "1234");

            // Assert
            Assert.Null(result);
        }
    }
}
