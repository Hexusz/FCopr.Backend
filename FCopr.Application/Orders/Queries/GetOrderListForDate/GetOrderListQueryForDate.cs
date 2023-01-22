
using System;
using FCopr.Application.Orders.Queries.GetOrderList;
using MediatR;

namespace FCopr.Application.Orders.Queries.GetOrderListForDate
{
    public class GetOrderListQueryForDate : IRequest<OrderListVm>
    {
        public DateTime Date { get; set; }
    }
}
