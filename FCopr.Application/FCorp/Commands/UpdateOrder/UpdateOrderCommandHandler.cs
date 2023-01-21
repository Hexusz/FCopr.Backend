using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FCopr.Application.Common.Exceptions;
using FCopr.Application.Interfaces;
using FCorp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.FCorp.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly IFCorpDbContext _dbContext;

        public UpdateOrderCommandHandler(IFCorpDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Order> Handle(UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Orders.Include(u => u.Positions)
                    .FirstOrDefaultAsync(order =>
                    order.OrderId == request.OrderId, cancellationToken);

            if (entity == null || entity.OrderId != request.OrderId)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            entity.OrderId = request.OrderId;
            entity.ClientFullName = request.ClientFullName;
            entity.Positions = request.Positions;
            entity.Status = request.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
