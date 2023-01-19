using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FCorp.Domain;

namespace FCorp.WebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderPosition> OrderPositions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(orderCommand => orderCommand.OrderId,
                    opt => opt.MapFrom(noteDto => noteDto.OrderId))
                .ForMember(orderCommand => orderCommand.ClientFullName,
                    opt => opt.MapFrom(noteDto => noteDto.ClientFullName))
                .ForMember(orderCommand => orderCommand.Status,
                    opt => opt.MapFrom(noteDto => noteDto.Status))
                .ForMember(orderCommand => orderCommand.OrderPositions,
                    opt => opt.MapFrom(noteDto => noteDto.OrderPositions));
        }
    }
}