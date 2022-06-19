using Microsoft.EntityFrameworkCore;
using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Data
{
    public class PropertySalePurchaseDbContext : DbContext
    {
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<PropertyDetail> PropertyDetails { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }


        public PropertySalePurchaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMaster>().HasData(
                new RoleMaster { Id = Convert.ToInt32(RoleEnum.Admin), Name = RoleEnum.Admin.ToString() },
                new RoleMaster { Id = Convert.ToInt32(RoleEnum.Buyer), Name = RoleEnum.Buyer.ToString() },
                new RoleMaster { Id = Convert.ToInt32(RoleEnum.Seller), Name = RoleEnum.Seller.ToString() },
                new RoleMaster { Id = Convert.ToInt32(RoleEnum.Agent), Name = RoleEnum.Agent.ToString() }
                );

            modelBuilder.Entity<UserMaster>()
                .HasOne(s => s.Role)
                .WithMany().HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<UserMaster>().HasData(
                new UserMaster { Email = "admin@admin.com", FirstName = "admin", LastName = "admin", Id = 1, Password = "admin", Phone = "9878656789", RoleId = Convert.ToInt32(RoleEnum.Admin) }
                );

            modelBuilder.Entity<CityMaster>()
                .HasOne(s => s.State)
                .WithMany().HasForeignKey(x => x.StateId);

            modelBuilder.Entity<PropertyDetail>()
                .HasOne(s => s.PropertyOwner)
                .WithMany().HasForeignKey(x => x.PropertyOwnerId);

            modelBuilder.Entity<PropertyDetail>()
                .HasOne(s => s.City)
                .WithMany().HasForeignKey(x => x.CityId);

            modelBuilder.Entity<PropertyDetail>()
                .HasOne(s => s.PropertyType)
                .WithMany().HasForeignKey(x => x.PropertyTypeId);

            modelBuilder.Entity<PropertyDetail>()
                .HasOne(s => s.PropertyStatus)
                .WithMany().HasForeignKey(x => x.PropertyStatusId);

            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = 1, Description = "Flat", Type = "Flat" },
                new PropertyType { Id = 2, Description = "Plot", Type = "Plot" },
                new PropertyType { Id = 3, Description = "Farm", Type = "Farm" }
               );

            modelBuilder.Entity<PropertyStatus>().HasData(
                new PropertyStatus { Id = 1, Description = "Ready to sale", Status = "Ready to sale" },
                new PropertyStatus { Id = 2, Description = "Sold", Status = "Sold" }
                );
        }
    }
}
