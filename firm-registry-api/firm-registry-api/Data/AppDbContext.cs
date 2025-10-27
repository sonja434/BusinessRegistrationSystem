using firm_registry_api.Models;
using firm_registry_api.Models.Enums;
using Microsoft.EntityFrameworkCore;


namespace firm_registry_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyRequest> CompanyRequests { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ActivitySector> ActivitySectors { get; set; }
        public DbSet<ActivityGroup> ActivityGroups { get; set; }
        public DbSet<ActivityCode> ActivityCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyRequest>()
                .HasDiscriminator<string>("CompanyType")
                .HasValue<EntrepreneurRequest>("Entrepreneur")
                .HasValue<JointStockCompanyRequest>("JointStockCompany")
                .HasValue<LimitedCompanyRequest>("LimitedCompany")
                .HasValue<LimitedPartnershipRequest>("LimitedPartnership")
                .HasValue<PartnershipRequest>("Partnership");

            modelBuilder.Entity<CompanyRequest>()
                .HasOne(c => c.Address)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyRequest>()
                .Property(c => c.Documents)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            modelBuilder.Entity<Founder>()
                .HasOne(f => f.CompanyRequest)
                .WithMany()
                .HasForeignKey(f => f.CompanyRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityGroup>()
                .HasMany(g => g.ActivityCodes)
                .WithOne(c => c.ActivityGroup)
                .HasForeignKey(c => c.ActivityGroupId);

            modelBuilder.SeedActivities();
        }
    }
}
