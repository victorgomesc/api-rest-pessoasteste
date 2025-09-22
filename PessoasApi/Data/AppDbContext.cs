using Microsoft.EntityFrameworkCore;
using PessoasApi.Models;

namespace PessoasApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
