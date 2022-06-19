using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract.Dto
{
    public class PropertyDetailDto
    {
        public int? Id { get; set; }

        public int PropertyOwnerId { get; set; }

        public string PropertyOwnerName { get; set; }

        public int? PropertyBuyerId { get; set; }

        public string PropertyBuyerName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public int Pincode { get; set; }

        public int PropertyTypeId { get; set; }

        public string PropertyType { get; set; }

        public int PropertyStatusId { get; set; }

        public string PropertyStatus { get; set; }
    }

    public class GetPropertyTypeInputDto : PagedResultInput
    {
        public int? CityId { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? PropertyStatusId { get; set; }
    }
}
