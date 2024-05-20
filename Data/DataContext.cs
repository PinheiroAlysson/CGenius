using CGenius.Models;
using Microsoft.EntityFrameworkCore;

namespace CGenius.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<ScriptVendas> Scripts { get; set; }    
    }
}
