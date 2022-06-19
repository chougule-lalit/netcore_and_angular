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
    public class UserMasterAppService : IUserMasterAppService
    {
        private readonly PropertySalePurchaseDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserMasterAppService(
            PropertySalePurchaseDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateUser(UserMasterCreateUpdateDto input)
        {
            if (input.Id.HasValue)
            {
                var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (user != null)
                {
                    _mapper.Map(input, user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<UserMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<UserMasterDto>> FetchUserListAsync(GetUserInput input)
        {
            var data = from u in _dbContext.UserMasters
                       join r in _dbContext.RoleMasters on u.RoleId equals r.Id
                       select new UserMasterDto
                       {
                           Email = u.Email,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Id = u.Id,
                           Phone = u.Phone,
                           RoleId = r.Id,
                           RoleName = r.Name
                       };

            if (!string.IsNullOrEmpty(input.Search))
                data = data.Where(x => x.FirstName.ToLower().Contains(input.Search.ToLower()) ||
                            x.LastName.ToLower().Contains(input.Search.ToLower()));

            var count = data.Count();

            var userList = await data.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            return new PagedResultDto<UserMasterDto>
            {
                Items = userList,
                TotalCount = count
            };
        }

        public async Task<UserMasterDto> GetUserAsync(int id)
        {
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            return _mapper.Map<UserMasterDto>(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.UserMasters.Remove(user);
            }
        }

        public async Task<LoginOutputDto> LoginAsync(LoginInputDto input)
        {
            var output = new LoginOutputDto();
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Email == input.Email);
            if(user != null)
            {
                if (input.Password == user.Password)
                {
                    output.IsSuccess = true;
                    output.Role = (RoleEnum)user.RoleId;
                    output.Id = user.Id;
                }
                else
                    return output;
            }

            return output;
        }

    }
}
