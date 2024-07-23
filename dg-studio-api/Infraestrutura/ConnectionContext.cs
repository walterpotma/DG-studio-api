using Microsoft.EntityFrameworkCore;
using dg_studio_api.Model;

namespace dg_studio_api.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cache> Cache { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Dgstudio;User Id=postgres;Password=Wa2157@@");
            }
        }
    }
}
