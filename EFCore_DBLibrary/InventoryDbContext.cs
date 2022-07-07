using InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DBLibrary
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {

        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=cmddbuser; Password=pa55w0rd!; Host=localhost; Port=5432; Database=ApressEFCoreInventory; Pooling=true;");
            }
        }

        public DbSet<Item> Items { get; set; }
    }
}
