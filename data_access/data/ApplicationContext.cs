using data_access.Configurations;
using data_access.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace data_access.data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());

			DbInitializer.SeedData(modelBuilder);
        }
        public DbSet<Advertisement> Advertisements { get; set; } = null!;
        public DbSet<AdvertisementStatus> AdvertisementStatuses { get; set; } = null!;
        public DbSet<AdvertisePicture> AdvertisePictures { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<DeliveryCompany> DeliveryCompanies { get; set; } = null!;
        public DbSet<DeliveryContactInfo> DeliveryContactInfos { get; set; } = null!;
        public DbSet<DeliveryHomeAdrdess> DeliveryHomeAdrdesses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
