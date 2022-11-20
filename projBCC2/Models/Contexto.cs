using Microsoft.EntityFrameworkCore;
using projBCC2.Models;

namespace projBCC2.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<projBCC2.Models.Transacao> transacoes { get; set; }
        public DbSet<Conta> contas { get; set; }
    }
}
