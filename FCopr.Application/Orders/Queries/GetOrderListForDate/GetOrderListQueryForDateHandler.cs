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
using FCorp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Orders.Queries.GetOrderListForDate
{
    public class GetOrderListQueryForDateHandler : IRequestHandler<GetOrderListQueryForDate, OrderListVm>
    {
        private readonly IFCorpDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryForDateHandler(IFCorpDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrderListQueryForDate request,
            CancellationToken cancellationToken)
        {
            var ordersQuery = await _dbContext.Orders
                .Where(order => order.CreateDate.Date == request.Date.Date)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}