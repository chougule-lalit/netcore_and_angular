using PropertySalePurchase.Contract;
using PropertySalePurchase.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PropertySalePurchase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateCityController: IStateCityAppService
    {
        private readonly IStateCityAppService _stateCityAppService;

        public StateCityController(
            IStateCityAppService stateCityAppService)
        {
            _stateCityAppService = stateCityAppService;
        }

        [HttpPost]
        [Route("createOrUpdateCity")]
        public virtual Task CreateOrUpdateCityMasterAsync(CityMasterDto input)
        {
            return _stateCityAppService.CreateOrUpdateCityMasterAsync(input);
        }

        [HttpPost]
        [Route("createOrUpdateState")]
        public virtual Task CreateOrUpdateStateMasterAsync(StateMasterDto input)
        {
            return _stateCityAppService.CreateOrUpdateStateMasterAsync(input);
        }

        [HttpDelete]
        [Route("deleteCity")]
        public virtual Task DeleteCityMasterAsync(int id)
        {
            return _stateCityAppService.DeleteCityMasterAsync(id);
        }

        [HttpDelete]
        [Route("deleteState")]
        public virtual Task DeleteStateMasterAsync(int id)
        {
            return _stateCityAppService.DeleteStateMasterAsync(id);
        }

        [HttpPost]
        [Route("fetchCityMasterList")]
        public virtual Task<PagedResultDto<CityMasterDto>> FetchCityMasterListAsync(GetStateMasterInputDto input)
        {
            return _stateCityAppService.FetchCityMasterListAsync(input);
        }

        [HttpPost]
        [Route("fetchStateMasterList")]
        public virtual Task<PagedResultDto<StateMasterDto>> FetchStateMasterListAsync(GetStateMasterInputDto input)
        {
            return _stateCityAppService.FetchStateMasterListAsync(input);
        }

        [HttpGet]
        [Route("getCityDropdown")]
        public virtual Task<List<CityMasterDto>> GetCityDropDownAsync()
        {
            return _stateCityAppService.GetCityDropDownAsync();
        }

        [HttpGet]
        [Route("getCity/{id}")]
        public virtual Task<CityMasterDto> GetCityMasterAsync(int id)
        {
            return _stateCityAppService.GetCityMasterAsync(id);
        }

        [HttpGet]
        [Route("getStateDropdown")]
        public virtual Task<List<StateMasterDto>> GetStateDropDownAsync()
        {
            return _stateCityAppService.GetStateDropDownAsync();
        }

        [HttpGet]
        [Route("getState/{id}")]
        public virtual Task<StateMasterDto> GetStateMasterAsync(int id)
        {
            return _stateCityAppService.GetStateMasterAsync(id);
        }
    }
}
