using PessoasApi.Models;
using PessoasApi.Repositories;

namespace PessoasApi.Services
{
    public interface IUsersService
    {
        Task<Users?> LoginAsync(string username, string password);
        Task<Users> RegisterAsync(string username, string email, string password);
        Task<Users?> GetByUsernameAsync(string username);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Users?> LoginAsync(string username, string password)
        {
            var user = await _repository.GetByUsernameAsync(username);

            if (user == null || user.Password != password)
                return null;

            return user;
        }

        public async Task<Users> RegisterAsync(string username, string email, string password)
        {
            var existing = await _repository.GetByUsernameAsync(username);
            if (existing != null)
                throw new InvalidOperationException("Usuário já existe");

            var newUser = new Users
            {
                Username = username,
                Email = email,
                Password = password
            };

            return await _repository.CreateAsync(newUser);
        }

        public async Task<Users?> GetByUsernameAsync(string username)
        {
            return await _repository.GetByUsernameAsync(username);
        }
    }
}
