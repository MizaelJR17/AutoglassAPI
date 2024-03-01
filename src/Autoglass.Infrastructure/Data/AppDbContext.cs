// Autoglass.Infrastructure/Data/AppDbContext.cs
using Autoglass.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de mapeamento de entidade, chaves primárias, etc.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>();
            
        }
    }
}
