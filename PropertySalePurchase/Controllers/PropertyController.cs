using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertySalePurchase.Contract;
using PropertySalePurchase.Contract.Dto;

namespace PropertySalePurchase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController: IPropertyAppService
    {
        private readonly IPropertyAppService _propertyAppService;

        public PropertyController(IPropertyAppService propertyAppService)
        {
            _propertyAppService = propertyAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdateAsync(PropertyDetailDto input)
        {
            return _propertyAppService.CreateOrUpdateAsync(input);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _propertyAppService.DeleteAsync(id);
        }

        [HttpPost]
        [Route("fetchPropertyList")]
        public virtual Task<PagedResultDto<PropertyDetailDto>> FetchPropertyListAsync(GetPropertyTypeInputDto input)
        {
            return _propertyAppService.FetchPropertyListAsync(input);
        }

        [HttpGet]
        [Route("get/{id}")]
        public virtual Task<PropertyDetailDto> GetAsync(int id)
        {
            return _propertyAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("getPropertyStatus")]
        public virtual Task<List<PropertyStatusDto>> GetPropertyStatusAsync()
        {
            return _propertyAppService.GetPropertyStatusAsync();
        }

        [HttpGet]
        [Route("getPropertyType")]
        public virtual Task<List<PropertyTypeDto>> GetPropertyTypeAsync()
        {
            return _propertyAppService.GetPropertyTypeAsync();
        }
    }
}
