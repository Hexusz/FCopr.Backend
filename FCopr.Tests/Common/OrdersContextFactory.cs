using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using FCorp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Tests.Common
{
    public class OrdersContextFactory
    {
        public static FCorpDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FCorpDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new FCorpDbContext(options);

            context.Goods.Add(new Good()
            {
                Price = 1000,
                Name = "Good1",
                Articul = 1
            });
            context.Goods.Add(new Good()
            {
                Price = 5000,
                Name = "Good2",
                Articul = 2
            });

            context.Orders.Add(new Order()
            {
                OrderId = 1,
                Status = 0,
                ClientFullName = "asd",
                CreateDate = DateTime.Now,
                Positions = new List<OrderPositions>()
                {
                    new OrderPositions(){Count = 1,GoodArticul = 1},
                    new OrderPositions(){Count = 2,GoodArticul = 2},
                }
            });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(FCorpDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
