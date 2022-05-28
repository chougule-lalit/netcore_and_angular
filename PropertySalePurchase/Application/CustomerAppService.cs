using Microsoft.EntityFrameworkCore;
using PropertySalePurchase.Contract;
using PropertySalePurchase.Data;
using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly PropertySalePurchaseDbContext _dbContext;

        public CustomerAppService(PropertySalePurchaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
