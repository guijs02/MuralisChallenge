using Microsoft.EntityFrameworkCore;
using Muralis.Infra.Models;

namespace Muralis.Infra.Data
{
    public class MuralisAppContext : DbContext
    {
        public MuralisAppContext(DbContextOptions<MuralisAppContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; } = null!;
        public DbSet<ContatoModel> Contato { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
        }
    }
}
