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
    public class StateCityAppService : IStateCityAppService
    {
        private readonly PropertySalePurchaseDbContext _dbContext;
        private readonly IMapper _mapper;

        public StateCityAppService(
            PropertySalePurchaseDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateStateMasterAsync(StateMasterDto input)
        {
            if (input.Id.HasValue)
            {
                var pd = await _dbContext.StateMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (pd != null)
                {
                    _mapper.Map(input, pd);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<StateMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<StateMasterDto> GetStateMasterAsync(int id)
        {
            var data = await _dbContext.StateMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return _mapper.Map<StateMasterDto>(data);
        }

        public async Task DeleteStateMasterAsync(int id)
        {
            var data = await _dbContext.StateMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.StateMasters.Remove(data);
            }
        }

        public async Task CreateOrUpdateCityMasterAsync(CityMasterDto input)
        {
            if (input.Id.HasValue)
            {
                var pd = await _dbContext.CityMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (pd != null)
                {
                    _mapper.Map(input, pd);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<CityMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<CityMasterDto> GetCityMasterAsync(int id)
        {
            var data = await _dbContext.CityMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return _mapper.Map<CityMasterDto>(data);
        }

        public async Task DeleteCityMasterAsync(int id)
        {
            var data = await _dbContext.CityMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.CityMasters.Remove(data);
            }
        }

        public async Task<List<StateMasterDto>> GetStateDropDownAsync()
        {
            return _mapper.Map<List<StateMasterDto>>(await _dbContext.StateMasters.ToListAsync());
        }

        public async Task<List<CityMasterDto>> GetCityDropDownAsync()
        {
            return _mapper.Map<List<CityMasterDto>>(await _dbContext.CityMasters.ToListAsync());
        }

        public async Task<PagedResultDto<StateMasterDto>> FetchStateMasterListAsync(GetStateMasterInputDto input)
        {
            var stateData = _dbContext.StateMasters.AsQueryable();

            if (!string.IsNullOrEmpty(input.Search))
                stateData = stateData.Where(x => x.Name.ToLower() == input.Search.ToLower());

            var data = await stateData.ToListAsync();

            var count = data.Count;

            var returnData = _mapper.Map<List<StateMasterDto>>(data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());

            return new PagedResultDto<StateMasterDto>
            {
                Items = returnData,
                TotalCount = count
            };
        }

        public async Task<PagedResultDto<CityMasterDto>> FetchCityMasterListAsync(GetStateMasterInputDto input)
        {
            var cityData = _dbContext.CityMasters.AsQueryable();

            if (!string.IsNullOrEmpty(input.Search))
                cityData = cityData.Where(x => x.Name.ToLower() == input.Search.ToLower());

            var data = await cityData.ToListAsync();

            var count = data.Count;

            var returnData = _mapper.Map<List<CityMasterDto>>(data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());

            return new PagedResultDto<CityMasterDto>
            {
                Items = returnData,
                TotalCount = count
            };
        }
    }
}
