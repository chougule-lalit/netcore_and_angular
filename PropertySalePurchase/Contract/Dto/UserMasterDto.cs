using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract.Dto
{
    public class UserMasterDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RoleEnum Role { get; set; }
    }

    public class UserMasterCreateUpdateDto
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RoleEnum Role { get; set; }
    }
}
