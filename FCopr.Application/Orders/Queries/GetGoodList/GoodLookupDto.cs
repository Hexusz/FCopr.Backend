using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCorp.Domain;

namespace FCopr.Application.Orders.Queries.GetGoodList
{
    public class GoodLookupDto : IMapWith<Good>
    {
        public sbyte Articul { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Good, GoodLookupDto>()
                .ForMember(goodDto => goodDto.Name,
                    opt => opt.MapFrom(good => good.Name))
                .ForMember(goodDto => goodDto.Articul,
                    opt => opt.MapFrom(good => good.Articul))
                .ForMember(goodDto => goodDto.Price,
                    opt => opt.MapFrom(good => good.Price));
        }
    }
}
