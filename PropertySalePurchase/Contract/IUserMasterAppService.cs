using PropertySalePurchase.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract
{
    public interface IUserMasterAppService
    {
        Task CreateOrUpdateUser(UserMasterCreateUpdateDto input);
    }
}
