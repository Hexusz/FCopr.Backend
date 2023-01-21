using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FCopr.Application.Interfaces;
using FCorp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Orders.Queries.GetOrderList
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
            DateTime date;

            DateTime.TryParse(request.Date,out date);

            var ordersQuery = await _dbContext.Orders
                .Where(order => order.CreateDate.Date == date.Date)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}