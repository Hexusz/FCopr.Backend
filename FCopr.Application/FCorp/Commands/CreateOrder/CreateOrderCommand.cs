using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using MediatR;

namespace FCopr.Application.FCorp.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<ushort>
    {
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<Good> Goods { get; set; }
    }
}
