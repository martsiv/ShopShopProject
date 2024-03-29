﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
