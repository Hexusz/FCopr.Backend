﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Exceptions;
using FCopr.Application.Interfaces;
using FCorp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IFCorpDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IFCorpDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.Include(u => u.Positions).ThenInclude(p=>p.Good)
                .FirstOrDefaultAsync(order =>
                    order.OrderId == request.OrderId, cancellationToken);

            if (entity == null || entity.OrderId != request.OrderId)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            return _mapper.Map<OrderDetailsVm>(entity);
        }
    }
}
