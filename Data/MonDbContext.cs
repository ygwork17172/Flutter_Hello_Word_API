namespace Flutter_Hello_Word_API.Data
{
    using Flutter_Hello_Word_API.Data.Entities; // Assurez-vous que cela est correct
    using Microsoft.EntityFrameworkCore;

    public class MonDbContext : DbContext
    {
        public MonDbContext(DbContextOptions<MonDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
