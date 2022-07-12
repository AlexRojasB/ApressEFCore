using InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DBLibrary
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {

        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=cmddbuser; Password=pa55w0rd!; Host=localhost; Port=5432; Database=ApressEFCoreInventory; Pooling=true;");
            }
        }
        private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";

        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                var referenceEntity = entry.Entity as FullAuditModel;
                switch (entry.State)
                {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(referenceEntity.CreatedByUserId))
                        {
                            referenceEntity.CreatedByUserId = _systemUserId;
                        }
                        break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(referenceEntity.LastModifiedUserId))
                        {
                            referenceEntity.LastModifiedUserId = _systemUserId;
                        }
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Item> Items { get; set; }
    }
}
