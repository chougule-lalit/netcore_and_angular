using PropertySalePurchase.Contract;
using PropertySalePurchase.Contract.Dto;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PropertySalePurchase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMasterController : IUserMasterAppService
    {
        private readonly IUserMasterAppService _userMasterAppService;

        public UserMasterController(IUserMasterAppService userMasterAppService)
        {
            _userMasterAppService = userMasterAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdateUser(UserMasterCreateUpdateDto input)
        {
            return _userMasterAppService.CreateOrUpdateUser(input);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public virtual Task DeleteUserAsync(int id)
        {
            return _userMasterAppService.DeleteUserAsync(id);
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public virtual Task<UserMasterDto> GetUserAsync(int id)
        {
            return _userMasterAppService.GetUserAsync(id);
        }

        [HttpPost]
        [Route("fetchUserList")]
        public virtual Task<PagedResultDto<UserMasterDto>> FetchUserListAsync(GetUserInput input)
        {
            return _userMasterAppService.FetchUserListAsync(input);
        }

        [HttpPost]
        [Route("login")]
        public virtual Task<LoginOutputDto> LoginAsync(LoginInputDto input)
        {
            return _userMasterAppService.LoginAsync(input);
        }

        [HttpGet]
        [Route("getSellerList")]
        public virtual Task<List<UserDropdownDto>> GetSellerListAsync()
        {
            return _userMasterAppService.GetSellerListAsync();
        }

        [HttpGet]
        [Route("getBuyerList")]
        public virtual Task<List<UserDropdownDto>> GetBuyerListAsync()
        {
            return _userMasterAppService.GetBuyerListAsync();
        }

        [HttpGet]
        [Route("getAgentList")]
        public virtual Task<List<UserDropdownDto>> GetAgentListAsync()
        {
            return _userMasterAppService.GetAgentListAsync();
        }
    }
}
