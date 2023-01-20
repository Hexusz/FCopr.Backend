using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FCopr.Application.Interfaces;
using FCopr.Application.Orders.Queries.GetOrderList;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Orders.Queries.GetGoodList
{
    public class GetGoodListQueryHandler 
        : IRequestHandler<GetGoodListQuery, GoodListVm>
    {
        private readonly IFCorpDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGoodListQueryHandler(IFCorpDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GoodListVm> Handle(GetGoodListQuery request,
            CancellationToken cancellationToken)
        {
            var goodQuery = await _dbContext.Goods
                .Where(good => good.Articul > 0)
                .ProjectTo<GoodLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GoodListVm() { Goods = goodQuery };
        }
    }
}
