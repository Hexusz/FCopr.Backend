﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FCopr.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryForDate : IRequest<OrderListVm>
    {
        public string Date { get; set; }
    }
}
