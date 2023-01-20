using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Mappings;
using FCopr.Application.Orders.Queries.GetOrderDetails;
using FCorp.Domain;

namespace FCopr.Application.Orders.Queries.GetGoodDetails
{
    public class GoodDetailsVm : IMapWith<Good>
    {
        public sbyte Articul { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Good, GoodDetailsVm>()
                .ForMember(goodVm => goodVm.Name,
                    opt => opt.MapFrom(good => good.Name))
                .ForMember(goodVm => goodVm.Price,
                    opt => opt.MapFrom(good => good.Price))
                .ForMember(goodVm => goodVm.Articul,
                    opt => opt.MapFrom(good => good.Articul));
        }
    }
}
