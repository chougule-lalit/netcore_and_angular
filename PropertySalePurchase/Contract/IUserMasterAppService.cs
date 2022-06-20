﻿using PropertySalePurchase.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract
{
    public interface IUserMasterAppService
    {
        Task CreateOrUpdateUser(UserMasterCreateUpdateDto input);

        Task<PagedResultDto<UserMasterDto>> FetchUserListAsync(GetUserInput input);

        Task<UserMasterDto> GetUserAsync(int id);

        Task DeleteUserAsync(int id);

        Task<LoginOutputDto> LoginAsync(LoginInputDto input);

        Task<List<UserDropdownDto>> GetSellerListAsync();

        Task<List<UserDropdownDto>> GetBuyerListAsync();

        Task<List<UserDropdownDto>> GetAgentListAsync();


    }
}
