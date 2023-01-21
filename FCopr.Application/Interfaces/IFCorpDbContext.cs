using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FCorp.Domain;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Interfaces
{
    public interface IFCorpDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Good> Goods { get; set; }
        DbSet<OrderPositions> OrderPositions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
