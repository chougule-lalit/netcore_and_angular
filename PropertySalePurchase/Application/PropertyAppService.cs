using AutoMapper;
using PropertySalePurchase.Contract;
using PropertySalePurchase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Application
{
    public class PropertyAppService: IPropertyAppService
    {
        private readonly PropertySalePurchaseDbContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyAppService(
            PropertySalePurchaseDbContext dbContext,
            IMapper mapper
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
