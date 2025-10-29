using firm_registry_api.Models;
using firm_registry_api.Models.firm_registry_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace firm_registry_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyRequest> CompanyRequests { get; set; }
        public DbSet<Owner> Owners { get; set; } 
        public DbSet<LimitedCompanyFounder> LimitedCompanyFounders { get; set; } 
        public DbSet<Shareholder> Shareholders { get; set; } 
        public DbSet<Partner> Partners { get; set; } 
        public DbSet<GeneralPartner> GeneralPartners { get; set; } 
        public DbSet<LimitedPartner> LimitedPartners { get; set; } 

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ActivitySector> ActivitySectors { get; set; }
        public DbSet<ActivityGroup> ActivityGroups { get; set; }
        public DbSet<ActivityCode> ActivityCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyRequest>()
                .UseTptMappingStrategy();

            modelBuilder.Entity<EntrepreneurRequest>().ToTable("EntrepreneurRequests");
            modelBuilder.Entity<JointStockCompanyRequest>().ToTable("JointStockCompanyRequests");
            modelBuilder.Entity<LimitedCompanyRequest>().ToTable("LimitedCompanyRequests");
            modelBuilder.Entity<LimitedPartnershipRequest>().ToTable("LimitedPartnershipRequests");
            modelBuilder.Entity<PartnershipRequest>().ToTable("PartnershipRequests");

            modelBuilder.Entity<EntrepreneurRequest>()
                .HasOne(e => e.Owner)
                .WithOne(o => o.EntrepreneurRequest)
                .HasForeignKey<Owner>(o => o.EntrepreneurRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LimitedCompanyRequest>()
                .HasMany(c => c.Founders)
                .WithOne(f => f.LimitedCompanyRequest)
                .HasForeignKey(f => f.LimitedCompanyRequestId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JointStockCompanyRequest>()
                .HasMany(c => c.Shareholders)
                .WithOne(s => s.JointStockCompanyRequest)
                .HasForeignKey(s => s.JointStockCompanyRequestId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LimitedPartnershipRequest>()
                .HasMany(c => c.LimitedPartners)
                .WithOne(lp => lp.LimitedPartnershipRequest)
                .HasForeignKey(lp => lp.LimitedPartnershipRequestId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LimitedPartnershipRequest>()
                .HasMany(c => c.GeneralPartners)
                .WithOne(gp => gp.LimitedPartnershipRequest)
                .HasForeignKey(gp => gp.LimitedPartnershipRequestId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PartnershipRequest>()
                .HasMany(c => c.Partners)
                .WithOne(p => p.PartnershipRequest)
                .HasForeignKey(p => p.PartnershipRequestId) 
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<CompanyRequest>()
                 .HasOne(c => c.Address)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Cascade);

            var stringListComparer = new ValueComparer<List<string>>(
                 (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList());

            modelBuilder.Entity<CompanyRequest>()
            .Property(c => c.Documents)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
            )
            .Metadata.SetValueComparer(stringListComparer);

            modelBuilder.Entity<ActivityGroup>()
                 .HasMany(g => g.ActivityCodes)
                 .WithOne(c => c.ActivityGroup)
                 .HasForeignKey(c => c.ActivityGroupId);

            modelBuilder.SeedActivities();
        }
    }
}