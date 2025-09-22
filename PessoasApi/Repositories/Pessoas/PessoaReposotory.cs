using Microsoft.EntityFrameworkCore;
using PessoasApi.Data;
using PessoasApi.Models;

namespace PessoasApi.Repositories
{
    public class PessoaRepository(AppDbContext context) : IPessoaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Pessoa?> ObterPorIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> ObterTodosAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<IEnumerable<Pessoa>> ObterPorNomeAsync(string nome)
        {
            return await _context.Pessoas
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();
        }

        public async Task<Pessoa?> ObterPorCpfAsync(string cpf)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<Pessoa> CriarAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa?> AtualizarAsync(Pessoa pessoa)
        {
            var existente = await _context.Pessoas.FindAsync(pessoa.Id);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(pessoa);
            existente.DataAtualizacao = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null) return false;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
