﻿using System;
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
      public  DbSet<Order> Orders { get; set; }

      public FCorpDbContext(DbContextOptions<FCorpDbContext> options)
          : base(options) { }

      protected override void OnModelCreating(ModelBuilder builder)
      {
          builder.ApplyConfiguration(new FCorpConfiguration());
      }
    }
}
