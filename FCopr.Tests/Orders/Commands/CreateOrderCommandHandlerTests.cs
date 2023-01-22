using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FCopr.Application.Common.Exceptions;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FCopr.Application.FCorp.Commands.DeleteOrder;
using FCopr.Tests.Common;
using FCorp.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FCopr.Tests.Orders.Commands
{
    public class CreateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateOrderCommandHandler(Context);
            var client = "asdasd";
            var status = OrderStatus.Registered;
            var positions = new List<OrderPositions>()
            {
                new OrderPositions(){Count = 2,GoodArticul = 1},
                new OrderPositions(){Count = 1,GoodArticul = 2}
            };

            // Act
            var orderId = await handler.Handle(new CreateOrderCommand()
            {
                ClientFullName = client,
                Status = status,
                Positions = positions
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Orders.SingleOrDefaultAsync(order =>
                order.OrderId == orderId.OrderId && orderId.ClientFullName == client
                                         && order.Status == status && order.Positions.Count == positions.Count));
        }

        [Fact]
        public async Task CreateOrderCommandHandler_FallOnManyGoods()
        {
            // Arrange
            var handler = new CreateOrderCommandHandler(Context);
            var client = "asdasd";
            var status = OrderStatus.Registered;
            var positions = new List<OrderPositions>()
            {
                new OrderPositions(){Count = 11,GoodArticul = 1},
                new OrderPositions(){Count = 1,GoodArticul = 2}
            };

            // Act
            // Assert
            await Assert.ThrowsAsync<IncorrectAmountGoodsException>(async () =>
                await handler.Handle(
                    new CreateOrderCommand()
                    {
                        ClientFullName = client,
                        Status = status,
                        Positions = positions
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task CreateOrderCommandHandler_FallOnBigPrice()
        {
            // Arrange
            var handler = new CreateOrderCommandHandler(Context);
            var client = "asdasd";
            var status = OrderStatus.Registered;
            var positions = new List<OrderPositions>()
            {
                new OrderPositions(){Count = 1,GoodArticul = 1},
                new OrderPositions(){Count = 9,GoodArticul = 2}
            };

            // Act
            // Assert
            await Assert.ThrowsAsync<IncorrectPriceException>(async () =>
                await handler.Handle(
                    new CreateOrderCommand()
                    {
                        ClientFullName = client,
                        Status = status,
                        Positions = positions
                    }, CancellationToken.None));
        }
    }
}
