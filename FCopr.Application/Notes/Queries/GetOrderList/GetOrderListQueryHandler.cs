using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FCopr.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Notes.Queries.GetOrderList
{
    public class GetOrderListQueryHandler
        : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IFCorpDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IFCorpDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrderListQuery request,
            CancellationToken cancellationToken)
        {
            var ordersQuery = await _dbContext.Orders
                .Where(order => order.Id == request.Id)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}