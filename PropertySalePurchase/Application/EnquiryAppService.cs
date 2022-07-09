﻿using AutoMapper;
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
    public class EnquiryAppService: IEnquiryAppService
    {
        private readonly PropertySalePurchaseDbContext _dbContext;
        private readonly IMapper _mapper;

        public EnquiryAppService(PropertySalePurchaseDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateUser(EnquiryDto input)
        {
            if (input.Id.HasValue)
            {
                var user = await _dbContext.Enquiries.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (user != null)
                {
                    _mapper.Map(input, user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<Enquiry>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<EnquiryDto> GetAsync(int id)
        {
            var data = await _dbContext.Enquiries.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return _mapper.Map<EnquiryDto>(data);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.Enquiries.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.Enquiries.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<EnquiryDto>> FetchEnquiryListAsync(GetEnquiryInputDto input)
        {
            var data = await _dbContext.Enquiries.ToListAsync();

            var count = data.Count;

            var returnData = data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<EnquiryDto>
            {
                Items = _mapper.Map<List<EnquiryDto>>(returnData),
                TotalCount = count
            };
        }

    }
}
