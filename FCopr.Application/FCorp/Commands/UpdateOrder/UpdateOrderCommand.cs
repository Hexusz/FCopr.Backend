using System;
using System.Collections.Generic;
using FCorp.Domain;
using MediatR;

namespace FCopr.Application.FCorp.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderPositions> Positions { get; set; }
    }
}
