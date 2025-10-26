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
        public DbSet<EntrepreneurRequest> EntrepreneurRequests { get; set; }
        public DbSet<LimitedCompanyRequest> LimitedCompanyRequests { get; set; }
        public DbSet<JointStockCompanyRequest> JointStockCompanyRequests { get; set; }
        public DbSet<PartnershipRequest> PartnershipRequests { get; set; }
        public DbSet<LimitedPartnershipRequest> LimitedPartnershipRequests { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Founder> Founders { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
