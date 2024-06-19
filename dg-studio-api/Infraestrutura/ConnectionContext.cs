using Microsoft.EntityFrameworkCore;
using dg_studio_api.Model;

namespace dg_studio_api.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=Dgstudio;" +
                "User Id=postgres;" +
                "Password=Wa2157@@");
    }
}
