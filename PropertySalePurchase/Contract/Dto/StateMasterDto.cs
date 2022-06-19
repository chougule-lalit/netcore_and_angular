using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract.Dto
{
    public class StateMasterDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }

    public class GetStateMasterInputDto : PagedResultInput
    {

    }
}
