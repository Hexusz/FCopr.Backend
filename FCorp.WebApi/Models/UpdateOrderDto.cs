using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCopr.Application.FCorp.Commands.UpdateOrder;
using FCorp.Domain;

namespace FCorp.WebApi.Models
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderPositions> Positions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
                .ForMember(orderCommand => orderCommand.OrderId,
                    opt => opt.MapFrom(orderDto => orderDto.OrderId))
                .ForMember(orderCommand => orderCommand.ClientFullName,
                    opt => opt.MapFrom(orderDto => orderDto.ClientFullName))
                .ForMember(orderCommand => orderCommand.Positions,
                    opt => opt.MapFrom(orderDto => orderDto.Positions))
                .ForMember(orderCommand => orderCommand.Status,
                    opt => opt.MapFrom(orderDto => orderDto.Status));
        }
    }
}