using CedroRestaurante.Dominio.Entities;
using CedroRestaurante.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace CedroRestaurante.Infra.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.ApplyConfiguration(new RestauranteConfig());
            construtorDeModelos.ApplyConfiguration(new PratoConfig());
            base.OnModelCreating(construtorDeModelos);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DB_restaurante;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
