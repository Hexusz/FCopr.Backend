using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCorp.Domain;

namespace FCopr.Application.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public ushort OrderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(orderDto => orderDto.OrderId,
                    opt => opt.MapFrom(order => order.OrderId));
        }
    }
}
