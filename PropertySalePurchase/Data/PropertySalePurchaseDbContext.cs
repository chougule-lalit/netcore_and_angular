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
        public PropertySalePurchaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
