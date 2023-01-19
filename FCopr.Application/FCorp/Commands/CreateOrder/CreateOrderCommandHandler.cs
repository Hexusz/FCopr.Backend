using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FCopr.Application.Interfaces;
using FCorp.Domain;
using MediatR;

namespace FCopr.Application.FCorp.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, ushort>
    {
        private readonly IFCorpDbContext _dbContext;

        public CreateOrderCommandHandler(IFCorpDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ushort> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ClientFullName = request.ClientFullName,
                OrderPositions = request.OrderPositions,
                Status = request.Status
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.OrderId;
        }
    }
}
