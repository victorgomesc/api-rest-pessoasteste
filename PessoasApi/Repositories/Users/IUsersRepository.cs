using PessoasApi.Models;

namespace PessoasApi.Repositories
{
    public interface IUsersRepository
    {
        Task<Users?> GetByUsernameAsync(string username);
        Task<Users> CreateAsync(Users user);
    }
}
