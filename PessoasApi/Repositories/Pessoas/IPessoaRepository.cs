using PessoasApi.Models;

namespace PessoasApi.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa?> ObterPorIdAsync(int id);
        Task<IEnumerable<Pessoa>> ObterTodosAsync();
        Task<IEnumerable<Pessoa>> ObterPorNomeAsync(string nome);
        Task<Pessoa?> ObterPorCpfAsync(string cpf);
        Task<Pessoa> CriarAsync(Pessoa pessoa);
        Task<Pessoa?> AtualizarAsync(Pessoa pessoa);
        Task<bool> DeletarAsync(int id);
    }
}
