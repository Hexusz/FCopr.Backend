using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FCopr.Application.Common.Exceptions;
using FCopr.Application.FCorp.Commands.UpdateOrder;
using FCopr.Application.Interfaces;
using FCorp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.FCorp.Commands.PartialUpdateOrder
{
    public class PartialUpdateOrderCommandHandler : IRequestHandler<PartialUpdateOrderCommand, Order>
    {
        private readonly IFCorpDbContext _dbContext;

        public PartialUpdateOrderCommandHandler(IFCorpDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Order> Handle(PartialUpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Orders.Include(u => u.Positions).ThenInclude(p => p.Good)
                    .FirstOrDefaultAsync(order =>
                        order.OrderId == request.OrderId, cancellationToken);

            if (entity == null || entity.OrderId != request.OrderId)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            if (entity.Status != OrderStatus.Registered)
            {
                throw new IncorrectStatusException(entity.OrderId, entity.Status, request.OrderId);
            }

            entity.OrderId = request.OrderId;

            if (request.ClientFullName != null)
                entity.ClientFullName = request.ClientFullName;

            entity.Status = request.Status;

            if (request.Positions != null)
            {
                entity.Positions.AddRange(request.Positions);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
