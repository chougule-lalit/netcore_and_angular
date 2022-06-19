using PropertySalePurchase.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract
{
    public interface IStateCityAppService
    {
        Task CreateOrUpdateStateMasterAsync(StateMasterDto input);
        Task<StateMasterDto> GetStateMasterAsync(int id);
        Task DeleteStateMasterAsync(int id);
        Task CreateOrUpdateCityMasterAsync(CityMasterDto input);
        Task<CityMasterDto> GetCityMasterAsync(int id);
        Task DeleteCityMasterAsync(int id);
        Task<List<StateMasterDto>> GetStateDropDownAsync();
        Task<List<CityMasterDto>> GetCityDropDownAsync();
        Task<PagedResultDto<StateMasterDto>> FetchStateMasterListAsync(GetStateMasterInputDto input);
        Task<PagedResultDto<CityMasterDto>> FetchCityMasterListAsync(GetStateMasterInputDto input);

    }
}
