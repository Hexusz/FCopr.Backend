using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCopr.Application.Interfaces;
using FCorp.Domain;
using FCorp.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FCorp.Persistence
{
    public class FCorpDbContext : DbContext, IFCorpDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPositions> OrderPositions { get; set; }
        public DbSet<Good> Goods { get; set; }


        public FCorpDbContext(DbContextOptions<FCorpDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderPositionsConfiguration());
            builder.ApplyConfiguration(new GoodConfiguration());
        }
    }
}
