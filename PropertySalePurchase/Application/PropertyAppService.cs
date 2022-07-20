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
    public class PropertyAppService : IPropertyAppService
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

        public async Task CreateOrUpdateAsync(PropertyDetailDto input)
        {
            if (input.Id.HasValue)
            {
                var pd = await _dbContext.PropertyDetails.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (pd != null)
                {
                    _mapper.Map(input, pd);
                    var city = await _dbContext.CityMasters.FindAsync(input.CityId);                    
                    pd.City = city;
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<PropertyDetail>(input);
                var city = await _dbContext.CityMasters.FindAsync(input.CityId);
                if (city != null)
                    userToCreate.City = city;
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PropertyDetailDto> GetAsync(int id)
        {
            var data = await _dbContext.PropertyDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            var returnData = _mapper.Map<PropertyDetailDto>(data);

            var city = await _dbContext.CityMasters.FirstOrDefaultAsync(x => x.Id == data.CityId);
            if (city != null)
                returnData.CityName = city.Name;

            return returnData;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.PropertyDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.PropertyDetails.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<PropertyDetailDto>> FetchPropertyListAsync(GetPropertyTypeInputDto input)
        {
            var propertyQuerable = from p in _dbContext.PropertyDetails
                                   join ps in _dbContext.PropertyStatuses on p.PropertyStatusId equals ps.Id
                                   join pt in _dbContext.PropertyTypes on p.PropertyTypeId equals pt.Id
                                   join c in _dbContext.CityMasters on p.CityId equals c.Id
                                   join ub in _dbContext.UserMasters on p.PropertyBuyerId equals ub.Id into ubSet
                                   from ub in ubSet.DefaultIfEmpty()
                                   join us in _dbContext.UserMasters on p.PropertyOwnerId equals us.Id
                                   select new PropertyDetailDto
                                   {
                                       Id = p.Id,
                                       PropertyOwnerId = p.PropertyOwnerId,
                                       PropertyBuyerId = p.PropertyBuyerId,
                                       Address1 = p.Address1,
                                       Address2 = p.Address2,
                                       CityId = p.CityId,
                                       CityName = c.Name,
                                       Pincode = p.Pincode,
                                       PropertyTypeId = p.PropertyTypeId,
                                       PropertyType = pt.Type,
                                       PropertyStatusId = p.PropertyStatusId,
                                       PropertyStatus = ps.Status,
                                       PropertyBuyerName = $"{ub.FirstName} {ub.LastName}",
                                       PropertyOwnerName = $"{us.FirstName} {us.LastName}"
                                   };

            if (input.CityId.HasValue)
                propertyQuerable = propertyQuerable.Where(x => x.CityId == input.CityId.Value);

            if (input.PropertyStatusId.HasValue)
                propertyQuerable = propertyQuerable.Where(x => x.PropertyStatusId == input.PropertyStatusId.Value);

            if (input.PropertyTypeId.HasValue)
                propertyQuerable = propertyQuerable.Where(x => x.PropertyTypeId == input.PropertyTypeId.Value);

            var data = await propertyQuerable.ToListAsync();

            var count = data.Count;

            var returnData = data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<PropertyDetailDto>
            {
                Items = returnData,
                TotalCount = count
            };
        }

        public async Task<List<PropertyTypeDto>> GetPropertyTypeAsync()
        {
            var data = await _dbContext.PropertyTypes.ToListAsync();
            return _mapper.Map<List<PropertyTypeDto>>(data);
        }

        public async Task<List<PropertyStatusDto>> GetPropertyStatusAsync()
        {
            var data = await _dbContext.PropertyStatuses.ToListAsync();
            return _mapper.Map<List<PropertyStatusDto>>(data);
        }
    }
}
