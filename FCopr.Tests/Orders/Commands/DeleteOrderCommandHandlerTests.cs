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
    public class DeleteOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteOrderCommandHandler(Context);
            ushort idOrder = 1;
            // Act
            await handler.Handle(new DeleteOrderCommand()
            {
                OrderId = idOrder
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Orders.SingleOrDefaultAsync(order =>
                order.OrderId == idOrder));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteOrderCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteOrderCommand
                    {
                        OrderId = ushort.MaxValue
                    },
                    CancellationToken.None));
        }
    }
}
