using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract
{
    public interface ICustomerAppService
    {
        Task<List<Customer>> GetAllCustomerAsync();
    }
}
