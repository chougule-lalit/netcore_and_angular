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
    public class RoleMasterController : IRoleMasterAppService
    {
        private readonly IRoleMasterAppService _roleMasterAppService;

        public RoleMasterController(IRoleMasterAppService roleMasterAppService)
        {
            _roleMasterAppService = roleMasterAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdateAsync(RoleMasterDto input)
        {
            return _roleMasterAppService.CreateOrUpdateAsync(input);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public virtual Task DeleteRoleAsync(int id)
        {
            return _roleMasterAppService.DeleteRoleAsync(id);
        }

        [HttpPost]
        [Route("fetchRolesList")]
        public virtual Task<PagedResultDto<RoleMasterDto>> FetchRolesListAsync(GetRoleInputDto input)
        {
            return _roleMasterAppService.FetchRolesListAsync(input);
        }

        [HttpGet]
        [Route("getRole/{id}")]
        public virtual Task<RoleMasterDto> GetRoleAsync(int id)
        {
            return _roleMasterAppService.GetRoleAsync(id);
        }

        [HttpGet]
        [Route("getRoleDropdown")]
        public virtual Task<List<RoleDropdownDto>> GetRoleDropdownAsync()
        {
            return _roleMasterAppService.GetRoleDropdownAsync();
        }
    }
}
