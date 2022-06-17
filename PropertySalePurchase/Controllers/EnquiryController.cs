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
    public class EnquiryController: IEnquiryAppService
    {
        private readonly IEnquiryAppService _enquiryAppService;

        public EnquiryController(IEnquiryAppService enquiryAppService)
        {
            _enquiryAppService = enquiryAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdateUser(EnquiryDto input)
        {
            return _enquiryAppService.CreateOrUpdateUser(input);
        }

        [HttpDelete]
        [Route("delete")]
        public virtual Task DeleteAsync(int id)
        {
            return _enquiryAppService.DeleteAsync(id);
        }

        [HttpPost]
        [Route("fetchEnquiryList")]
        public virtual Task<PagedResultDto<EnquiryDto>> FetchEnquiryListAsync(GetEnquiryInputDto input)
        {
            return _enquiryAppService.FetchEnquiryListAsync(input);
        }

        [HttpGet]
        [Route("get")]
        public virtual Task<EnquiryDto> GetAsync(int id)
        {
            return _enquiryAppService.GetAsync(id);
        }
    }
}
