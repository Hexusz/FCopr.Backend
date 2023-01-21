using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCorp.Domain;

namespace FCopr.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderPositions> Positions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderVm => orderVm.ClientFullName,
                    opt => opt.MapFrom(order => order.ClientFullName))
                .ForMember(orderVm => orderVm.OrderId,
                    opt => opt.MapFrom(order => order.OrderId))
                .ForMember(orderVm => orderVm.Positions,
                    opt => opt.MapFrom(order => order.Positions))
                .ForMember(orderVm => orderVm.Status,
                    opt => opt.MapFrom(order => order.Status));
        }
    }
}
