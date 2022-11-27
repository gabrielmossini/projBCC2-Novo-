using Microsoft.EntityFrameworkCore;

namespace projBCC2.Models
{
    public class Contexto: DbContext
    {
        public DbSet<Cliente> clientes { get; set; } = null!;

        public DbSet<Compra> compras { get; set; } = null!;

        public DbSet<Empresa> empresas { get; set; } = null!;

        public DbSet<Funcionario> funcionarios { get; set; } = null!;

        public DbSet<Movimentacao> balancete { get; set; } = null!;

        public DbSet<Produto> produtos { get; set; } = null!;

        public DbSet<Revenda> revendas { get; set; } = null!;

        public Contexto(DbContextOptions<Contexto> options) : 
            base(options) 
        { }
    }
}
