using Microsoft.EntityFrameworkCore;
using projBCC2.Models;

namespace projBCC2.Models
{
    public class Contexto: DbContext
    {
        public DbSet<Cliente> clientes { get; set; }

        public DbSet<Compra> compras { get; set; }

        public DbSet<Empresa> empresas { get; set; }

        public DbSet<Funcionario> funcionarios { get; set; }

        public DbSet<Movimentacao> balancete { get; set; }

        public DbSet<Produto> produtos { get; set; }

        public DbSet<Revenda> revendas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    }
}
