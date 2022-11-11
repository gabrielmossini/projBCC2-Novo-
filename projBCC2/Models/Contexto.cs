using Microsoft.EntityFrameworkCore;
using projBCC2.Models;

namespace projBCC2.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<projBCC2.Models.Transacao> Transacao { get; set; }
    }
}
