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

namespace FCopr.Application.FCorp.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler
    : IRequestHandler<DeleteOrderCommand>
    {

        private readonly IFCorpDbContext _dbContext;

        public DeleteOrderCommandHandler(IFCorpDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders
                .FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            if (entity.Status == OrderStatus.Registered)
            {
                _dbContext.Orders.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                //У заказа статус отличный от "Зарегистрирован"
            }

            return Unit.Value;
        }
    }
}
