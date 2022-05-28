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
        public DbSet<Customer> Customers { get; set; }
        public PropertySalePurchaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
