using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Entities
{
    public class UserMaster
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RoleEnum Role { get; set; }
    }
}
