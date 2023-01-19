using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCorp.Domain;

namespace FCopr.Application.Notes.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(order => order.Id));
        }
    }
}
