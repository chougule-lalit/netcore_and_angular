using PropertySalePurchase.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract
{
    public interface IPropertyAppService
    {
        Task CreateOrUpdateAsync(PropertyDetailDto input);
        Task<EnquiryDto> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<PagedResultDto<PropertyDetailDto>> FetchPropertyListAsync(GetPropertyTypeInputDto input);
        Task<List<PropertyTypeDto>> GetPropertyTypeAsync();
        Task<List<PropertyStatusDto>> GetPropertyStatusAsync();

    }
}
