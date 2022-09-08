using ApiDeliveryFlutter.models;
using Microsoft.EntityFrameworkCore;

namespace ApiDeliveryFlutter.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
