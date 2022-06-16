using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Entities
{
    public class CityMaster
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public StateMaster State { get; set; }

        public int StateId { get; set; }
    }
}
