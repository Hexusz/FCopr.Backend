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

namespace FCopr.Application.FCorp.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IFCorpDbContext _dbContext;

        public CreateOrderCommandHandler(IFCorpDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Order> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CreateDate = DateTime.Now,
                ClientFullName = request.ClientFullName,
                Positions = request.Positions,
                Status = request.Status
            };

            var goodsCount = order.Positions.Sum(x => x.Count);

            if (goodsCount > 10)
            {
                throw new IncorrectAmountGoodsException(goodsCount, request.Positions);
            }

            var goodsPrice = order.Positions.Sum(x => _dbContext.Goods.First(g => g.Articul == x.GoodArticul).Price * x.Count);

            if (goodsPrice > 15000)
            {
                throw new IncorrectPriceException(goodsPrice, request.Positions);
            }

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order;
        }
    }
}
