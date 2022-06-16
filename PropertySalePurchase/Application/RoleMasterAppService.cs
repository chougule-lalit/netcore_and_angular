using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertySalePurchase.Contract;
using PropertySalePurchase.Contract.Dto;
using PropertySalePurchase.Data;
using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Application
{
    public class RoleMasterAppService: IRoleMasterAppService
    {
        private readonly PropertySalePurchaseDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoleMasterAppService(
            PropertySalePurchaseDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateAsync(RoleMasterDto input)
        {
            if (input.Id.HasValue)
            {
                var role = await _dbContext.RoleMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (role != null)
                {
                    _mapper.Map(input, role);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var roleToCreate = _mapper.Map<RoleMaster>(input);
                await _dbContext.AddAsync(roleToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<RoleMasterDto> GetRoleAsync(int id)
        {
            var user = await _dbContext.RoleMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            return _mapper.Map<RoleMasterDto>(user);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var user = await _dbContext.RoleMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.RoleMasters.Remove(user);
            }
        }
    }
}
