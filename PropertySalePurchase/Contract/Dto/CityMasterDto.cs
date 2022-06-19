using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract.Dto
{
    public class CityMasterDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int StateId { get; set; }
    }

    public class GetCityInputDto : PagedResultInput
    {

    }
}
