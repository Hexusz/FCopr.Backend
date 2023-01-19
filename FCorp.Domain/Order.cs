﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCorp.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderPosition> OrderPositions { get; set; }
    }
}
