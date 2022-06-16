using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Entities
{
    public class PropertyDetail
    {
        public int Id { get; set; }

        public UserMaster PropertyOwner { get; set; }

        public int PropertyOwnerId { get; set; }

        public int? PropertyBuyerId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public CityMaster City { get; set; }

        public int CityId { get; set; }

        public int Pincode { get; set; }

        public PropertyType PropertyType { get; set; }

        public int PropertyTypeId { get; set; }

        public PropertyStatus PropertyStatus { get; set; }

        public int PropertyStatusId { get; set; }
    }
}
