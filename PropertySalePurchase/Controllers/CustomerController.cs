using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertySalePurchase.Contract;
using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController: ICustomerAppService
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [Route("getAllCustomers")]
        public Task<List<Customer>> GetAllCustomerAsync()
        {
            return _customerAppService.GetAllCustomerAsync();
        }
    }
}
