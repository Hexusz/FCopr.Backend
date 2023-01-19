using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using MediatR;

namespace FCopr.Application.FCorp.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public ushort Id { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderPosition> OrderPositions { get; set; }
    }
}
