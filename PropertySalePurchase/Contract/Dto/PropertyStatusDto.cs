﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase.Contract.Dto
{
    public class PropertyStatusDto
    {
        public int? Id { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }
    }
}
