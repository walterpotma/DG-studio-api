using Microsoft.EntityFrameworkCore;
using dg_studio_api.Model;

namespace dg_studio_api.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cache> Cache { get; set; }
        public DbSet<Hqs> Hqs { get; set; }
        public DbSet<Capitulos> Capitulos { get; set; }
        public DbSet<Paginas> Paginas { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ep-shrill-smoke-a4eb74ri.us-east-1.aws.neon.tech;Port=5432;Database=verceldb;Username=default;Password=GapgWPN2hL4i;SslMode=Require");
            }
        }
    }
}
