using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FCopr.Application.Orders.Queries.GetGoodDetails
{
    public class GetGoodDetailsQuery : IRequest<GoodDetailsVm>
    {
        public sbyte Articul { get; set; }
    }
}
